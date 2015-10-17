using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Ekko.Config.Misc.AutoUlt;


namespace ZiiM.Ekko.Modes
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
            if (Settings.UseR && R.IsReady() && Player.Instance.IsRecalling() && !Player.Instance.IsDead && Player.Instance.HealthPercent <= Settings.MinHP)
            { 
                R.Cast();
            }
            /*if (ZiiM.Ekko.Config.Misc.AutoStun.UseW && W.IsReady() && !Player.Instance.IsRecalling && !Player.Instance.IsDead)
            {
                foreach (var stuntar in EntityManager.Heroes.Enemies.Where(e => W.IsInRange(e)))
                {
                    if (stuntar != null)
                        W.Cast(stuntar);
                }
            }*/
        }
    }
}
