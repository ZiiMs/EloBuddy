﻿using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.LuLu
{
    public static class LuLu
    {
        // We are double checking to make sure that the correct script is being loaded.
        public const string ChampName = "Lulu";

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }
        }
        public static void Initialize()
        {
        }
    }
}
