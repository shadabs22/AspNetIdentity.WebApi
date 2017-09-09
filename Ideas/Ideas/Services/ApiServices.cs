using Ideas.Models;
using Ideas.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ideas.Services
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");        
            var response = await client.PostAsync("http://localhost:5628/api/Account/Register", content);

            return response.IsSuccessStatusCode;

        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var KeyValue = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string,string>("username",username),
                 new KeyValuePair<string,string>("password",password),
                  new KeyValuePair<string,string>("grant_type","password")

            };
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5628/Token");
            request.Content = new FormUrlEncodedContent(KeyValue);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var jwt = await response.Content.ReadAsStringAsync();
            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);
            var accessToken = jwtDynamic.Value<string>("access_token");
            Debug.WriteLine(jwt);
            return accessToken;
        }

        public async Task<List<Idea>> GetIdeasAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",accessToken);
            var json = await client.GetStringAsync("http://localhost:5628/api/ideas");
            var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);
            return ideas;
        }

        public async Task PostIdeasAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://localhost:5628/api/ideas", content);       
        }

        public async Task PutIdeasAsync(Idea idea, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(idea);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync("http://localhost:5628/api/ideas/" + idea.Id, content);
        }


        public async Task DeleteIdeasAsync(int Id, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var response = await client.DeleteAsync("http://localhost:5628/api/ideas/" + Id);
        }

    }
}
