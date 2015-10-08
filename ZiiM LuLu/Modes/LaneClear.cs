using EloBuddy.SDK;
﻿using Settings = ZiiM.LuLu.Config.LaneClear;
namespace ZiiM.LuLu.Modes
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
            var minionsnear = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Q.Range);
            if (minionsnear.Count == 0)
            {
                return;
            }
            foreach (var minion in EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Q.Range))
            {
                if (Settings.UseQ && Q.IsReady())
                {
                    {
                        Q.Cast(minion);
                    }
                }
            }
            foreach (var minion in EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, E.Range))
            {
                if (Settings.UseE && E.IsReady())
                {
                    {
                        E.Cast(minion);
                    }
                }
            }
        }
    }
}
