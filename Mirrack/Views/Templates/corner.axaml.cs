using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace Mirrack.Views.Templates;

public partial class Corner : TemplatedControl
{
    public static readonly StyledProperty<string?> SideProperty =
        AvaloniaProperty.Register<Corner, string?>(nameof(Side), defaultValue: "huh");
    public string? Side
    {
        get => GetValue(SideProperty);
        set => SetValue(SideProperty, value);
    }
    public Corner()
    {
        InitializeComponent();
    }
}