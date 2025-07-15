using Mirrack.Models;
using ReactiveUI;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia;
using System.Diagnostics;
using Mirrack.Services;

namespace Mirrack.ViewModels
{
    internal class DemoViewModel : ReactiveObject
    {
        public DemoViewModel() ////TODO -- Create an interface for this
        {
            InputService.ScrollInput += HandleScroll;
            InputService.KeyInput += HandleKey;
        }
        private string _test = "aklsjfdklj";
        public string Test { get { return _test; } set => this.RaiseAndSetIfChanged(ref _test, value); }

        private DemoModel _demoModel = new DemoModel();

        int _message = 1;
        public int Message { get { return _message; } set 
            { 
                this.RaiseAndSetIfChanged(ref _message, value);
            } 
        }

        public void HandleKey(Key key, bool held) 
        {
            if (key == Key.Up && !held) 
            {
                Debug.WriteLine("yahahaha you clicked me!");
            }
        }

        public void HandleScroll (Vector rotation)
        {
            Message += (int)rotation.Y;
            Debug.WriteLine(rotation.ToString());
        }
    }
}
