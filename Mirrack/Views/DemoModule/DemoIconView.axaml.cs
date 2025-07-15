using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels.DemoModule;

namespace Mirrack.Views.DemoModule;

public partial class DemoIconView : UserControl
{
    public DemoIconView()
    {
        InitializeComponent();
        DataContext = new DemoIconViewModel();
    }
}