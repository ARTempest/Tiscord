using System.Net.Http;


namespace Tiscord.Server;


public class DiscordAPIHandler : HttpClient
{
    public const string Endpoint = "https://discord.com/api/v10/";


    public HttpClient Client { get; }

    public string ClientId { get; }
    public string ClientSecret { get; }
    public string AuthCode { get; }


    public DiscordAPIHandler(string clientId, string clientSecret, string authCode)
    {
        Client = new();

        ClientId = clientId;
        ClientSecret = clientSecret;
        AuthCode = authCode;
    }
}
