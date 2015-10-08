using EloBuddy;
using System.Linq;
using EloBuddy.SDK;
using Settings = ZiiM.Ekko.Config.Modes.LaneClear;

namespace ZiiM.Ekko.Modes
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
            // Minions around
            foreach (var minions in EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Q.Range))
            {
                #region Q usage
                if (Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
                {
                    {
                        Q.Cast(minions);
                    }
                }
                #endregion

                #region W usage
                if (Settings.UseW && Player.Instance.ManaPercent > Settings.Mana && W.IsReady())
                {
                    {
                        W.Cast(minions);
                    }
                }
                #endregion

                #region E usage
                if (Settings.UseE && Player.Instance.ManaPercent > Settings.Mana && E.IsReady())
                {
                    {
                        E.Cast(minions);
                    }
                }
                #endregion
            }
        }
    }
}
