using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels.WeatherModule;

namespace Mirrack.Views.WeatherModule;

public partial class IconView : UserControl
{
    public IconView()
    {
        InitializeComponent();
        DataContext = new IconViewModel();
    }
}