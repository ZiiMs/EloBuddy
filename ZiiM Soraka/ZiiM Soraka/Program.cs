using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.Soraka
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Soraka";

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }
            
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            Drawing.OnDraw += OnDraw;
        }



        private static void OnDraw(EventArgs args)
        {
            //Drawing all Circles
            foreach (var spell in SpellManager.AllSpells)
            {
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        if (!Config.Drawing.DrawQ)
                        {
                            continue;
                        }
                        break;
                    case SpellSlot.W:
                        if (!Config.Drawing.DrawW)
                        {
                            continue;
                        }
                        break;
                    case SpellSlot.E:
                        if (!Config.Drawing.DrawE)
                        {
                            continue;
                        }
                        break;

                }

                Circle.Draw(spell.GetColor(), spell.Range, Player.Instance.Position);

            }
        }
        public static void Initialize()
        {
        }
    }
}
