using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Soraka.Config.Misc.AutoUlt;
using Setting = ZiiM.Soraka.Config.Misc.AutoHeal;


namespace ZiiM.Soraka.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }
        public override void Execute()
        {
            if (Settings.UseR && R.IsReady())
            {
                var ultable = EntityManager.Heroes.Allies.Where(a => !a.IsDead && !a.IsRecalling && a.HealthPercent <= Settings.MinHP);
                if (ultable != null)
                    R.Cast();
            }
            if (Setting.UseW && W.IsReady())
            {
                var ally = EntityManager.Heroes.Allies.Where(a => !a.IsDead && !a.IsMe && !a.IsRecalling && W.IsInRange(a) && a.HealthPercent <= Setting.MinHP).ToList();
                var lowally = ally.OrderBy(x => x.Health).FirstOrDefault(x => !x.IsInShopRange());
                if (lowally != null)
                    W.Cast(lowally);
            }
        }
    }
}
