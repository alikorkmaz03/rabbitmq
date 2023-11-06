using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
//Create Connection
ConnectionFactory factory = new();
factory.Uri = new("amqps://acggcrmh:zagmC6HPcGM0J9wO6DkhnPaI1z7N2Vwr@fish.rmq.cloudamqp.com/acggcrmh");

//Activating the connection and opening a channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange:"fanout-exchange-example",
    type:ExchangeType.Fanout
    );


for(int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes($"Gönderilen Mesaj {i}");
    channel.BasicPublish(
        exchange: "fanout-exchange-example",
        routingKey: string.Empty,
        body: message);
}

Console.Read();