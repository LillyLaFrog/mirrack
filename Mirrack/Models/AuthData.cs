namespace Mirrack.Models;

public class AuthData
{
    public string idToken { get; set; } = "";
    public string refreshToken { get; set; } = "";
    public string localId { get; set; } = "";
}

public class RefreshData
{
    public string id_token { get; set; } = "";
    public string refresh_token { get; set; } = "";
    public string user_id { get; set; } = "";
}