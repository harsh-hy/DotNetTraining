using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
public class RabbitMqService
{
    public List<ChatMessage> ReceivedMessages = new List<ChatMessage>();
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;

    public RabbitMqService(IConfiguration configuration)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        // 1️⃣ Declare Exchange
        _channel.ExchangeDeclare(
            exchange: "chat-exchange",
            type: ExchangeType.Direct);

        // 2️⃣ Each running instance has its own queue
        _queueName = configuration["ChatUser"];
        _channel.QueueDeclare(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        // 3️⃣ Bind Queue to Exchange using routing key
        _channel.QueueBind(
            queue: _queueName,
            exchange: "chat-exchange",
            routingKey: _queueName);

        // 4️⃣ Start Listening
        StartConsumer();
    }

    public void Publish(ChatMessage message)
    {
        var json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        _channel.BasicPublish(
            exchange: "chat-exchange",
            routingKey: message.Receiver,
            basicProperties: null,
            body: body);
    }

    private void StartConsumer()
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = JsonSerializer.Deserialize<ChatMessage>(
                Encoding.UTF8.GetString(body));

            ReceivedMessages.Add(message);
            Console.WriteLine($"Message received from {message.Sender}: {message.Content}");
        };

        _channel.BasicConsume(
            queue: _queueName,
            autoAck: true,
            consumer: consumer);
    }
}