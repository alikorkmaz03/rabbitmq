RabbitMQ Nugget Package for Consumer

->dotnet add package RabbitMQ.Client --version 6.6.0
- Create Connection
- Activating the connection and opening a channel
- Create Queue
- Read Message in Queue

-----------------ACKNOWLEDGEMENT  YAPILANDIRMASI------------------
BasicAck:

A��klama: Bir mesaj�n ba�ar�yla i�lendi�ini bildirir.
Kullan�m:
csharp
Copy code
channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
Parametreler:
deliveryTag: ��lenen mesaj� tan�mlamak i�in kullan�l�r.
multiple: E�er true olarak ayarlan�rsa, belirtilen deliveryTag'e kadar olan t�m mesajlar onaylanm�� say�l�r.

BasicNack:

A��klama: Bir mesaj�n i�lenemedi�ini veya t�ketici taraf�ndan reddedildi�ini bildirir.
Kullan�m:
csharp
Copy code
channel.BasicNack(deliveryTag: e.DeliveryTag, multiple: false, requeue: false);
Parametreler:
deliveryTag: ��lenen mesaj� tan�mlamak i�in kullan�l�r.
multiple: E�er true olarak ayarlan�rsa, belirtilen deliveryTag'e kadar olan t�m mesajlar reddedilmi� say�l�r.
requeue: E�er true olarak ayarlan�rsa, reddedilen mesaj tekrar kuyru�a eklenir. E�er false olarak ayarlan�rsa, mesaj kuyruktan silinir.


BasicReject:

A��klama: Bir mesaj�n i�lenemedi�ini bildirir.
Kullan�m:
csharp
Copy code
channel.BasicReject(deliveryTag: e.DeliveryTag, requeue: false);
Parametreler:
deliveryTag: ��lenen mesaj� tan�mlamak i�in kullan�l�r.
requeue: E�er true olarak ayarlan�rsa, reddedilen mesaj tekrar kuyru�a eklenir. E�er false olarak ayarlan�rsa, mesaj kuyruktan silinir.


BasicCancel:

A��klama: T�ketici taraf�ndan bir aboneli�in iptal edilmesini talep etmek i�in kullan�l�r.
Kullan�m:
csharp
Copy code
channel.BasicCancel(consumerTag: "myConsumerTag");
Parametreler:
consumerTag: �ptal edilmek istenen t�keticiyi tan�mlamak i�in kullan�l�r. Bu etiket, t�ketici ba�lat�l�rken belirlenir.
Bu kod par�ac�klar�, RabbitMQ'nun .NET istemci k�t�phanesi ile kullan�lan temel y�ntemlerin basit kullan�m �rnekleridir. Ger�ek uygulamalarda, bu y�ntemlerin kullan�m� daha karma��k senaryolar� da kapsayabilir.