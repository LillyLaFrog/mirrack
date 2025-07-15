using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels.DemoModule;

namespace Mirrack.Views.DemoModule;

public partial class DemoContentView : UserControl
{
    public DemoContentView()
    {
        InitializeComponent();
        DataContext = new DemoContentViewModel();
    }
}