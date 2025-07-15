using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels.DemoModule;

namespace Mirrack.Views.DemoModule;

public partial class DemoLOptionView : UserControl
{
    public DemoLOptionView()
    {
        InitializeComponent();
        DataContext = new DemoLOptionViewModel();
    }
}