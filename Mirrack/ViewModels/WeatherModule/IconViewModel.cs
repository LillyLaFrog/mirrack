using Mirrack.Models;
using Mirrack.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;

namespace Mirrack.ViewModels.WeatherModule
{
    internal class IconViewModel : ViewModelBase
    {
        private WeatherData _currentWeather;
        private WeatherData CurrentWeather
        {
            get => _currentWeather;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentWeather, value);
                this.RaisePropertyChanged(nameof(Icon));
                this.RaisePropertyChanged(nameof(Summary));
                this.RaisePropertyChanged(nameof(Temperature));
                this.RaisePropertyChanged(nameof(TemperatureHigh));
                this.RaisePropertyChanged(nameof(TemperatureLow));
                this.RaisePropertyChanged(nameof(PrecipProbability));
                this.RaisePropertyChanged(nameof(WindSpeed));
            }
        }

        //split up currentWeather to bindable properties
        private string TempUnit { get => "° " + ((CurrentWeather.units == "us") ? 'F' : 'C'); }

        public IImage Icon
        {
            get
            {
                var uri = new Uri("avares://Mirrack/Assets/weatherIcons/"+CurrentWeather.icon+".png");
                var stream = AssetLoader.Open(uri);
                return new Bitmap(stream);
            }
        }

        public string Summary { get => CurrentWeather.summary + ""; }
        public string Temperature { get => double.Round(CurrentWeather.temperature).ToString() + TempUnit; }
        public string TemperatureHigh { get => double.Round(CurrentWeather.temperatureMax).ToString() + TempUnit; }
        public string TemperatureLow { get => double.Round(CurrentWeather.temperatureMin).ToString() + TempUnit; }
        public string PrecipProbability { get => (CurrentWeather.precipProbability*100).ToString() + '%'; }
        public string WindSpeed { get => CurrentWeather.windSpeed.ToString() + ' ' + ((CurrentWeather.units == "us" || CurrentWeather.units == "uk") ? "MPH" : (CurrentWeather.units == "ca") ? "KPH" : "MPS"); }

        public IconViewModel()
        {

            //update current weather on the hour
            TimeService.HourChanged += UpdateWeather;
            //init
            UpdateWeather();
        }
        private async void UpdateWeather()
        {
            //dummy data
            //CurrentWeather = new WeatherData("uk","fog","foggy!",64.5,88.2,60.0,.99,14);
            
            //todo: use an actual idToken
            WeatherData? data = await WeatherModel.GetWeather("1234");
            if (data != null)
            {
                CurrentWeather = data;
            }
        }
    }
}
