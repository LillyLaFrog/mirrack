using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.Models
{
    public class WeatherData
    {
        public WeatherData(string units, string icon, string summary, double temperature, double temperatureMax, double temperatureMin, double precipProbability, double windSpeed)
        {
            //create hardcoded weatherData with icon for testing
            this.units = units;
            this.icon = icon;
            this.summary = summary;
            this.temperature = temperature;
            this.temperatureMax = temperatureMax;
            this.temperatureMin = temperatureMin;
            this.precipProbability = precipProbability;
            this.windSpeed = windSpeed;
        }
        public string? units { get; set; }
        public string? icon { get; set; }
        public string? summary { get; set; }
        public double temperature { get; set; }
        public double temperatureMax { get; set; }
        public double temperatureMin { get; set; }
        public double precipProbability { get; set; }
        public double windSpeed { get; set; }
    }
}
