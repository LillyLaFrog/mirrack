using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mirrack.ViewModels;

namespace Mirrack.Views;

public partial class AuthView : UserControl
{
    public AuthView()
    {
        InitializeComponent();
        DataContext = new AuthViewModel();
    }
}