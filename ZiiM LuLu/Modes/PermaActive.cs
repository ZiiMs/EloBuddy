using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.LuLu.Config.Misc.AutoUlt;
using Setting = ZiiM.LuLu.Config.Misc.AutoShield;

namespace ZiiM.LuLu.Modes
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
            if (Settings.UseR && R.IsReady() && !Settings.UltSelf)
            {
                var getult = EntityManager.Heroes.Allies.Where(h => !h.IsDead && !h.IsRecalling && R.IsInRange(h) && h.HealthPercent <= Settings.MinHP && Player.Instance.CountEnemiesInRange(1200f) > 0).ToList();
                var ulttar = getult.OrderBy(x => x.Health).FirstOrDefault(x => !x.IsInShopRange());
                if (ulttar != null)
                    R.Cast(ulttar);
            }
            if (Settings.UseR && R.IsReady() && Settings.UltSelf)
            {
                var ultself = EntityManager.Heroes.Allies.Where(h => !h.IsDead && h.IsMe && !h.IsRecalling && R.IsInRange(h) && h.HealthPercent <= Settings.MinHP && Player.Instance.CountEnemiesInRange(1200f) > 0).ToList();
                var ultme = ultself.OrderBy(x => x.Health).FirstOrDefault(x => !x.IsInShopRange());
                if (ultme != null)
                    R.Cast(ultme);
            }
        }
    }
}
