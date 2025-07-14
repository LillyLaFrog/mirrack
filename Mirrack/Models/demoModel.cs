using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.Models
{
    internal class DemoModel
    {
        public DemoModel()
        {

        }

        private bool _buttonState1 = false;
        private bool _buttonState2 = false;
        private bool _buttonState3 = false;
        private int _scrollLocation = 0;
        public bool button1State { get => _buttonState1; set => _buttonState1 = value; }
        public bool button2State { get => _buttonState2; set => _buttonState2 = value; }
        public bool button3State { get => _buttonState3; set => _buttonState3 = value; }
        public int scrollLocation { get => _scrollLocation; set => _scrollLocation = value; }


        string _message = "Hello World";
        public string message { get => _message; set => _message = value; }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            
        }

        
        
    }
}
