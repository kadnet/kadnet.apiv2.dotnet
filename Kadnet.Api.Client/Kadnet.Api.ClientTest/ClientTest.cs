using System;
using System.Collections.Generic;
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
            var client = new Client(klimapikey, "", "https://api.kadnet.ru/v2/");
            //var client = new Client(apikey);


            var objectArray = client.CheckNumbers("", "just test").ToArray();

            if (objectArray.Any())
            {
                Console.WriteLine($"{objectArray[0].Number};не найден;");
            }
            else
            {
                Console.WriteLine($"{objectArray[0].Number};{objectArray[0].Address};{objectArray[0].Status};{objectArray[0].IsCanceled};{objectArray[0].Area}");
            }


            Assert.That(objectArray.Length, Is.EqualTo(2));
        }



        //[Test]
        //public void CheckNumbersAsJson_GetJsonString()
        //{
        //    var client = new Client(apikey);
        //    var json = client.CheckNumbersAsJsonAsyncTask("66:41:0402033:2266;66:41:0402033:2267", "just test").Result;
        //    StringAssert.StartsWith("{\"Result\":true", json);
        //}

        [Test]
        public void CheckAddress_GetCadastralObjectArrayWithElements()
        {

            //var client = new Client(apikey);
            //var client = new Client(apikey, "", "https://api.kadnet.ru/v2/");
            var client = new Client(klimapikey, "", "https://test-api.kadnet.ru/v2/");

            var objectArray = client.CheckAddressAsJsonAsyncTask("г Екатеринбург, ул Дорожная, д 13", false).Result;
            Assert.That(objectArray.Length, Is.GreaterThan(1));
        }

        [Test]
        public void CheckInn()
        {

            var client = new Client(apikey, "", "https://test-api.kadnet.ru/v2/");
            //var client = new Client(apikey);
            var objectArray = client.CheckInn("6679093937").ToArray();
            Assert.That(objectArray.Length, Is.GreaterThan(1));
        }

        //[Test]
        //public void CheckList_GetListRequests()
        //{
        //    var client = new Client(apikey);
        //    var objectArray = client.GetListRequestInfoAsyncTask(20, 4).Result.ToArray();
        //    Assert.That(objectArray.Length, Is.EqualTo(20));
        //}

        //[Test]
        //public void CheckListById_GetListRequests()
        //{
        //    var client = new Client(apikey);
        //    var list = new Guid[] { Guid.Parse("6ff23ab5-5996-44fb-831a-00c17a98a6d6"), Guid.Parse("dc0d91f2-62f1-4d0b-b451-72ea3d096cf4") };
        //    var objectArray = client.GetListRequestInfoAsyncTask(list).Result.ToArray();
        //    Assert.That(objectArray.Length, Is.EqualTo(20));
        //}

        //[Test]
        //public void CheckAddressAsJson_GetJsonString()
        //{
        //    var client = new Client(apikey);
        //    var json = client.CheckAddressAsJsonAsyncTask("Екатеринбург, ул. Малопрудная 5").Result;
        //    StringAssert.StartsWith("{\"Result\":true", json);
        //}

        [Test]
        public void TestCreateRequest_GetRequestTicket()
        {

            var client = new Client(apikey, "", "https://test-api.kadnet.ru/v2/");
            //var client = new Client(apikey);
            var coi = new CadastralObjectInfo()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.Parse("c067ed89-607f-4cd0-8b53-43658dc0688d"),
                Number = "66:41:0501054:2335",
                Comment = "Екатеринбург, ул. Авиационная, д. 59, кв. 11",
                ObjectType = "Помещение",
                Region = "66"
            };
            var ticket = client.CreateRequestAsyncTask(coi, RequestType.EgrnObject).Result;


            Assert.That(ticket.Result, Is.True);
        }

        //[Test]
        //public void TestGetInfo_GetRequestInfo()
        //{
        //    var client = new Client(apikey);
        //    var ri = client.GetRequestInfoAsyncTask("5079cfff-da4d-403a-a7c2-9cf79a83f06e").Result;
        //    Assert.AreEqual(ri.Status, "Завершен");
        //}

        [Test]
        public void TestResult_GetFileResultEntry()
        {
            //https://api.kadnet.ru/v2/;token=ec650871-0c2d-438c-a708-fa1b817ddd3f;param=&UserId=dca77536-438f-41ca-8087-42cdde69da8e&OrgId=751219d9-b134-41e0-be9e-a86e24093c6d&UserEmail=ki@kadnet.ru
            var param = "&UserId=dca77536-438f-41ca-8087-42cdde69da8e&OrgId=751219d9-b134-41e0-be9e-a86e24093c6d&UserEmail=ki@kadnet.ru";
            var client = new Client(klimapikey, param);
            var ri = client.GetResultAsyncTask("97a93566-c71b-4c97-ad38-26b4761aaab7", ResultFormat.Html).Result;
            File.WriteAllBytes($"D:\\{ri.Name}", ri.Data?.ToArray());
            Assert.NotNull(ri?.Data);
        }

        //[Test]
        //public void TestHistory_GetHistoryEntryArray()
        //{
        //    var client = new Client(klimapikey);
        //    var ri = client.GetHistoryAsyncTask(Guid.Parse("1d8b64b9-30df-4d7f-b678-3ba76c039fbe")).Result;
        //    Assert.IsTrue(ri.Any());
        //}

        //[Test]
        //public void TestDelete()
        //{
        //    var client = new Client(klimapikey);
        //    var resFlag = client.DeleteAsyncTask(Guid.Parse("5079cfff-da4d-403a-a7c2-9cf79a83f06e")).Result;
        //    Assert.IsTrue(resFlag);
        //}

    }
}
