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
    exchange: "fanout-exchange-example",
    type:ExchangeType.Fanout
    );

Console.Write("Kuyruk adını giriniz :");
string queuename = Console.ReadLine();

channel.QueueDeclare(
    queue: queuename,
    exclusive:false);


channel.QueueBind(
    queue: queuename,
    exchange: "fanout-exchange-example",
    routingKey:string.Empty
    );

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    queue:queuename,
    autoAck:true,
    consumer:consumer);

consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);
};

Console.Read();