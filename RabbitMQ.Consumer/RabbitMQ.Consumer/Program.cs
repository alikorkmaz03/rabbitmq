using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Create Connection
ConnectionFactory factory = new();
factory.Uri = new Uri("amqps://acggcrmh:zagmC6HPcGM0J9wO6DkhnPaI1z7N2Vwr@fish.rmq.cloudamqp.com/acggcrmh");
//Activating the connection and opening a channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
//Create Queue
//(exclusive) The queue can be used by multiple connections.The queue must be declared with the exact same configuration as the publisher
channel.QueueDeclare(queue: "example-queue", exclusive: false, durable:true);
//Read Message in Queue
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue",autoAck:false,consumer);//Configure message acknowledgement for autoAck 

consumer.Received += (sender, e) =>
{
    //the place where the message arriving in the queue is processed
    //e.Body.Span  or e.Body.ToArray()

    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));

    channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false );//Configure message acknowledgement propert. BasicAck multiple should be false

    
};
Console.Read();