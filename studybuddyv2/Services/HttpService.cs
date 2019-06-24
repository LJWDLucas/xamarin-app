using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using studybuddyv2.Models;

namespace studybuddyv2.Services
{
    static class HttpService
    {
        private static WebClient client = new WebClient();
        private static string JWT { get; set; }

        private static JsonSerializerSettings GetJsonSerializerSettings ()
        {
            var sSettings = new JsonSerializerSettings();
            sSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return sSettings;
        }

        private static Uri GetUri(string address)
        {
            return new Uri(string.Format(address));
        }

        public static async Task<bool> RegisterUser(string email, string password)
        {
            var body = JsonConvert.SerializeObject(new TempUser(email, password), GetJsonSerializerSettings());

            try
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string response = await client.UploadStringTaskAsync(GetUri(Constants.BaseAddress + Constants.RegisterPath), "POST", body);

            } catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> LoginUser(string email, string password)
        {
            var body = JsonConvert.SerializeObject(new TempUser(email, password), GetJsonSerializerSettings());

            try
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string response = await client.UploadStringTaskAsync(GetUri(Constants.BaseAddress + Constants.LoginPath), "POST", body);
                LoginUser loginUser = JsonConvert.DeserializeObject<LoginUser>(response);
                JWT = loginUser.Token;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }

    public class TempUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public TempUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class LoginUser
    {
        public bool Success { get; set; }
        public string Token { get; set; } 
    }
}
