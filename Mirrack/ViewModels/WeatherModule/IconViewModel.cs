using Mirrack.Models;
using Mirrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.ViewModels.WeatherModule
{
    internal class IconViewModel
    {
        public IconViewModel()
        {

            //update current weather on the hour
            TimeService.HourChanged += updateWeather;
            //init
            updateWeather();
        }
        public async void updateWeather()
        {
            await WeatherModel.GetWeather(19,19,"us");
        }
        public WeatherData? WeatherData { get; set; }
    }
}
