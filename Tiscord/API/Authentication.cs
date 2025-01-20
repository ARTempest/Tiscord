using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Diagnostics;


namespace Tiscord.API;


public record ClientId(string Id, string Secret);


public static class DiscordOAuth
{
    public const string AuthServerUrl = "http://localhost:5050/";

    public const string AuthEndpoint =
        "https://discord.com/oauth2/authorize?client_id=1330614744649957457&response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A5050%2F&scope=identify";

    public const string TokenEndpoint = $"{DiscordAPIHandler.Endpoint}/oauth2/token";


    /// <summary>
    /// Requests the exchange of the authentication token by the API access token.
    /// </summary>
    /// <param name="authCode">The authentication code.</param>
    /// <param name="clientData">Client authentication data.</param>
    /// <returns>The access bearer token string.</returns>
    public static string GetBearerToken(string authCode, ClientId clientData)
    {
        HttpClient client = new();
        HttpRequestMessage request = new(HttpMethod.Post, TokenEndpoint);
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", authCode },
            { "redirect_uri", AuthServerUrl },
            { "client_id", clientData.Id },
            { "client_secret", clientData.Secret }
        });

        HttpResponseMessage response = client.Send(request);

        return response.Content.ReadAsStringAsync().Result;
    }


    /// <summary>
    /// Setups a server that listens for the authentication code from Discord at localhost.
    /// </summary>
    /// <returns>The authentication code string.</returns>
    public static string? GetAuthCode()
    {
        HttpListener httpServer = new();
        httpServer.Prefixes.Add(AuthServerUrl);
        httpServer.Start();

        Process.Start("xdg-open", AuthEndpoint);
        HttpListenerContext context = httpServer.GetContext();

        return context.Request.QueryString["code"];
    }
}
