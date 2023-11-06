using RabbitMQ.Client;
using System.Text;
//Create Connection
ConnectionFactory factory = new();
factory.Uri = new("amqps://acggcrmh:zagmC6HPcGM0J9wO6DkhnPaI1z7N2Vwr@fish.rmq.cloudamqp.com/acggcrmh");

//Activating the connection and opening a channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(
    exchange: "direct-exchange-example", 
    type: ExchangeType.Direct);

while (true)
{
    Console.Write("Mesaj : " );
    string message = Console.ReadLine();
    byte[] byteMsg = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(
        exchange: "direct-exchange-example",
        routingKey:"direct-queue-example",
        body:byteMsg);
}

Console.Read();