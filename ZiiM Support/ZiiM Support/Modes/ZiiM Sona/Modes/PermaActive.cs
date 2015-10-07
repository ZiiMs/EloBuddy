using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Sona.Config.Misc;

namespace ZiiM.Sona.Modes
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
            if (Settings.UseW && Player.Instance.ManaPercent > Settings.Mana && W.IsReady())
            {
                var tars = EntityManager.Heroes.Allies.Where(a => W.IsInRange(a)).ToArray();
                {
                    if (tars.Length >= Settings.Allies)
                    {
                        foreach (var target in HeroManager.Allies.Where(target => target.IsValidTarget(W.Range) && !target.IsZombie && !target.IsMe))
                        {
                            if (target.HealthPercent <= Settings.MinHP)
                            {
                                W.Cast();
                            }
                        }
                    }
                }
            }
            if (Settings.HealSelf && Player.Instance.ManaPercent > Settings.Mana && W.IsReady())
            {
                if (Player.Instance.HealthPercent <= Settings.MinHP)
                {
                    W.Cast();
                }
            }
        }
    }
}
