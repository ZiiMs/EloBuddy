using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.Sona
{
    public static class Sona
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Sona";

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName == ChampName)
            {
                return;
            }

            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            //Drawing all Circles
            foreach (var spell in SpellManager.AllSpell)
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

                Circle.Draw(spell.GetColo(), spell.Range, Player.Instance.Position);
            }
        }
        public static void Initialize()
        {
        }
    }
}
