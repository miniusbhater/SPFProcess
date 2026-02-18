using System.Runtime.InteropServices;

class Program
{
    [DllImport("steam_api.dll")]
    private static extern bool SteamAPI_Init();

    [DllImport("steam_api.dll")]
    private static extern void SteamAPI_RunCallbacks();

    static void Main(string[] args)
    {
        if (args.Length == 0) // help you if your fucking stupid (jokes :p)
        {
            Console.WriteLine("Usage: SteamPlaytimeFarm.exe <AppID>");
            return;
        }

        string appId = args[0];

        File.WriteAllText("steam_appid.txt", appId); // i wonder

        if (!SteamAPI_Init())
        {
            Console.WriteLine("Steam init failed.");
            return;
        }

        Console.WriteLine($"Idling AppID {appId}");

        while (true)
        {
            SteamAPI_RunCallbacks();
            Thread.Sleep(1000);
        }
    }
}
