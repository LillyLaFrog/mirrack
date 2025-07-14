using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Mirrack.Services;
using Mirrack.ViewModels;
using System;
using System.Diagnostics;

namespace Mirrack.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PointerWheelChanged += onPointerWheel;
            this.KeyDown += onKeyDown;
            this.KeyUp += onKeyUp;
        }

        public void onPointerWheel(object? sender, PointerWheelEventArgs args)
        {
            InputService.RaiseScroll(args.Delta);
            args.Handled = true;
        }

        private bool _keyDown = false;
        private DateTime timePressed;
        public void onKeyDown(object? sender, KeyEventArgs args)
        {
            if (!_keyDown)
            {
                timePressed = DateTime.Now;
                _keyDown = true;
            }
                args.Handled = true;
        }

        public void onKeyUp(object? sender, KeyEventArgs args) 
        {
            int HoldDelay = 500;
            _keyDown = false;
            //if held for longer than hold delay
            if (DateTime.Now - timePressed > new TimeSpan(0,0,0,0,HoldDelay))
            {
                //key held
                InputService.RaiseKey(args.Key, true);
            } else {
                //key pressed
                InputService.RaiseKey(args.Key, false);
            }
        }
    }
}