using DiscordRPC;
using System;
using System.Diagnostics;

namespace TheRestLauncher.Classes
{
     public class Discord_Rich_Presence
    {
        private DiscordRpcClient client;
        private Timestamps timestamps;

        public Discord_Rich_Presence(string Rich)
        {
            client = new DiscordRpcClient(Rich);
            timestamps = new Timestamps(DateTime.UtcNow);
            client.Initialize();
        }

        public void UpdatePresence(string pageTitle)
        {
            client.SetPresence(new RichPresence()
            {
                Details = pageTitle,
                Timestamps = timestamps,
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                }
            });
        }
    }
}
