using Avalonia.Controls;
using Mirrack.Services;
using Mirrack.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    internal static class WeatherModel
    {
        public static event Action? CurrentChanged;
        private static WeatherData _current = new WeatherData("us", "loading", "Loading", 0, 0, 0, 0, 0); //loading data
        public static WeatherData Current {
            get => _current;
            private set {
                //set and Invoke CurrentChanged if value changed
                if (_current != value)
                {
                    _current = value;
                    CurrentChanged?.Invoke();
                }
            }
        }
        static WeatherModel()
        {
            //Update current weather on the hour
            TimeService.HourChanged += UpdateCurrent;
            //Update current weather on app auth
            AuthService.Authenticated += UpdateCurrent;
        }

        public static async void UpdateCurrent()
        {
            WeatherData? data = await GetWeather();
            Current = (data == null) ? new WeatherData("us", "error", "Could not load weather", 0, 0, 0, 0, 0) : data;
        }
        private static async Task<WeatherData?> GetWeather(string weekly = "false")
        {
            //todo switch this to production url :)
            string weatherUri = "https://getweather-i3pl3ppnaa-uc.a.run.app";
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //throw error if logged out
                    if (AuthModel.IdToken == null)
                    {
                        throw new Exception("not logged in");
                    }
                    var postData = new Dictionary<string, string>
                    {
                        { "idToken", AuthModel.IdToken},
                        { "weekly", weekly }
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
