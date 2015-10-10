using EloBuddy;
using System.Linq;
using EloBuddy.SDK;
using Settings = ZiiM.Vi.Config.Modes.LaneClear;

namespace ZiiM.Vi.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            // Minions around
            foreach (var JG in EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, E.Range))
            {
                #region Q usage
                if (Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
                {
                    {
                        Q.Cast(JG);
                    }
                }
                #endregion

                #region E usage
                if (Settings.UseE && Player.Instance.ManaPercent > Settings.Mana && E.IsReady())
                {
                    {
                        E.Cast(JG);
                    }
                }
                #endregion
            }
        }
    }
}
