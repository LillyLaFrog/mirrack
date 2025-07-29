using Avalonia;
using Avalonia.Controls.Primitives;

namespace Mirrack.Controls;

public class LOption : TemplatedControl
{
    public static readonly AvaloniaProperty<string?> PrimaryOptionProperty =
        AvaloniaProperty.Register<LOption, string?>(nameof(PrimaryOption));
    public string? PrimaryOption
    {
        get { return (string?)GetValue(PrimaryOptionProperty); }
        set { SetValue(PrimaryOptionProperty, value); }
    }
    public static readonly AvaloniaProperty<string?> SecondaryOptionProperty =
        AvaloniaProperty.Register<LOption, string?>(nameof(SecondaryOption));
    public string? SecondaryOption
    {
        get { return (string?)GetValue(SecondaryOptionProperty); }
        set { SetValue(SecondaryOptionProperty, value); }
    }
}