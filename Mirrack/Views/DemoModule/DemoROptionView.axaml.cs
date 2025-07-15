using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels.DemoModule;

namespace Mirrack.Views.DemoModule;

public partial class DemoROptionView : UserControl
{
    public DemoROptionView()
    {
        InitializeComponent();
        DataContext = new DemoROptionViewModel();
    }
}