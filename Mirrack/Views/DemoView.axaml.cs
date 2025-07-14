using Avalonia.Controls;
using Avalonia.Input;
using Mirrack.ViewModels;

namespace Mirrack;

public partial class DemoView : UserControl
{
    public DemoView()
    {
        
        InitializeComponent();
        DataContext = new DemoViewModel();
        this.PointerWheelChanged += OnPointerWheelChanged;
    }

    private void OnPointerWheelChanged(object? sender, PointerWheelEventArgs args)
    {
        if (DataContext is DemoViewModel vm) 
        {
            vm.HandleScroll(args.Delta);
        }
        //args.Handled = true;
    }
}