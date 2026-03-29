using System.Text;
using System.Text.Json;
using ConsumerApi.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerApi.Services;

public sealed class RabbitMqConsumerService : BackgroundService
{
    private readonly ILogger<RabbitMqConsumerService> _logger;
    private readonly ReceivedMessageStore _store;
    private readonly RabbitMqOptions _options;
    private IConnection? _connection;
    private IModel? _channel;

    public RabbitMqConsumerService(
        ILogger<RabbitMqConsumerService> logger,
        ReceivedMessageStore store,
        IOptions<RabbitMqOptions> options)
    {
        _logger = logger;
        _store = store;
        _options = options.Value;
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("[RabbitMQ] Connecting to {Host}:{Port}, Exchange: {Exchange}, Queue: {Queue}, RoutingKey: {RoutingKey}",
            _options.HostName, _options.Port, _options.ExchangeName, _options.QueueName, _options.RoutingKey);

        var factory = new ConnectionFactory
        {
            HostName = _options.HostName,
            Port = _options.Port,
            UserName = _options.UserName,
            Password = _options.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _logger.LogInformation("[RabbitMQ] Connection and channel established.");
        _channel.ExchangeDeclare(_options.ExchangeName, ExchangeType.Direct, durable: true);
        _logger.LogInformation("[RabbitMQ] Exchange declared: {Exchange}", _options.ExchangeName);
        _channel.QueueDeclare(_options.QueueName, durable: true, exclusive: false, autoDelete: false);
        _logger.LogInformation("[RabbitMQ] Queue declared: {Queue}", _options.QueueName);
        _channel.QueueBind(_options.QueueName, _options.ExchangeName, _options.RoutingKey);
        _logger.LogInformation("[RabbitMQ] Queue bound: {Queue} -> {Exchange} ({RoutingKey})", _options.QueueName, _options.ExchangeName, _options.RoutingKey);
        _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        return base.StartAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_channel is null)
        {
            _logger.LogError("[RabbitMQ] Channel is null in ExecuteAsync.");
            throw new InvalidOperationException("RabbitMQ channel has not been initialized.");
        }

        _logger.LogInformation("[RabbitMQ] Consumer started. Waiting for messages...");
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (_, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());
            _logger.LogInformation("[RabbitMQ] Message received: {Payload}", json);
            var message = JsonSerializer.Deserialize<RabbitMessage>(json);

            if (message is null)
            {
                _logger.LogWarning("[RabbitMQ] Received an invalid message payload: {Payload}", json);
                _channel.BasicNack(ea.DeliveryTag, multiple: false, requeue: false);
                return;
            }

            _store.Add(message);
            _logger.LogInformation("[RabbitMQ] Received message {MessageId} from {Sender}", message.Id, message.Sender);
            _channel.BasicAck(ea.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(_options.QueueName, autoAck: false, consumer);
        _logger.LogInformation("[RabbitMQ] BasicConsume started on queue: {Queue}", _options.QueueName);
        return Task.Delay(Timeout.Infinite, stoppingToken);
    }

    public override void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
        base.Dispose();
    }
}
