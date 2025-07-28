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
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Mirrack.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private int screenIndex = 0;
        private List<ViewModelBase> icons;
        private ViewModelBase _iconVM;
        private List<ViewModelBase> scrolls;
        private ViewModelBase _scrollVM;
        private List<ViewModelBase> contents;
        private ViewModelBase _contentVM;
        private List<ViewModelBase> lOptions;
        private ViewModelBase _lOptionVM;
        private List<ViewModelBase> rOptions;
        private ViewModelBase _rOptionVM;

        public MainWindowViewModel()
        {
            InputService.KeyInput += OnButtonPressed;
             icons =
                [
                new DemoModule.DemoIconViewModel(),
                ];
            _iconVM = icons[0];
            scrolls = 
                [
                new DemoModule.DemoScrollViewModel(),
                ];
            _scrollVM = scrolls[0];
            contents = 
                [
                new DemoModule.DemoContentViewModel(),
                ];
            _contentVM = contents[0];
            lOptions = 
                [
                new DemoModule.DemoLOptionViewModel(),
                ];
            _lOptionVM = lOptions[0];
            rOptions =
                [
                new DemoModule.DemoROptionViewModel(),
                ];
            _rOptionVM = rOptions[0];
            new Task(keepTime).Start();
        }

        private void OnButtonPressed(Avalonia.Input.Key key, bool held)
        {
            if (key == Avalonia.Input.Key.Up && !held)
            {
                //switch screen
                screenIndex++;
                if(screenIndex >= icons.Count) { screenIndex = 0; }
                IconVM = icons[screenIndex];
                ScrollVM = scrolls[screenIndex];
                ContentVM = contents[screenIndex];
                LOptionVM = lOptions[screenIndex];
                ROptionVM = rOptions[screenIndex];
            }
        }
        private string _time = "";
        private string _date = "";
        private string getTime() => DateTime.Now.ToString("t");
        private string getDate() => DateTime.Now.ToString("D");
        private async void keepTime()
        {
            while (true)
            {
                await Dispatcher.UIThread.InvokeAsync(() => { Time = getTime(); Date = getDate(); });
                await (Task.Delay(1000));
            }
        }
        
        
        public ViewModelBase IconVM
        {
            get => _iconVM; set
            {
                this.RaiseAndSetIfChanged(ref _iconVM, value);
                _iconVM = value;
            }
        }
        public ViewModelBase ScrollVM
        {
            get => _scrollVM; set
            {
                this.RaiseAndSetIfChanged(ref _scrollVM, value);
                _scrollVM = value;
            }
        }
        public ViewModelBase ContentVM
        {
            get => _contentVM; set
            {
                this.RaiseAndSetIfChanged(ref _contentVM, value);
                _contentVM = value;
            }
        }
        public ViewModelBase LOptionVM
        {
            get => _lOptionVM; set
            {
                this.RaiseAndSetIfChanged(ref _lOptionVM, value);
                _lOptionVM = value;
            }
        }
        public ViewModelBase ROptionVM
        {
            get => _rOptionVM; set
            {
                this.RaiseAndSetIfChanged(ref _rOptionVM, value);
                _rOptionVM = value;
            }
        }
        public string Time
        {
            get => _time;
            set
            {
                this.RaiseAndSetIfChanged(ref _time, value);
                _time = value;
            }
        }
        public string Date
        {
            get => _date;
            set
            {
                this.RaiseAndSetIfChanged(ref _date, value);
                _date = value;
            }
        }
    }

}
