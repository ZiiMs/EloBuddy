using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.Sona
{
    public static class Sona
    {
        // We are double checking to make sure that the correct script is being loaded.
        public const string ChampName = "Sona";

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName == ChampName)
            {
                return;
            }
        }
        public static void Initialize()
        {
            // This Allows us to call this program to be loaded in our initiliazing program
        }
    }
}
