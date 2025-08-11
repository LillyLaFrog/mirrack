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
            Units = "us";
            Icon = "cloudy";
            Summary = "Overcast";
            Temperature = 70.13;
            TemperatureHigh = 75.23;
            TemperatureLow = 65.72;
            PrecipProbability = 0.25;
            WindSpeed = 7.2;
        }
        public string? Units { get; set; }
        public string? Icon { get; set; }
        public string? Summary { get; set; }
        public double Temperature { get; set; }
        public double TemperatureHigh { get; set; }
        public double TemperatureLow { get; set; }
        public double PrecipProbability { get; set; }
        public double WindSpeed { get; set; }
    }
}
