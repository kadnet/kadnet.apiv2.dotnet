using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadnet.Api.RegistrationClientTest
{
    [TestFixture]
    public class TestClass
    {
        //Fake key. Generate your actual key on https://api.kadnet.ru
        private string apikey = "";
        private string testServer = "https://test-api.kadnet.ru/v2/";


        //===== Test Object =====//
        [Test]
        public void TestGetObjectKinds()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.GetObjectKinds().Result;
            Assert.That(objectArray.Count, Is.EqualTo(8));
        }
        [Test]
        public void TestGetAllObjects()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.GetObjects().Result;
            Assert.That(objectArray.Count, Is.GreaterThan(1));
        }
        //[Test]
        //public void TestSaveObject()
        //{
        //    var client = new RegistrationApiClient(apikey, url: testServer);
        //    var json = "{\"Id\": \"d743ba92-198f-4870-8575-679e5df4b203\",\"KindId\": \"ee132d91-0b59-4b6d-898f-1fbe2620f689\",\"Number\": \"-\",\"Address\": \"г Екатеринбург, ул Генеральская, стр 6А\",\"Area\": 4.0,\"Visible\": true}";
        //    var objectArray = client.SaveObjects(json).Result;
        //    Assert.That(objectArray.Key, Is.True);
        //}
        [Test]
        public void TestGetOneObject()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.GetObjects(Guid.Parse("d743ba92-198f-4870-8575-679e5df4b203")).Result;
            Assert.That(objectArray.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestDeleteObject()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.DeleteObjects(Guid.Parse("d743ba92-198f-4870-8575-679e5df4b203")).Result;
            Assert.That(objectArray.Key, Is.False);
        }


        //===== Clients ======/
        [Test]
        public void TestClientKind()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.ClientsKind().Result;
            Assert.That(objectArray.Count, Is.EqualTo(3));
        }
        [Test]
        public void TestClientGovCodes()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.ClientsGovernanceCodes().Result;
            Assert.That(objectArray.Count, Is.GreaterThan(3));
        }
        [Test]
        public void TestClientDocumentTypes()
        {
            var client = new RegistrationApiClient(apikey,url:testServer);
            var objectArray = client.ClientsDocumentTypes().Result;
            Assert.That(objectArray.Count, Is.GreaterThan(3));
        }
        [Test]
        public void TestGetAllClients()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.GetClients().Result;
            Assert.That(objectArray.Count, Is.GreaterThan(3));
        }
        [Test]
        public void TestGetOneClient()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var objectArray = client.GetClients(Guid.Parse("74cfd617-56c5-4817-96ad-04c16203b064")).Result;
            Assert.That(objectArray.Count, Is.EqualTo(1));
        }
        [Test]
        public void TestSaveClient()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var oneClientData = client.GetClients(Guid.Parse("d46bd292-3645-438f-94e1-afe8c48947c3")).Result.FirstOrDefault(); //Ярослав Баландин
            oneClientData.Snils = "000-000-001 10";
            var res = client.SaveClient(oneClientData).Result;
            Assert.That(res, Is.True);
        }
        [Test]
        public void TestDeleteClient()
        {
            var client = new RegistrationApiClient(apikey, url: testServer);
            var res = client.DeleteClients(Guid.Parse("d46bd292-3645-438f-94e1-afe8c48947c3")).Result;
            Assert.That(res.Key, Is.True);
        }
    }
}
