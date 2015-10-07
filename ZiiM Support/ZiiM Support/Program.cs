using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.Support
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct
        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            SpellColors.Initialize();
            
            if (Player.Instance.ChampionName == "Lulu")
            {
                // Champion is not the one we made this addon for,
                // therefore we return



                // Initialize the classes that we need
                ZiiM.LuLu.Config.Initialize();
                ZiiM.LuLu.SpellManager.Initialize();
                ZiiM.LuLu.ModeManager.Initialize();
                ZiiM.LuLu.AutoShield.Initialize();
                ZiiM.LuLu.LuLu.Initialize();
                Drawing.OnDraw += OnDraw;
            }
            else if (Player.Instance.ChampionName == "Sona")
            {
                // Champion is not the one we made this addon for,
                // therefore we return



                // Initialize the classes that we need
                ZiiM.Sona.Config.Initialize();
                ZiiM.Sona.SpellManager.Initialize();
                ZiiM.Sona.ModeManager.Initialize();
                ZiiM.Sona.Sona.Initialize();
                Drawing.OnDraw += OnDraw;
            }
            else if (Player.Instance.ChampionName == "Leona")
            {
                // Champion is not the one we made this addon for,
                // therefore we return



                // Initialize the classes that we need
                ZiiM.Leona.Config.Initialize();
                ZiiM.Leona.SpellManager.Initialize();
                ZiiM.Leona.ModeManager.Initialize();
                ZiiM.Leona.Leona.Initialize();
                Drawing.OnDraw += OnDraw;
            }
            else
            {
                return;
            }
            var SkinChampName = Player.Instance.ChampionName;
            var version = "Version 1.3.7";

            Chat.Print("ZiiM's Support bundle loaded. " + version, Color.Blue);
            Chat.Print("You have loaded ZiiM's " + SkinChampName + ".", Color.Blue);
        }
        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.ChampionName == "Lulu")
            {
                foreach (var spell in ZiiM.LuLu.SpellManager.AllSpell)
                {
                    switch (spell.Slot)
                    {
                        case SpellSlot.Q:
                            if (!ZiiM.LuLu.Config.Drawing.DrawQ)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.W:
                            if (!ZiiM.LuLu.Config.Drawing.DrawW)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.E:
                            if (!ZiiM.LuLu.Config.Drawing.DrawE)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.R:
                            if (!ZiiM.LuLu.Config.Drawing.DrawR)
                            {
                                continue;
                            }
                            break;

                    }
                    Circle.Draw(spell.GetColor(), spell.Range, Player.Instance.Position);
                }
            }
            else if (Player.Instance.ChampionName == "Sona")
            {
                foreach (var spell in ZiiM.Sona.SpellManager.AllSpell)
                {
                    switch (spell.Slot)
                    {
                        case SpellSlot.Q:
                            if (!ZiiM.Sona.Config.Drawing.DrawQ)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.W:
                            if (!ZiiM.Sona.Config.Drawing.DrawW)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.E:
                            if (!ZiiM.Sona.Config.Drawing.DrawE)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.R:
                            if (!ZiiM.Sona.Config.Drawing.DrawR)
                            {
                                continue;
                            }
                            break;

                    }

                    Circle.Draw(spell.GetColor(), spell.Range, Player.Instance.Position);
                }
            }
            else if (Player.Instance.ChampionName == "Leona")
            {
                foreach (var spell in ZiiM.Leona.SpellManager.AllSpell)
                {
                    switch (spell.Slot)
                    {
                        case SpellSlot.Q:
                            if (!ZiiM.Leona.Config.Drawing.DrawQ)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.W:
                            if (!ZiiM.Leona.Config.Drawing.DrawW)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.E:
                            if (!ZiiM.Leona.Config.Drawing.DrawE)
                            {
                                continue;
                            }
                            break;
                        case SpellSlot.R:
                            if (!ZiiM.Leona.Config.Drawing.DrawR)
                            {
                                continue;
                            }
                            break;

                    }

                    Circle.Draw(spell.GetColor(), spell.Range, Player.Instance.Position);
                }
            }
        }
    }
}
