using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
};

await using var connection = await factory.CreateConnectionAsync();
await using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(
    queue: "testqueue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var message = "Hello from .NET Producer";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(
    exchange: string.Empty,
    routingKey: "testqueue",
    body: body);

Console.WriteLine("Message sent successfully.");