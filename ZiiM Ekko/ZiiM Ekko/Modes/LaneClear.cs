using EloBuddy;
using System;
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
                    foreach (var eminions in EntityManager.MinionsAndMonsters.EnemyMinions)
                    {
                        Chat.Print("The target is : " + eminions.Name);

                        var result = Prediction.Position.PredictLinearMissile(eminions,
                            Q.Range, Q.Width, Q.CastDelay, Q.Speed, Int32.MaxValue, Player.Instance.ServerPosition);

                        var colli = result.CollisionObjects;

                        for (int j = 0; j < colli.Length; j++)
                        {
                            if (!colli[j].IsEnemy)
                            {
                                if (colli.Length < Settings.MinInQ)
                                {
                                    Q.Cast(colli[j]);
                                }
                            }
                        }
                    }
                }
                #endregion

                #region W usage
                if (Settings.UseW && Player.Instance.ManaPercent > Settings.Mana && W.IsReady())
                {
                    foreach (var eminions in EntityManager.MinionsAndMonsters.EnemyMinions)
                    {
                        Chat.Print("The target is : " + eminions.Name);

                        var result = Prediction.Position.PredictCircularMissile(eminions,
                            W.Range, W.Radius, W.CastDelay, W.Speed, Player.Instance.ServerPosition);

                        var colli = result.CollisionObjects;

                        for (int j = 0; j < colli.Length; j++)
                        {
                            if (!colli[j].IsEnemy)
                            {
                                Chat.Print(colli[j].Name + " is on the path");
                            }
                        }
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
