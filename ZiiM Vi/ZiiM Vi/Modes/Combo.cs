using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;
using SharpDX;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Vi.Config.Modes.Combo;

namespace ZiiM.Vi.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseQ)
            {
                var target = TargetSelector.GetTarget(Q.MaximumRange-50, DamageType.Physical);
                if (target != null)
                {
                    if (Q.IsInRange(target) && Q.IsReady())
                    {
                        if (SpellManager.Q.IsCharging)
                        {
                            Q2.Cast(target);
                        }
                        else
                        {
                            SpellManager.Q.StartCharging();
                        }
                    }
                }
            }
            if (Settings.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Physical);
                if (target != null)
                {
                    var epred = E.GetPrediction(target);
                    if (epred.HitChance >= HitChance.Low)
                    {
                        E.Cast(epred.CastPosition);
                    }
                }
            }
            if (Settings.UseR && R.IsReady())
            {
                var target = TargetSelector.GetTarget(R.Range, DamageType.Physical);
                if (target != null)
                {
                    if (target.Health > Player.Instance.GetSpellDamage(target, SpellSlot.R, DamageLibrary.SpellStages.DamagePerStack))
                    {
                        R.Cast(target);
                    }
                }
            }
        }
    }
}
