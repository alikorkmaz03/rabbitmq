using RabbitMQ.Client;
using System.Text;
//Create Connection
ConnectionFactory factory = new();
factory.Uri = new("amqps://acggcrmh:zagmC6HPcGM0J9wO6DkhnPaI1z7N2Vwr@fish.rmq.cloudamqp.com/acggcrmh");

//Activating the connection and opening a channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Create Queue
//Kuyruklar içindeki mesajları kalıcı hale getirmek için durable özelliği true kullanılır.
channel.QueueDeclare(queue: "example-queue",exclusive:false,durable:true);

//Send Queue (!important :  RabbitMQ accepts the messages it sends to the queue in byte array type.We should convert byte array type)
//byte[] message = Encoding.UTF8.GetBytes("İlk RabbitMQ Mesajı");
//channel.BasicPublish(exchange: "", routingKey: "example-queue",body:message);//exchange default using direct exchange

IBasicProperties properties = channel.CreateBasicProperties();
properties.Persistent = true;

for (int i = 0; i < 100; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("RabbitMQ Mesajı" + i);
    //basicProperties:properties kalıcı ileti olucak fakat iletinin tam kayıpolmayacağını garanti etmez. outbox inbox design pattern kullanmak gerekebilir.
    channel.BasicPublish(exchange: "", routingKey: "example-queue",body:message,basicProperties:properties);//exchange default using direct exchange
}
Console.Read();