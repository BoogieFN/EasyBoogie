using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using ConsoleControlAPI;

namespace EasyBoogie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    ______                 ____  ____  ____  ________________");
                Console.WriteLine("   / ____/___ ________  __/ __ )/ __ \\/ __ \\/ ____/  _/ ____/");

                Console.WriteLine("  / __/ / __ `/ ___/ / / / __  / / / / / / / / __ / // __/   ");
                Console.WriteLine(" / /___/ /_/ (__  ) /_/ / /_/ / /_/ / /_/ / /_/ // // /___   ");
                Console.WriteLine("/_____/\\__,_/____/\\__, /_____/\\____/\\____/\\____/___/_____/   ");
                Console.WriteLine("                 /____/                                      ");
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[BOOGIE] Welcome To EasyBoogie! discord.gg/fortnitedev");

                Console.WriteLine("[BOOGIE] Loading Installation Path");

                string EasyBoogieBuildPath = "";
                try
                {
                    dynamic EasyBoogieJVal = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat")));
                    foreach (var installion in EasyBoogieJVal.InstallationList)
                    {
                        if (installion.AppName == "Fortnite")
                        {
                            EasyBoogieBuildPath = installion.InstallLocation.ToString();
                            string EasyBoogieVersion = installion.AppVersion.ToString().Split('-')[1];
                            Console.WriteLine($"[BOOGIE] Found Version {EasyBoogieVersion} in {EasyBoogieBuildPath} !");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[ERROR] Could not locate Epic Installations List, Please make sure you have Fortnite Installed!");
                }
                Console.WriteLine("[BOOGIE] Fetching Required Files");

                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFile("https://cdn.boogiefn.dev/assets/dlls/BAC.exe", EasyBoogieBuildPath + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_BE.exe");
                client.DownloadFile("https://cdn.boogiefn.dev/assets/dlls/BAC.exe", EasyBoogieBuildPath + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_EAC.exe");
                client.DownloadFile("https://cdn.discordapp.com/attachments/1059106864303980574/1066797541183717386/Boogie.dll", EasyBoogieBuildPath + "/Boogie.dll");
                Console.WriteLine("[BOOGIE] Launching");
                System.Diagnostics.Process EasyBoogieGame = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(
                            EasyBoogieBuildPath + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe"
                        )
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                EasyBoogieGame.Start();
                Console.WriteLine("[BOOGIE] Launched!");
                Console.WriteLine("[BOOGIE] Thank you for using EasyBoogie! https://github.com/BoogieFN/EasyBoogie");
                EasyBoogieGame.WaitForInputIdle();
                EasyBoogieGame.WaitForExit();
                Console.WriteLine("[BOOGIE] Exiting...");
                System.Threading.Thread.Sleep(5000);
            }
            
            catch (System.Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex}");
            }
        }
    }
}
