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
            this.PointerWheelChanged += OnPointerWheel;
            this.KeyDown += OnKeyDown;
            this.KeyUp += OnKeyUp;
            DataContext = new MainWindowViewModel();
        }
        

        private void OnPointerWheel(object? sender, PointerWheelEventArgs args)
        {
            InputService.RaiseScroll(args.Delta);
            args.Handled = true;
        }

        //mark time to check how long btn press was when released
        private bool _keyDown = false;
        private DateTime timePressed;
        private void OnKeyDown(object? sender, KeyEventArgs args)
        {
            if (!_keyDown)
            {
                timePressed = DateTime.Now;
                _keyDown = true;
            }
            //let key presses bubble past this for keyboard input :)
            args.Handled = false;
        }

        //use keyDown time to check if button was pressed or held
        private void OnKeyUp(object? sender, KeyEventArgs args) 
        {
            int holdDelay = 500;
            _keyDown = false;
            //if held for longer than hold delay
            if (DateTime.Now - timePressed > TimeSpan.FromMilliseconds(holdDelay))
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