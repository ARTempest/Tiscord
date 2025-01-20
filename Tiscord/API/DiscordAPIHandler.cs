using System.Net.Http;


namespace Tiscord.API;


public class DiscordAPIHandler : HttpClient
{
    public const string Endpoint = "https://discord.com/api/v10";


    public string AccessToken { get; }


    public DiscordAPIHandler(string accessToken)
    {
        DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

        AccessToken = accessToken;
    }
}
