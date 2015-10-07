using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace ZiiM.LuLu
{
    public static class LuLu
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Lulu";

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                return;
            }

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

                Circle.Draw(spell.GetColo(), spell.Range, Player.Instance.Position);

            }
        }
        public static void Initialize()
        {
        }
    }
}
