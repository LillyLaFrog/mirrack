using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using dotenv.net;
using Mirrack.Services;

namespace Mirrack.Models;


public static class AuthModel
{
    public static string? IdToken { get; set; }
    public static string? Uid { get; set; }

    private static string RefreshPath {
        get
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, "MyAvaloniaApp", "refresh_token");
        }
    }
    
    //writes property to file
    private static string? RefreshToken
    {
        get => File.Exists(RefreshPath) ? File.ReadAllText(RefreshPath) : null;
        set
        {
            Directory.CreateDirectory(Path.GetDirectoryName(RefreshPath));
            File.WriteAllText(RefreshPath, value);
        }
    }

    public static bool Logout()
    {
        if (File.Exists(RefreshPath))
        {
            File.Delete(RefreshPath);
            IdToken = null;
            Uid = null;
            //invoke login changed event
            AuthService.RaiseLoginChange(false);
            return true;
        }

        return false;
    }
    public static Task<bool> SignUp(string email, string password)
    {
        return Auth(false,email,password);
    }
    public static Task<bool> Login(string email, string password)
    {
        Console.WriteLine("in Login!");
        return Auth(true,email,password);
    }

    public static async Task<bool> Refresh()
    {
        //update idToken using refreshToken, if valid, return false if invalid or errors
        if (!File.Exists(RefreshPath))
        {
            return false;
        }
        
        DotEnv.Load();
        var envVars = DotEnv.Read();
        string apikey = envVars["FIREBASEAPIKEY"];
        //set uri
        string refreshUri = $"https://securetoken.googleapis.com/v1/token?key={apikey}";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var postData = new
                {
                    grant_type = "refresh_token",
                    refresh_token = RefreshToken
                };
                var postContent = new StringContent(JsonSerializer.Serialize(postData));
                HttpResponseMessage response = await client.PostAsync(refreshUri, postContent);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<RefreshData>(content);
                if (data == null) throw new Exception();
                IdToken = data.id_token;
                Uid = data.user_id;
                //update refresh token since we have it, though old refresh token should still be valid too!
                RefreshToken = data.refresh_token;
                AuthService.RaiseAuthenticated();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    private static async Task<bool> Auth(bool isLogin,string email, string password)
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();
        string apikey = envVars["FIREBASEAPIKEY"];
        //set authUri to appropriate uri
        string authUri = isLogin?$"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apikey}":$"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apikey}";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var postData = new
                {
                    email = email,
                    password = password,
                    returnSecureToken = true
                };
                var postContent = new StringContent(JsonSerializer.Serialize(postData));
                HttpResponseMessage response = await client.PostAsync(authUri, postContent);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<AuthData>(content);
                if (data == null) throw new Exception();
                IdToken = data.idToken;
                RefreshToken = data.refreshToken;
                Uid = data.localId;
                //invoke login changed event
                AuthService.RaiseLoginChange(true);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}