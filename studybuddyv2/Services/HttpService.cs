using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using studybuddyv2.Models;

namespace studybuddyv2.Services
{
    public class Http
    {
        static HttpClient client = new HttpClient();


        static async Task<User> RegisterUser(User user)
        {
            var uri = new Uri (string.Format (Constants.BaseAddress, Constants.RegisterPath));
            var body = JsonConvert.SerializeObject(user);
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);
            return null;
        }
    }
}
