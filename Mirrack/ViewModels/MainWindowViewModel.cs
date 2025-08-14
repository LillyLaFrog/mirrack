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
using Mirrack.Views;

namespace Mirrack.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {


        public MainWindowViewModel()
        {
            RefreshScreen();
            AuthService.LoginChange += OnLoginChange;
        }

        private readonly ViewModelBase _layout = new LayoutViewModel();
        private readonly ViewModelBase _auth =  new AuthViewModel();
        private ViewModelBase _screen = new LoadingViewModel();
        public ViewModelBase Screen
        {
            get => _screen;
            set
            {
                this.RaiseAndSetIfChanged(ref _screen, value);
                _screen = value;
            }
        }
        
        public void OnLoginChange(bool isLoggedIn)
        {
            if (isLoggedIn)
            {
                Screen = _layout;
            }
            else
            {
                Screen = _auth;
            }
        }
        public async Task RefreshScreen()
        {
            OnLoginChange(await AuthModel.Refresh());
        }

    }

}
