using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AcessoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:51224/";

            // autentica usuario
            Token loginToken = null;
            using (var client = new HttpClient())
            {
                JObject obj = new JObject();
                obj.Add("Login", "cds");
                obj.Add("Senha", "123");

                var loginPost = client.PostAsync(url + "api/login", new StringContent(obj.ToString(), Encoding.UTF8, "application/json")).Result;
                loginToken = JsonConvert.DeserializeObject<Token>(loginPost.Content.ReadAsStringAsync().Result);
            }

            // acessa API
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginToken.accessToken);

                var post = client.PostAsync(url + "api/cliente",new StringContent("")).Result;
                var dados = post.Content.ReadAsStringAsync().Result;
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(dados);
            }
        }
    }
}
