using AIWM.Model;
using AIWM.Web.Controller;
using AIWM.Web.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AIWM.Web.Connection
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> FindUserByName(string login)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, UriHelper.BaseUrl + "api/user/name/"+login);
            User user = null;
            using (var response = await _httpClient.SendAsync(httpRequestMessage))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(content);
            }

            System.Diagnostics.Debug.WriteLine("login string");
            return user;
        }

        public async Task<bool> Login(User user)
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,  UriHelper.BaseUrl + "api/user/login");
            httpRequestMessage.Headers.Add("Accept", "application/json");
            var httpContent = new System.Net.Http.StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            httpRequestMessage.Content = httpContent;

            string result = "false";
            using (var response = await _httpClient.SendAsync(httpRequestMessage))
            {
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsStringAsync();
            }

            System.Diagnostics.Debug.WriteLine("login user");
            return Convert.ToBoolean(result);
        }
    }









    /* var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "api/user/id/5");
     httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(loginParameters));
     httpRequestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

               using (var response = await _httpClient.SendAsync(httpRequestMessage))
               {
                   response.EnsureSuccessStatusCode();
             var content = await response.Content.ReadAsStringAsync();
     resp = JsonConvert.DeserializeObject<ApiResponseDto>(content);
         }

             return resp;*/
}
