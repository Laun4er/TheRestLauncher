using DiscordRPC;
using System;
using TheRestLauncher.Settings;

namespace TheRestLauncher.Classes
{
     public class Discord_Rich_Presence
    {
        private bool DRPCenable;
        private DiscordRpcClient client;
        private Timestamps timestamps;

        public Discord_Rich_Presence(string Rich)
        {
            client = new DiscordRpcClient(Rich);
            timestamps = new Timestamps(DateTime.UtcNow);
            client.Initialize();
            DRPCenable = Launcher.Default.RPC;
        }

        public static Discord_Rich_Presence instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Discord_Rich_Presence("1237463189722103838");
                }
                return instance;
            }
        }

        public void UpdatePresence(string pageTitle)
        {
            if(DRPCenable)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = pageTitle,
                    Timestamps = timestamps,
                    Assets = new Assets()
                    {
                        LargeImageKey = "test"
                    }
                });
            }
            else
            {
                client.ClearPresence();
            }    
        }
        public void tongle()
        {
            DRPCenable = !DRPCenable;

            Launcher.Default.RPC = DRPCenable;
            Launcher.Default.Save();
        }
    }
}
