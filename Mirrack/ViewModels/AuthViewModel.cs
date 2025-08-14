using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Mirrack.Models;
using ReactiveUI;

namespace Mirrack.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private string _email = string.Empty;
    private string _password = string.Empty;
    public string Email
    {
        get => _email;
        set
        {
            this.RaiseAndSetIfChanged(ref _email, value);
            _email = value;
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            this.RaiseAndSetIfChanged(ref _password, value);
            _password = value;
        }
    }

    public async Task LoginBtn()
    {
       bool result = await AuthModel.Login(Email, Password);
    }
    
    public AuthViewModel()
    {

    }
}