using Mirrack.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mirrack.ViewModels
{
    internal class DemoViewModel : ReactiveObject
    {
        private string _test = "aklsjfdklj";
        public string Test { get { return _test; } set => this.RaiseAndSetIfChanged(ref _test, value); }

        private DemoModel _demoModel = new DemoModel();


        public string Message { get { return _demoModel.message; } set 
            { 
                string _message = _demoModel.message;
                this.RaiseAndSetIfChanged(ref _message, value);
            } 
        }

    }
}
