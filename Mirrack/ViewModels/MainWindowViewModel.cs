using Avalonia.Threading;
using DynamicData.Binding;
using Mirrack.Models;
using Mirrack.Services;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Mirrack.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {


        public MainWindowViewModel()
        {
        }

        private readonly ViewModelBase _layout = new LayoutViewModel();
        private readonly ViewModelBase _login =  new LayoutViewModel();
        //todo: make this use app-wide state (maybe make a file or something) 
        private bool _loggedIn = false;
        public ViewModelBase Screen
        {
            get
            {
                if (_loggedIn)
                {
                    return _layout;
                }
                else
                {
                    return _login;
                }
            }
        }

    }

}
