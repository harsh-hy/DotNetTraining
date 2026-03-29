using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<List<string>>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var messages = app.Services.GetRequiredService<List<string>>();

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
};

var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "testqueue2",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    messages.Add(message);
    await Task.CompletedTask;
};

await channel.BasicConsumeAsync(
    queue: "testqueue2",
    autoAck: true,
    consumer: consumer);

app.MapGet("/messages", () => messages);

app.Run();