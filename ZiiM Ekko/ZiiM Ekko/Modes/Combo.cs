using System.Linq;
using System;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Ekko.Config.Modes.Combo;

namespace ZiiM.Ekko.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (Settings.UseW && W.IsReady())
            {
                var target = TargetSelector.GetTarget(W.Range, DamageType.Magical);
                if (target != null)
                {
                    foreach (var enemy in EntityManager.Heroes.Enemies)
                    {
                        Chat.Print("The target is : " + enemy.Name);

                        var result = Prediction.Position.PredictCircularMissile(enemy,
                            W.Range, W.Radius, W.CastDelay, W.Speed, Player.Instance.ServerPosition);

                        var colli = result.CollisionObjects;

                        for (int j = 0; j < colli.Length; j++)
                        {
                            if (!colli[j].IsMinion)
                            {
                                Chat.Print(colli[j].Name + " is on the path");
                            }
                        }
                    }
                }
            }
            if (Settings.UseE && E.IsReady())
            {
                var target = TargetSelector.GetTarget(E.Range, DamageType.Magical);
                if (target != null)
                {
                    E.Cast(target);
                }
            }
            if (Settings.UseQ && Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
                if (target != null)
                {
                    Q.Cast(target);
                }
            }
        }
    }
}
