using System;

namespace Mirrack.Services;

public class AuthService
{
    public static event Action<bool>? LoginChange;
    public static event Action? Authenticated;
    public static void RaiseLoginChange(bool isLoggedIn) { 
        LoginChange?.Invoke(isLoggedIn);
        if (isLoggedIn) 
            { RaiseAuthenticated(); }
    }
    public static void RaiseAuthenticated() => Authenticated?.Invoke();

}