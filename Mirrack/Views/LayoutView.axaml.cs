using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels;

namespace Mirrack.Views;

public partial class LayoutView : UserControl
{
    public LayoutView()
    {
        InitializeComponent();
        DataContext = new LayoutViewModel();
    }
}