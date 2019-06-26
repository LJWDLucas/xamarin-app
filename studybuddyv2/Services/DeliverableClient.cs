using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using studybuddyv2.Models;

namespace studybuddyv2.Services
{
    static class DeliverableClient
    {
        public static async Task<bool> CreateDeliverable(Deliverable deliverable)
        {
            var body = JsonConvert.SerializeObject(deliverable, HttpService.GetJsonSerializerSettings());
            var result = false;
            try
            {
                var client = HttpService.GetWebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Authorization] = HttpService.GetJWT();
                string response = await client.UploadStringTaskAsync(HttpService.GetUri(Constants.BaseAddress + Constants.ApiVersion + Constants.CreateDeliverablePath), "POST", body);
            }
            catch (Exception e)
            {
                return result;
            }
            result = true;
            return result;
        }
    }
}
