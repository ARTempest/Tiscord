using System;

using Tiscord.API;


namespace Tiscord.Terminal;


public static class Input
{
    public static ClientId ReadClientIdFromTerminal()
    {
        Console.Write("Enter your client id: ");
        string id = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter your client secret: ");
        string secret = Console.ReadLine() ?? string.Empty;

        return new(id, secret);
    }
}
