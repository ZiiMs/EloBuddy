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
            if (Settings.UseQ && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
                if (target != null)
                {
                    var qpred = Q.GetPrediction(target);
                    if (qpred.HitChance >= HitChance.High)
                    {
                        Q.Cast(qpred.CastPosition);
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
