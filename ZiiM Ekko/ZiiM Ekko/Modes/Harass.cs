﻿using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Ekko.Config.Modes.Harass;

namespace ZiiM.Ekko.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (target != null)
                {
                    Q.Cast(target);
                }
            }
            if (Settings.UseW && Player.Instance.ManaPercent > Settings.Mana && W.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Physical);
                if (target != null)
                {
                    W.Cast(target);
                }
            }
            if (Settings.UseE && Player.Instance.ManaPercent > Settings.Mana && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (target != null)
                {
                    E.Cast(target);
                }
            }
        }
    }
}
