using System.Net.Http;


namespace Tiscord.API;


public class DiscordAPIHandler : HttpClient
{
    public const string Endpoint = "https://discord.com/api/v10";


    public string AccessToken { get; }


    public DiscordAPIHandler(string accessToken)
    {
        BaseAddress = new(Endpoint);
        DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        DefaultRequestHeaders.Add("Content-Type", "application/json");

        AccessToken = accessToken;
    }
}
