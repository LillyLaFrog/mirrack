using Avalonia;
using Avalonia.Controls;
using Mirrack.ViewModels.DemoModule;
using Avalonia.Markup.Xaml;

namespace Mirrack.Views.DemoModule;

public partial class DemoScrollView : UserControl
{
    public DemoScrollView()
    {
        InitializeComponent();
        DataContext = new DemoScrollViewModel();
    }
}