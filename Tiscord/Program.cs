using System;
using System.IO;

using Tiscord.API;
using Tiscord.Terminal;


namespace Tiscord;


class TiscordApp
{
    public static void Main()
    {
        Config.InitConfigPath();

        ClientId clientData;

        try
        {
            Console.WriteLine("Loading client data from configuration path.");
            clientData = Config.GetClientIdFromConfigPath();
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine("Couldn't load client data from configuration path.");
            Console.WriteLine($"Configuration can be find at '{Config.ConfigPath}'.");

            clientData = Input.ReadClientIdFromTerminal();

            Config.LoadClientIdToConfigPath(clientData);
        }

        Console.WriteLine("Asking for authentication.");

        string? authCode = DiscordOAuth.GetAuthCode();

        if (authCode is null)
        {
            Console.WriteLine("OAuth2 didn't work as expected. Closing application.");
            return;
        }

        Console.WriteLine($"OAuth2 code: {authCode}.");
        Console.WriteLine("Requesting access token.");

        string accessToken = DiscordOAuth.GetBearerToken(authCode, clientData)["access_token"]!.ToString();
        Console.WriteLine($"Access token: {accessToken}.");

        DiscordAPIHandler discord = new(accessToken);

        // does nothing bruh
    }
}
