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
        public static async Task<WeatherData?> GetWeather()
        {
            //todo switch this to production url :)
            string weatherUri = "https://getweather-i3pl3ppnaa-uc.a.run.app";
            using (HttpClient client = new HttpClient())
            {
                
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var postData = new Dictionary<string, string>
                    {
                        { "idToken", AuthModel.IdToken != null? AuthModel.IdToken : "" },
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
