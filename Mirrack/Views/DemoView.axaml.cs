using Avalonia.Controls;
using Mirrack.ViewModels;

namespace Mirrack;

public partial class DemoView : UserControl
{
    public DemoView()
    {
        InitializeComponent();
        DataContext = new DemoViewModel();
    }
}