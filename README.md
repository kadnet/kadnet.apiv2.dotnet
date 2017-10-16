# Kadnet.API.Client
Kadnet API v2 dotNet

Full description API on postman:  
https://documenter.getpostman.com/view/2625849/kadnet-api/6tgTfhm#intro

# How to use #
* Generate your private apikey on https://api.kadnet.ru
* Download .net client project
* Add Kadnet.Api.Client project to your solution
* Use it

```C#
var client = new Client(apikey);  
var result = client.CheckNumbers("66:41:0402033:2266;66:41:0402033:2267", "just test").Result;
```

More Examples in TestModule:  
https://github.com/kadnet/kadnet.apiv2.dotnet/blob/master/Kadnet.Api.Client/Kadnet.Api.ClientTest/ClientTest.cs

================================================================================

# Клиент для запроса кадастровых данных из Росреестра через программный интерфейс Каднет

Полное описание API Каднет можно найти тут:  
https://documenter.getpostman.com/view/2625849/kadnet-api/6tgTfhm#intro

# Начало работы: #
* Зарегистрироваться на сайте Каднет
* Сгенерировать ключ доступа на сайте https://api.kadnet.ru
* Загрузить проект .net клиента
* Подключить проект к вашему решению

Больше примеров использования можно найти в тестовом модуле  
https://github.com/kadnet/kadnet.apiv2.dotnet/blob/master/Kadnet.Api.Client/Kadnet.Api.ClientTest/ClientTest.cs

 
 
