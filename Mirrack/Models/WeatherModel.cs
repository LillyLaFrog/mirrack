using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reactive;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mirrack.Models
{
    internal class WeatherModel
    {
        public static async Task<WeatherData?> GetWeather(string idToken)
        {
            //todo switch this to production url :)
            string weatherUri = "http://127.0.0.1:5001/mirrack-ecb5a/us-central1/getWeather";
            using (HttpClient client = new HttpClient())
            {
                
                try
                {
                    var postData = new Dictionary<string, string>
                    {
                        { "idToken", "1234" },
                        { "weekly", "false" }
                    };
                    var postContent = new FormUrlEncodedContent(postData);
                    HttpResponseMessage response = await client.PostAsync((string)weatherUri, postContent);
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    WeatherData? data = JsonSerializer.Deserialize<WeatherData>(content);
                    if (data == null) throw new Exception();
                    return data;
                }
                catch
                {
                    return null;
                }
            }

        }
    }
}
