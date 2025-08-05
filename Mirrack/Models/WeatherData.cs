using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.Models
{
    public class WeatherData
    {
        public WeatherData()
        {
            //create default weatherData
            units = "us";
            icon = "cloudy";
            summary = "Overcast";
            temperature = 70.13;
            temperatureHigh = 75.23;
            temperatureLow = 65.72;
            precipProbability = 0.25;
            windSpeed = 7.2;
        }
        public string? units { get; set; }
        public string? icon { get; set; }
        public string? summary { get; set; }
        public double temperature { get; set; }
        public double temperatureHigh { get; set; }
        public double temperatureLow { get; set; }
        public double precipProbability { get; set; }
        public double windSpeed { get; set; }
    }
}
