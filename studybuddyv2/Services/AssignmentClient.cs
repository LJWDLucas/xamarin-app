using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using studybuddyv2.Models;

namespace studybuddyv2.Services
{
    static class AssignmentClient
    {

        public static async Task<bool> CreateAssignment(Assignment assignment)
        {
            var body = JsonConvert.SerializeObject(assignment, HttpService.GetJsonSerializerSettings());
            var result = false;
            try
            {
                var client = HttpService.GetWebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Authorization] = HttpService.GetJWT();
                string response = await client.UploadStringTaskAsync(HttpService.GetUri(Constants.BaseAddress + Constants.ApiVersion + Constants.CreateAssignmentPath), "POST", body);
                
            }
            catch (Exception e)
            {
                return result;
            }

            return result;
        }
    }
}
