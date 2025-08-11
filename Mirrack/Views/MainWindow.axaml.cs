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
            //listen to input on main window, pass it along to anything using the input service
            this.PointerWheelChanged += onPointerWheel;
            this.KeyDown += onKeyDown;
            this.KeyUp += onKeyUp;
        }

        public void onPointerWheel(object? sender, PointerWheelEventArgs args)
        {
            InputService.RaiseScroll(args.Delta);
            args.Handled = true;
        }

        //mark time to check how long btn press was when released
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

        //use keyDown time to check if button was pressed or held
        public void onKeyUp(object? sender, KeyEventArgs args) 
        {
            int HoldDelay = 500;
            _keyDown = false;
            //if held for longer than hold delay
            if (DateTime.Now - timePressed > TimeSpan.FromMilliseconds(HoldDelay))
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