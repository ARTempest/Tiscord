using System.Net;
using System.Diagnostics;


namespace Tiscord.Server;


public static class OAuthHandler
{
    public static string? RequestAuthCode()
    {
        const string DiscordRedirectUrl = "https://discord.com/oauth2/authorize?client_id=1330614744649957457&response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A5010&scope=identify";

        HttpListener listener = new();
        listener.Prefixes.Add("http://localhost:5010/");
        listener.Start();

        Process.Start("xdg-open", DiscordRedirectUrl);

        return listener.GetContext().Request.QueryString["code"];
    }
}
