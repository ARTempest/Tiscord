using System;

using Tiscord.Server;


namespace Tiscord;


class TiscordApp
{
    public static void Main()
    {
        Console.WriteLine("Tiscord started, welcome!");

        Console.WriteLine("Asking for Discord permission in the browser, please accept.");
        string? authCode = OAuthHandler.RequestAuthCode();

        if (authCode is null)
        {
            Console.WriteLine("OAuth didn't work as expected, closing application...");
            return;
        }

        const string ClientId = "1330614744649957457";
        const string ClientSecret = "vM3eWsw3Yy-tG6n3pzXOdRyjmSNp8fhM";

        DiscordAPIHandler discord = new(ClientId, ClientSecret, authCode);


    }
}
