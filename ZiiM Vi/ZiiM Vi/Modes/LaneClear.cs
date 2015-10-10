using EloBuddy;
using System;
using System.Linq;
using EloBuddy.SDK;
using Settings = ZiiM.Vi.Config.Modes.LaneClear;

namespace ZiiM.Vi.Modes
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

            #region Q usage
            if (Settings.UseQ && Player.Instance.ManaPercent > Settings.Mana && Q.IsReady())
            {
                foreach (var eminions in EntityManager.MinionsAndMonsters.EnemyMinions)
                {

                    var result = Prediction.Position.PredictLinearMissile(eminions,
                        Q.Range, Q.Width, Q.CastDelay, Q.Speed, Int32.MaxValue, Player.Instance.ServerPosition);

                    var colli = result.CollisionObjects;

                    for (int j = 0; j < colli.Length; j++)
                    {
                        if (colli[j].IsMinion)
                        {
                            if (colli.Length >= Settings.MinInQ)
                            {
                                Q.Cast(colli[j]);
                            }
                        }
                    }
                }
            }
            #endregion

            #region E usage
            if (Settings.UseE && Player.Instance.ManaPercent > Settings.Mana && E.IsReady())
            {
                foreach (var eminions in EntityManager.MinionsAndMonsters.EnemyMinions)
                {

                    var result = Prediction.Position.PredictLinearMissile(eminions,
                        E.Range, E.Width, E.CastDelay, E.Speed, Int32.MaxValue, Player.Instance.ServerPosition);

                    var colli = result.CollisionObjects;

                    for (int j = 0; j < colli.Length; j++)
                    {
                        if (colli[j].IsMinion)
                        {
                            if (colli.Length >= Settings.MinInQ)
                            {
                                E.Cast(colli[j]);
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}
