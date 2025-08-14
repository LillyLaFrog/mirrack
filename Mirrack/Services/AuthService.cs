using System;

namespace Mirrack.Services;

public class AuthService
{
    public static event Action<bool>? LoginChange;

    public static void RaiseLoginChange(bool isLoggedIn) => LoginChange?.Invoke(isLoggedIn);
}