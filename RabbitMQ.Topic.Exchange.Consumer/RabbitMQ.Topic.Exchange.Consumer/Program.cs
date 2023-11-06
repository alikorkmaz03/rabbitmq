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
    exchange: "topic-exchange-example",
    type: ExchangeType.Topic
    );

string? topic = null;
while (string.IsNullOrEmpty(topic))
{
    Console.WriteLine("Dinlencek topic formatı belirtiniz : ");
    topic = Console.ReadLine();

    if (string.IsNullOrEmpty(topic))
    {
        Console.WriteLine("Topic boş bırakılamaz! Lütfen değer giriniz ");
    }

}
string queueName = channel.QueueDeclare().QueueName;



channel.QueueBind(
    queue: queueName,
    exchange: "topic-exchange-example",
    routingKey: topic
    );

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(
    queue: queueName,
    autoAck: true,
    consumer
    );


consumer.Received += (sender, e) =>
{
    string message = Encoding.UTF8.GetString(e.Body.Span);
    Console.WriteLine(message);

};
// Wait for user input to exit
Console.WriteLine("Çıkmak için [Enter] tuşuna basın.");
Console.ReadLine();