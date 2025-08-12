using Avalonia;
using Avalonia.Controls.Primitives;
using Mirrack.Models;
using System;
using System.Reactive;
using System.Xml;
using Avalonia.Media;

namespace Mirrack.Controls;

public class WeatherWidget : TemplatedControl
{

    //displayed datapoints
    public static readonly StyledProperty<IImage> IconProperty =
        AvaloniaProperty.Register<WeatherWidget, IImage>(nameof(Icon));
    public static readonly StyledProperty<string> SummaryProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(Summary));
    public static readonly StyledProperty<string> TemperatureProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(Temperature));
    public static readonly StyledProperty<string> TemperatureHighProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(TemperatureHigh));
    public static readonly StyledProperty<string> TemperatureLowProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(TemperatureLow));
    public static readonly StyledProperty<string> PrecipProbabilityProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(PrecipProbability));
    public static readonly StyledProperty<string> WindSpeedProperty =
        AvaloniaProperty.Register<WeatherWidget, string>(nameof(WindSpeed));

    public IImage Icon { get => GetValue(IconProperty); set => SetValue(IconProperty, value); }
    public string Summary { get => GetValue(SummaryProperty); set => SetValue(SummaryProperty, value); }
    public string Temperature { get => GetValue(TemperatureProperty); set => SetValue(TemperatureProperty, value); }
    public string TemperatureHigh { get => GetValue(TemperatureHighProperty); set => SetValue(TemperatureHighProperty,value); }
    public string TemperatureLow { get => GetValue(TemperatureLowProperty); set => SetValue(TemperatureLowProperty, value); }
    public string PrecipProbability { get => GetValue(PrecipProbabilityProperty); set => SetValue(PrecipProbabilityProperty, value); }
    public string WindSpeed { get => GetValue(WindSpeedProperty); set => SetValue(WindSpeedProperty, value); }
}