using Mirrack.Models;
using Mirrack.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Input;
using Avalonia;

namespace Mirrack.ViewModels
{
    internal class ModuleBtnComponent
    {
        public ModuleBtnComponent()
        {
            InputService.ScrollInput += HandleScroll;
            InputService.KeyInput += HandleKey;
        }


        public void HandleKey(Key key, bool held)
        {

        }

        public void HandleScroll(Vector rotation)
        {

        }
    }
}
