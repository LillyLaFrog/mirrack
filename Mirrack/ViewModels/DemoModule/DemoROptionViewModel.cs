using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Input;
using Mirrack.Models;
using Mirrack.Services;

namespace Mirrack.ViewModels.DemoModule
{
    internal class DemoROptionViewModel : ViewModelBase
    {
        public DemoROptionViewModel()
        {
            InputService.KeyInput += OnKeyInput;
        }

        private void OnKeyInput(Key key, bool held)
        {
            if (key == Key.Right && held)
            {
                AuthModel.Logout();
            }
        }
    }
}
