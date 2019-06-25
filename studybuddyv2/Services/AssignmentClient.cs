using System;
using System.Collections.Generic;
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
            result = true;
            return result;
        }

        public static async Task<List<Assignment>> GetAssignmentsAsync()
        {
            List<Assignment> list;
            try
            {
                var client = HttpService.GetWebClient();
                client.Headers[HttpRequestHeader.Authorization] = HttpService.GetJWT();
                string response = await client.DownloadStringTaskAsync(HttpService.GetUri(Constants.BaseAddress + Constants.ApiVersion + Constants.AssignmentsPath + "/createdBy/" + App.CurrentUser));
                var result = JsonConvert.DeserializeObject<GetAssignmentsResponse>(response);
                list = result.Payload;
            } catch
            {
                list = new List<Assignment>();
            }
            return list;
        }
    }

    public class GetAssignmentsResponse 
    {
        public bool Success { get; set; }
        public List<Assignment> Payload { get; set; }
    }
}
