using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using Settings = ZiiM.LuLu.Config.Misc.AutoShield;

namespace ZiiM.LuLu
{
    public class AutoShield
    {
        private static Spell.Targeted E
        {
            get { return SpellManager.E; }
        }
        private static readonly Dictionary<float, float> IncDamage = new Dictionary<float, float>();
        private static readonly Dictionary<float, float> InstDamage = new Dictionary<float, float>();
        public static float IncomingDamage
        {
            get { return IncDamage.Sum(e => e.Value) + InstDamage.Sum(e => e.Value); }
        }

        public static void Initialize()
        {
            // Listen to related events
            Game.OnUpdate += OnUpdate;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
        } 
        private static void OnUpdate(EventArgs args)
        {
            if (Settings.UseE && E.IsReady())
            {
                foreach (var ally in EntityManager.Heroes.Allies.Where(ally => E.IsInRange(ally) && !ally.IsZombie))
                {
                    // Ult casting
                    if (IncomingDamage > 0)
                        E.Cast(ally);
                }
            }

            // Check spell arrival
            foreach (var entry in IncDamage.Where(entry => entry.Key < Game.Time).ToArray())
            {
                IncDamage.Remove(entry.Key);
            }

            // Instant damage removal
            foreach (var entry in InstDamage.Where(entry => entry.Key < Game.Time).ToArray())
            {
                InstDamage.Remove(entry.Key);
            }
        }

        private static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            foreach (var ally in EntityManager.Heroes.Allies.Where(ally => E.IsInRange(ally) && !ally.IsZombie))
            { 
                if (sender.IsEnemy)
                {
                    // Calculations to save your souldbound
                    if (ally != null && Settings.UseE)
                    {
                            // Auto attacks
                            if ((!(sender is AIHeroClient) || args.SData.IsAutoAttack()) && args.Target != null && args.Target.NetworkId == ally.NetworkId)
                            {
                                // Calculate arrival time and damage
                                IncDamage[ally.ServerPosition.Distance(sender.ServerPosition) / args.SData.MissileSpeed + Game.Time] = sender.GetAutoAttackDamage(ally);
                            }
                            // Sender is a hero
                            else
                            {
                                var attacker = sender as AIHeroClient;
                                if (attacker != null)
                                {
                                var slot = attacker.GetSpellSlotFromName(args.SData.Name);

                                if (slot != SpellSlot.Unknown)
                                {
                                    if (slot == attacker.GetSpellSlotFromName("SummonerDot") && args.Target != null && args.Target.NetworkId == ally.NetworkId)
                                    {
                                        // Ingite damage (dangerous)
                                        InstDamage[Game.Time + 2] = attacker.GetSummonerSpellDamage(ally, DamageLibrary.SummonerSpells.Ignite);
                                    }
                                    else
                                    {
                                        switch (slot)
                                        {
                                            case SpellSlot.Q:
                                            case SpellSlot.W:
                                            case SpellSlot.E:
                                            case SpellSlot.R:

                                                if ((args.Target != null && args.Target.NetworkId == ally.NetworkId) || args.End.Distance(ally.ServerPosition) < Math.Pow(args.SData.LineWidth, 2))
                                                {
                                                    // Instant damage to target
                                                    InstDamage[Game.Time + 2] = attacker.GetSpellDamage(ally, slot);
                                                }

                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}