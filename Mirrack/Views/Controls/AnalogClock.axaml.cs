using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;
using Mirrack.Controls;

namespace Mirrack.Controls;

public class AnalogClock : TemplatedControl
{
    public static readonly AvaloniaProperty<TimeOnly> TimeProperty =
        AvaloniaProperty.Register<AnalogClock, TimeOnly>(nameof(Time), new TimeOnly(12,00));
    //private TimeOnly _time = new(6,30);
    public TimeOnly Time
    {
        get => (TimeOnly)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }
    
    
    private RotateTransform? _hourRotate; 
    private RotateTransform? _minuteRotate;
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        Border? hourHand = (Border?)e.NameScope.Find("PART_HourHand");
        Border? minuteRotate = (Border?)e.NameScope.Find("PART_MinuteHand");
        _hourRotate = hourHand?.RenderTransform as RotateTransform;
        _minuteRotate = minuteRotate?.RenderTransform as RotateTransform;

        UpdateHands();
    }

    private void UpdateHands()
    {

        double hourAngle = (Time.Hour + ((double)Time.Minute / 60)) * 30;
        int minuteAngle = Time.Minute * 6;


        if (_hourRotate != null)
            _hourRotate.Angle = hourAngle;

        if (_minuteRotate != null)
            _minuteRotate.Angle = minuteAngle;
    }
}