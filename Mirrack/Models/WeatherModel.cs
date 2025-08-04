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
    public class WeatherData
    {
        public string? units { get; set; }
        public string? icon { get; set; }
        public string? summary { get; set; }
        public double temperature { get; set; }
        public double precipProbability { get; set; }
        public double windSpeed { get; set; }
    }
    internal class WeatherModel
    {
        public async static Task<WeatherData?> GetWeather(double lat, double lng, string units)
        {
            string weatherUri = $"https://api.pirateweather.net/forecast/[apikey]/{lat},{lng}&units={units}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(weatherUri);
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
