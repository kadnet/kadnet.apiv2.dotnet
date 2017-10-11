using System;
using System.IO;
using System.Linq;
using Kadnet.Api.Models;
using NUnit.Framework;

//using NUnit.Framework;

namespace Kadnet.Api.ClientTest
{
    [TestFixture]
    public class ClientTest
    {
        //Fake key. Generate your actual key on https://api.kadnet.ru
        private string apikey = "";
        private string klimapikey = "";

        [Test]
        public void CheckNumbers_GetCadastralObjectArrayWith2Elements()
        {
            var client = new Client(apikey);
            var objectArray = client.CheckNumbersAsyncTask("66:41:0402033:2266;66:41:0402033:2267", "just test").Result.ToArray();
            Assert.That(objectArray.Length, Is.EqualTo(2));
        }

        [Test]
        public void CheckNumbersAsJson_GetJsonString()
        {
            var client = new Client(apikey);
            var json = client.CheckNumbersAsJsonAsyncTask("66:41:0402033:2266;66:41:0402033:2267", "just test").Result;
            StringAssert.StartsWith("{\"Result\":true", json);
        }

        [Test]
        public void CheckAddress_GetCadastralObjectArrayWithElements()
        {
            var client = new Client(apikey);
            var objectArray = client.CheckAddressAsyncTask("Екатеринбург, ул. Малопрудная 5").Result.ToArray();
            Assert.That(objectArray.Length, Is.GreaterThan(1));
        }

        [Test]
        public void CheckAddressAsJson_GetJsonString()
        {
            var client = new Client(apikey);
            var json = client.CheckAddressAsJsonAsyncTask("Екатеринбург, ул. Малопрудная 5").Result;
            StringAssert.StartsWith("{\"Result\":true", json);
        }

        [Test]
        public void TestCreateRequest_GetRequestTicket()
        {
            var client = new Client(apikey);
            var coi = new CadastralObjectInfo()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.Parse("c067ed89-607f-4cd0-8b53-43658dc0688d"),
                Number = "66:41:0402033:2266",
                Comment = "test request from api",
                ObjectType = "Участок",
                Region = "66"
            };
            var ticket = client.CreateRequestAsyncTask(coi, RequestType.EgrnObject).Result;
            Assert.That(ticket.Result, Is.True);
        }

        [Test]
        public void TestGetInfo_GetRequestInfo()
        {
            var client = new Client(apikey);
            var ri = client.GetRequestInfoAsyncTask(Guid.Parse("5079cfff-da4d-403a-a7c2-9cf79a83f06e")).Result;
            Assert.AreEqual(ri.Status, "Завершен");
        }

        [Test]
        public void TestResult_GetFileResultEntry()
        {
            var client = new Client(klimapikey);
            var ri = client.GetResultAsyncTask(Guid.Parse("1d8b64b9-30df-4d7f-b678-3ba76c039fbe"), ResultFormat.Html).Result;
            File.WriteAllBytes($"D:\\{ri.Name}",ri.Data?.ToArray());
            Assert.NotNull(ri?.Data);
        }

        [Test]
        public void TestHistory_GetHistoryEntryArray()
        {
            var client = new Client(klimapikey);
            var ri = client.GetHistoryAsyncTask(Guid.Parse("1d8b64b9-30df-4d7f-b678-3ba76c039fbe")).Result;
            Assert.IsTrue(ri.Any());
        }

        [Test]
        public void TestDelete()
        {
            var client = new Client(klimapikey);
            var resFlag = client.DeleteAsyncTask(Guid.Parse("5079cfff-da4d-403a-a7c2-9cf79a83f06e")).Result;
            Assert.IsTrue(resFlag);
        }
      
    }
}
