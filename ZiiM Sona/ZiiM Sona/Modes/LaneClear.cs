using EloBuddy;
using System.Linq;
using EloBuddy.SDK;
using Settings = ZiiM.Sona.Config.Modes.LaneClear;

namespace ZiiM.Sona.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (Player.Instance.ManaPercent < Settings.Mana)
            {
                return;
            }

            if (!(Settings.UseQ && Q.IsReady()))
            {
                return;
            }

            // Minions around
            var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Q.Range);
            if (minions.Count == 0)
            {
                return;
            }

            #region Q usage

            var minionsInRange = minions.Where(m => Q.IsInRange(m)).ToArray();

            if (Settings.UseQ && Q.IsReady())
            {
                if (minionsInRange.Length >= 1)
                {
                    Q.Cast();
                }
            }

            #endregion
        }
    }
}
