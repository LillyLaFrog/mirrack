using Mirrack.Models;
using Mirrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.ViewModels.WeatherModule
{
    internal class IconViewModel : ViewModelBase
    {
        public WeatherData currentWeather { get; set; } = new WeatherData();

        //split up currentWeather to bindable properties
        private string TempUnit { get => "° " + ((currentWeather.Units == "us") ? 'F' : 'C'); }
        public string Icon { get => currentWeather.Icon; }
        public string Summary { get => currentWeather.Summary; }
        public string Temperature { get => double.Round(currentWeather.Temperature).ToString() + TempUnit; }
        public string TemperatureHigh { get => double.Round(currentWeather.TemperatureHigh).ToString() + TempUnit; }
        public string TemperatureLow { get => double.Round(currentWeather.TemperatureLow).ToString() + TempUnit; }
        public string PrecipProbability { get => (currentWeather.PrecipProbability*100).ToString() + '%'; }
        public string WindSpeed { get => currentWeather.WindSpeed.ToString() + ' ' + ((currentWeather.Units == "us" || currentWeather.Units == "uk") ? "MPH" : (currentWeather.Units == "ca") ? "KPH" : "MPS"); }

        public IconViewModel()
        {

            //update current weather on the hour
            TimeService.HourChanged += UpdateWeather;
            //init
            UpdateWeather();
        }
        public async void UpdateWeather()
        {
            currentWeather = new WeatherData(); //await WeatherModel.GetWeather(19,19,"us");
        }
    }
}
