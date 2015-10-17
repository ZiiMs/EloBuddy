using EloBuddy;
using System.Linq;
using EloBuddy.SDK;

using Settings = ZiiM.Leona.Config.Modes.LaneClear;
  
namespace ZiiM.Leona.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Player.Instance.ManaPercent < Settings.Mana)
            {
                return;
            }

            // Minions around
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Q.Range);
            if (minions.Count() == 0)
            {
                return;
            }
            var minionsInQRange = minions.Where(m => Q.IsInRange(m)).ToArray();

            if (Settings.UseQ && Q.IsReady())
            {
                if (minionsInQRange.Length >= 1)
                {
                    Q.Cast();
                }
            }
            var minionsInERange = minions.Where(m => W.IsInRange(m)).ToArray();

            if (Settings.UseW && W.IsReady())
            {
                if (minionsInERange.Length >= 2)
                {
                    W.Cast();
                }
            }
        }
    }
}
