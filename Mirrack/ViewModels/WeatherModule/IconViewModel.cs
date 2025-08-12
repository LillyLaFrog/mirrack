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
        private string TempUnit { get => "° " + ((CurrentWeather.Units == "us") ? 'F' : 'C'); }

        public IImage Icon
        {
            get
            {
                var uri = new Uri("avares://Mirrack/Assets/weatherIcons/"+CurrentWeather.Icon+".png");
                var stream = AssetLoader.Open(uri);
                return new Bitmap(stream);
            }
        }

        public string Summary { get => CurrentWeather.Summary + ""; }
        public string Temperature { get => double.Round(CurrentWeather.Temperature).ToString() + TempUnit; }
        public string TemperatureHigh { get => double.Round(CurrentWeather.TemperatureHigh).ToString() + TempUnit; }
        public string TemperatureLow { get => double.Round(CurrentWeather.TemperatureLow).ToString() + TempUnit; }
        public string PrecipProbability { get => (CurrentWeather.PrecipProbability*100).ToString() + '%'; }
        public string WindSpeed { get => CurrentWeather.WindSpeed.ToString() + ' ' + ((CurrentWeather.Units == "us" || CurrentWeather.Units == "uk") ? "MPH" : (CurrentWeather.Units == "ca") ? "KPH" : "MPS"); }

        public IconViewModel()
        {

            //update current weather on the hour
            TimeService.SecondChanged += UpdateWeather;
            //init
            CurrentWeather = new WeatherData();
        }
        private async void UpdateWeather()
        {
            //todo: use an actual request instead of making a new weatherData
            CurrentWeather = new WeatherData("uk","fog","foggy!",64.5,88.2,60.0,.99,14); //await WeatherModel.GetWeather(19,19,"us");
        }
    }
}
