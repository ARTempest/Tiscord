using System.IO;

using Tiscord.API;


namespace Tiscord;


public static class Config
{
    public const string ConfigPath = "~/.config/Tiscord";
    public const string ClientIdFile = $"{ConfigPath}/client_id";
    public const string ClientSecretFile = $"{ConfigPath}/client_secret";


    public static void InitConfigPath()
    {
        if (!Directory.Exists(ConfigPath))
            Directory.CreateDirectory(ConfigPath);
    }


    public static ClientId GetClientIdFromConfigPath()
    {
        string clientId = File.ReadAllText(ClientIdFile);
        string clientSecret = File.ReadAllText(ClientSecretFile);

        return new(clientId, clientSecret);
    }


    public static void LoadClientIdToConfigPath(ClientId clientData)
    {
        File.WriteAllText(ClientIdFile, clientData.Id);
        File.WriteAllText(ClientSecretFile, clientData.Secret);
    }
}
