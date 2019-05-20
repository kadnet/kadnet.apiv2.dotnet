using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Kadnet.Api2.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Kadnet.Api
{
    public class RegistrationApiClient
    {
        private readonly string _baseUrl;
        private readonly string _apikey;
        private readonly string _params;

        /// <summary>
        /// </summary>
        /// <param name="apikey">Your api key. Request at hello@kadnet.ru</param>
        /// <param name="urlparam">Other request parameters</param>
        /// <param name="url">Custom API entiry</param>
        public RegistrationApiClient(string apikey, string urlparam = "", string url = "https://api.kadnet.ru/v2/")
        {
            _apikey = apikey;
            _baseUrl = url;
            if (!string.IsNullOrEmpty(urlparam))
                _params = urlparam.StartsWith("&") ? urlparam : $"&{urlparam}";
            else
                _params = string.Empty;
        }
        /// <summary>
        /// Создание запроса
        /// </summary>
        /// <param name="method">Метод HTTP</param>
        /// <param name="urlParameters">URL запроса</param>
        /// <param name="jsonData">JSON передаваемого объекта</param>
        /// <returns></returns>
        private async Task<string> CreateRequest(Method method, string urlParameters, string jsonData = null)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(urlParameters+"?api-key={apikey}" + _params, method);
            request.AddUrlSegment("apikey", _apikey);
            if (!string.IsNullOrEmpty(jsonData))
                request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            var cancellationToken = new CancellationToken();
            var response = await client.ExecuteTaskAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            return null;
        }

        //======== Objects ========== 
        /// <summary>
        /// Допустимые типы объектов недвижимости. Статические данные
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> GetObjectKindsAsJson()
        {
            return await CreateRequest(Method.GET, "Objects/Kinds");
        }
        /// <summary>
        /// Допустимые типы объектов недвижимости. Статические данные
        /// </summary>
        /// <returns>KeyValuePair Array</returns>
        public async Task<Dictionary<Guid, string>> GetObjectKinds()
        {
            var result = new Dictionary<Guid, string>();
            var jsonResponse = await GetObjectKindsAsJson();
            {
                var data = JObject.Parse(jsonResponse);
                if ((bool)data["Result"])
                {
                    foreach (var dictRow in JsonConvert.DeserializeObject<JObject[]>(data["Data"].ToString()))
                        result.Add(dictRow["Id"].ToObject<Guid>(), dictRow["Name"].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// Созданные объекты недвижимости
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> GetObjectAsJson(Guid objectId = new Guid())
        {
            var url = objectId == Guid.Empty ? "Objects" : $"Objects/{objectId}";
            return await CreateRequest(Method.GET, url);
        }
        /// <summary>
        /// Созданные объекты недвижимости
        /// </summary>
        /// <returns>KeyValuePair Array</returns>
        public async Task<RealtyObject[]> GetObjects(Guid objectId=new Guid())
        {
            var jsonResponse = await this.GetObjectAsJson(objectId);
            {
                var data = JObject.Parse(jsonResponse);
                if ((bool)data["Result"])
                    return JsonConvert.DeserializeObject<RealtyObject[]>(data["Data"].ToString());                    
            }
            return Enumerable.Empty<RealtyObject>().ToArray();
        }
        /// <summary>
        /// Создание/Обновление объекта недвижимости
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> SaveObjectsAsJson(string jsonString)
        {
            return await CreateRequest(Method.POST, "Objects/Save", jsonString);
        }
        /// <summary>
        /// Создание/Обновление объекта недвижимости
        /// </summary>
        /// <returns>bool</returns>
        public async Task<KeyValuePair<bool,string>> SaveObjects(RealtyObject obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var jsonResponse = await SaveObjectsAsJson(jsonString);
            var data = JObject.Parse(jsonResponse);
            return new KeyValuePair<bool, string>((bool) data["Result"], data["Message"].ToString());
        }
        /// <summary>
        /// Удаление объекта недвижимости
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> DeleteObjecstAsJson(Guid objectId)
        {
            return await CreateRequest(Method.DELETE, $"Objects/Delete/{objectId}");
        }
        /// <summary>
        /// Удаление объекта недвижимости
        /// </summary>
        /// <returns>bool</returns>
        public async Task<KeyValuePair<bool, string>> DeleteObjects(Guid objectId)
        {
            var jsonResponse = await DeleteObjecstAsJson(objectId);
            var data = JObject.Parse(jsonResponse);
            return new KeyValuePair<bool, string>((bool)data["Result"], data["Message"].ToString());
        }


        //===== Clients =====//
        /// <summary>
        /// Список допустимых типов клиентов
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> ClientsKindAsJson()
        {
            return await CreateRequest(Method.GET, $"Clients/Kinds");
        }
        /// <summary>
        /// Список допустимых типов клиентов
        /// </summary>
        /// <returns>bool</returns>
        public async Task<Dictionary<int, string>> ClientsKind()
        {
            var result = new Dictionary<int, string>();
            var jsonResponse = await ClientsKindAsJson();
            {
                var data = JObject.Parse(jsonResponse);
                if ((bool)data["Result"])
                {
                    foreach (var dictRow in JsonConvert.DeserializeObject<JObject[]>(data["Data"].ToString()))
                        result.Add(dictRow["Id"].ToObject<int>(), dictRow["Name"].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// Список допустимых типов гос.органов
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> ClientsGovernanceCodesAsJson()
        {
            return await CreateRequest(Method.GET, $"Clients/GovernanceCodes");
        }
        /// <summary>
        /// Список допустимых типов гос.органов
        /// </summary>
        /// <returns>bool</returns>
        public async Task<Dictionary<Guid, string>> ClientsGovernanceCodes()
        {
            var result = new Dictionary<Guid, string>();
            var jsonResponse = await ClientsGovernanceCodesAsJson();
            {
                var data = JObject.Parse(jsonResponse);
                if ((bool)data["Result"])
                {
                    foreach (var dictRow in JsonConvert.DeserializeObject<JObject[]>(data["Data"].ToString()))
                        result.Add(dictRow["Id"].ToObject<Guid>(), dictRow["Name"].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// Список допустимых типов документов
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> ClientsDocumentTypesAsJson()
        {
            return await CreateRequest(Method.GET, $"Clients/DocumentTypes");            
        }
        /// <summary>
        /// Список допустимых типов документов
        /// </summary>
        /// <returns>bool</returns>
        public async Task<Dictionary<Guid, string>> ClientsDocumentTypes()
        {
            var result = new Dictionary<Guid, string>();
            var jsonResponse = await ClientsDocumentTypesAsJson();
            {
                var data = JObject.Parse(jsonResponse);
                if ((bool)data["Result"])
                {
                    foreach (var dictRow in JsonConvert.DeserializeObject<JObject[]>(data["Data"].ToString()))
                        result.Add(dictRow["Id"].ToObject<Guid>(), dictRow["Name"].ToString());
                }
            }
            return result;
        }
        /// <summary>
        /// Список клиентов
        /// </summary>
        /// <param name="clientid">Id клиента. Все клиенты если не указано</param>
        /// <returns></returns>
        public async Task<string> GetClientsAsJson(Guid clientid=new Guid())
        {
            var url = clientid != Guid.Empty ? $"Clients/{clientid}" : $"Clients";
            return await CreateRequest(Method.GET, url);
        }
        /// <summary>
        /// Список клиентов как объекты
        /// </summary>
        /// <returns></returns>
        public async Task<ClientModel[]> GetClients(Guid clientId=new Guid())
        {
            var jsonResponse = await GetClientsAsJson(clientId);

            var data = JObject.Parse(jsonResponse);
            if ((bool)data["Result"])
            {
                return JsonConvert.DeserializeObject<ClientModel[]>(data["Data"].ToString());
            }
            return Enumerable.Empty<ClientModel>().ToArray();
        }
        /// <summary>
        /// Сохранить данные клиента
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<string> SaveClientAsJson(string jsonString)
        {
            return await CreateRequest(Method.POST, "Clients/Save", jsonString);
        }
        /// <summary>
        /// Сохранить данные клиента
        /// </summary>
        /// <param name="clientModel"></param>
        /// <returns></returns>
        public async Task<bool> SaveClient(ClientModel clientModel)
        {
            var jsonString = JObject.FromObject(clientModel).ToString();
            var jsonResponse = await SaveClientAsJson(jsonString);
            var data = JObject.Parse(jsonResponse);
            return (bool)data["Result"];
        }
        /// <summary>
        /// Удаление объекта недвижимости
        /// </summary>
        /// <returns>Json string</returns>
        public async Task<string> DeleteClientsAsJson(Guid clientId)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("Clients/Delete/{id}?api-key={apikey}" + _params, Method.DELETE);
            request.AddUrlSegment("id", clientId.ToString());
            request.AddUrlSegment("apikey", _apikey);
            var cancellationToken = new CancellationToken();
            var response = await client.ExecuteTaskAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            return null;
        }
        /// <summary>
        /// Удаление объекта недвижимости
        /// </summary>
        /// <returns>bool</returns>
        public async Task<KeyValuePair<bool, string>> DeleteClients(Guid objectId)
        {
            var jsonResponse = await DeleteClientsAsJson(objectId);
            var data = JObject.Parse(jsonResponse);
            return new KeyValuePair<bool, string>((bool)data["Result"], data["Message"].ToString());
        }
        /// <summary>
        /// Данные о сертификатах пользователя
        /// </summary>
        /// <param name="clientid">Id клиента</param>
        /// <returns></returns>
        public async Task<string> GetCertificateInfoAsJson(Guid clientid = new Guid())
        {
            var url = $"Clients/Verificate/{clientid}";
            return await CreateRequest(Method.GET, url);
        }
        /// <summary>
        /// Данные о сертификатах пользователя
        /// </summary>
        /// <param name="clientid">Id клиента</param>
        /// <returns></returns>
        public async Task<CertificateInfo[]> GetCertificateInfo(Guid clientid = new Guid())
        {
            var jsonResponse = await GetCertificateInfoAsJson(clientid);
            var data = JObject.Parse(jsonResponse);
            if ((bool)data["Result"])
            {
                return JsonConvert.DeserializeObject<CertificateInfo[]>(data["Data"].ToString());
            }
            return Enumerable.Empty<CertificateInfo>().ToArray();
        }
        /// <summary>
        /// Запрос на выпуск сертификата
        /// </summary>
        /// <param name="userClientId"></param>
        /// <returns></returns>
        public async Task<string> SendCertificateRequestAsJson(Guid userClientId)
        {
            var url = $"Certificates/Request/{userClientId}";
            return await CreateRequest(Method.POST, url);
        }
        /// <summary>
        /// Запрос на выпуск сертификата
        /// </summary>
        /// <param name="userClientId"></param>
        /// <returns></returns>
        public async Task<CertificateInfo> SendCertificateRequest(Guid userClientId)
        {
            var jsonResponse = await SendCertificateRequestAsJson(userClientId);
            var data = JObject.Parse(jsonResponse);
            if ((bool)data["Result"])
                return JsonConvert.DeserializeObject<CertificateInfo>(data["Data"].ToString());
            return null;
        }

        //=== Application ===/
        public async Task<string> SaveRegApplicationAsJson(string jsonString)
        {
            return await CreateRequest(Method.POST, "Registrations/Save", jsonString);
        }
        
        public async Task<KeyValuePair<bool, string>> SaveRegApplication(RegApplicModel regAppModel)
        {
            var jsonString = JObject.FromObject(regAppModel).ToString();
            var jsonResponse = await SaveRegApplicationAsJson(jsonString);
            var data = JObject.Parse(jsonResponse);
            return new KeyValuePair<bool, string>((bool)data["Result"], data["Message"].ToString());
        }
        /// <summary>
        /// Сгенерировать документы-заявления для существующих данных 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public async Task<string> GenerateApplicationAsJson(Guid applicationId)
        {
            return await CreateRequest(Method.POST, $"Registrations/GenerateApplication/{applicationId}");
        }
        /// <summary>
        /// Сгенерировать документы-заявления для существующих данных 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public async Task<KeyValuePair<bool, string>> GenerateApplication(Guid applicationId)
        {
            var jsonResponse = await GenerateApplicationAsJson(applicationId);
            var data = JObject.Parse(jsonResponse);
            return new KeyValuePair<bool, string>((bool)data["Result"], data["Message"].ToString());
        }
    }
}
