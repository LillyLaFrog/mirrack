using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
