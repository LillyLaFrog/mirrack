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

namespace Mirrack.ViewModels;

public class LayoutViewModel : ViewModelBase
{
    //create lists and viewmodels for the 5 parts of the screen
    private List<ViewModelBase> icons = [];
    private ViewModelBase? _iconVM;
    private List<ViewModelBase> scrolls = [];
    private ViewModelBase? _scrollVM;
    private List<ViewModelBase> contents = [];
    private ViewModelBase? _contentVM;
    private List<ViewModelBase> lOptions = [];
    private ViewModelBase? _lOptionVM;
    private List<ViewModelBase> rOptions = [];
    private ViewModelBase? _rOptionVM;
    
    //keep track of what screen is focused
    private int _screenIndex = 0;
    
    private string _time = "";
    private string _date = "";
    
    public ViewModelBase? IconVM
    {
        get => _iconVM; set
        {
            this.RaiseAndSetIfChanged(ref _iconVM, value);
            _iconVM = value;
        }
    }
    public ViewModelBase? ScrollVM
    {
        get => _scrollVM; set
        {
            this.RaiseAndSetIfChanged(ref _scrollVM, value);
            _scrollVM = value;
        }
    }
    public ViewModelBase? ContentVM
    {
        get => _contentVM; set
        {
            this.RaiseAndSetIfChanged(ref _contentVM, value);
            _contentVM = value;
        }
    }
    public ViewModelBase? LOptionVM
    {
        get => _lOptionVM; set
        {
            this.RaiseAndSetIfChanged(ref _lOptionVM, value);
            _lOptionVM = value;
        }
    }
    public ViewModelBase? ROptionVM
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

    public LayoutViewModel()
    {
        //update time every minute
        TimeService.MinChanged += updateTime;
        //update date every day
        TimeService.DayChanged += updateDate;
        //initial date/time fetch
        updateTime();
        updateDate();
        
        //a model definition has functions to create the 5 portions of the screen
        List<IModuleDefinition> modules =
        [
            new DemoModule.DemoDefinition(),
            new WeatherModule.Definition(),
        ];
        foreach(IModuleDefinition module in modules)
        {
            //create the 5 portions of the screen and add them to their respective list
            icons.Add(module.CreateIconVM());
            scrolls.Add(module.CreateScrollVM());
            contents.Add(module.CreateContentVM());
            lOptions.Add(module.CreateLOptionVM());
            rOptions.Add(module.CreateROptionVM());
        }
        //set UI bound variables to the first screen in the list
        setScreen(0);
        InputService.KeyInput += OnButtonPressed;
    }
    
    private void OnButtonPressed(Avalonia.Input.Key key, bool held)
    {
        if (key == Avalonia.Input.Key.Up && !held)
        {
            SwitchScreens();
        }
    }

    public void SwitchScreens()
    {
        //switch screen
        _screenIndex++;
        //overflow to beginning
        if(_screenIndex >= icons.Count) { _screenIndex = 0; }
        //set each part of the screen to the appropriate index
        setScreen(_screenIndex);
        Debug.WriteLine(_screenIndex);
    }
    
    private void setScreen(int index)
    {
        IconVM = icons[index];
        ScrollVM = scrolls[index];
        ContentVM = contents[index];
        LOptionVM = lOptions[index];
        ROptionVM = rOptions[index];
    }
    
    private void updateTime() => Time = DateTime.Now.ToString("t");
    private void updateDate() => Date = DateTime.Now.ToString("D");
    
    
}