using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Sona.Config.Modes.Combo;

namespace ZiiM.Sona.Modes
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
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            if (target != null)
            {
                if (Settings.UseQ && Q.IsReady())
                {
                    Q.Cast(target);
                    return;
                }
                if (Settings.UseR && R.IsReady())
                {
                    R.Cast(target);
                    return;
                }
            }
        }
    }
}
