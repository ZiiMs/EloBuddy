using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Color = System.Drawing.Color;
using SpellData = ZiiM.Ekko.DamageIndicator.SpellData;

namespace ZiiM.Ekko
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public static DamageIndicator.DamageIndicator Indicator;
        public const string ChampName = "Ekko";

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
            Indicator = new DamageIndicator.DamageIndicator();

            Indicator.Add("Q", new SpellData(SpellSlot.Q, true, DamageLibrary.SpellStages.Default, Color.Blue));
            Indicator.Add("E", new SpellData(SpellSlot.E, true, DamageLibrary.SpellStages.Default, Color.Blue));
            Indicator.Add("R", new SpellData(SpellSlot.R, true, DamageLibrary.SpellStages.Default, Color.Blue));
            Indicator.Add("Q2", new SpellData(SpellSlot.Q, true, DamageLibrary.SpellStages.WayBack, Color.Blue));
            Indicator.Add("P", new SpellData(SpellSlot.Unknown, true, DamageLibrary.SpellStages.Passive, Color.Red));


            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();
            var version = "1.2.1";
            var championname = Player.Instance.ChampionName;
            Chat.Print("ZiiM's " + championname + " " + version + " Loaded.");

            Drawing.OnDraw += OnDraw;
            Game.OnUpdate += Game_OnUpdate;
        }
        private static void Game_OnUpdate(EventArgs args)
        {
            //Indicator.Update("Combo", new SpellData((int)DamageHandler.ComboDamage(), DamageType.Physical, Color.Aqua));
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
                    case SpellSlot.R:
                        if (!Config.Drawing.DrawR)
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
