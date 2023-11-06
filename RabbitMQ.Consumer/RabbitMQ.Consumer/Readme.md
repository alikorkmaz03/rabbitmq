RabbitMQ Nugget Package for Consumer

->dotnet add package RabbitMQ.Client --version 6.6.0
- Create Connection
- Activating the connection and opening a channel
- Create Queue
- Read Message in Queue

-----------------ACKNOWLEDGEMENT  YAPILANDIRMASI------------------
BasicAck:

Açýklama: Bir mesajýn baþarýyla iþlendiðini bildirir.
Kullaným:
csharp
Copy code
channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
Parametreler:
deliveryTag: Ýþlenen mesajý tanýmlamak için kullanýlýr.
multiple: Eðer true olarak ayarlanýrsa, belirtilen deliveryTag'e kadar olan tüm mesajlar onaylanmýþ sayýlýr.

BasicNack:

Açýklama: Bir mesajýn iþlenemediðini veya tüketici tarafýndan reddedildiðini bildirir.
Kullaným:
csharp
Copy code
channel.BasicNack(deliveryTag: e.DeliveryTag, multiple: false, requeue: false);
Parametreler:
deliveryTag: Ýþlenen mesajý tanýmlamak için kullanýlýr.
multiple: Eðer true olarak ayarlanýrsa, belirtilen deliveryTag'e kadar olan tüm mesajlar reddedilmiþ sayýlýr.
requeue: Eðer true olarak ayarlanýrsa, reddedilen mesaj tekrar kuyruða eklenir. Eðer false olarak ayarlanýrsa, mesaj kuyruktan silinir.


BasicReject:

Açýklama: Bir mesajýn iþlenemediðini bildirir.
Kullaným:
csharp
Copy code
channel.BasicReject(deliveryTag: e.DeliveryTag, requeue: false);
Parametreler:
deliveryTag: Ýþlenen mesajý tanýmlamak için kullanýlýr.
requeue: Eðer true olarak ayarlanýrsa, reddedilen mesaj tekrar kuyruða eklenir. Eðer false olarak ayarlanýrsa, mesaj kuyruktan silinir.


BasicCancel:

Açýklama: Tüketici tarafýndan bir aboneliðin iptal edilmesini talep etmek için kullanýlýr.
Kullaným:
csharp
Copy code
channel.BasicCancel(consumerTag: "myConsumerTag");
Parametreler:
consumerTag: Ýptal edilmek istenen tüketiciyi tanýmlamak için kullanýlýr. Bu etiket, tüketici baþlatýlýrken belirlenir.
Bu kod parçacýklarý, RabbitMQ'nun .NET istemci kütüphanesi ile kullanýlan temel yöntemlerin basit kullaným örnekleridir. Gerçek uygulamalarda, bu yöntemlerin kullanýmý daha karmaþýk senaryolarý da kapsayabilir.