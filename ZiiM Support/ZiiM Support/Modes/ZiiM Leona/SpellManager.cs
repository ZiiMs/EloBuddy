using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace ZiiM.Leona
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Active Q { get; private set; }
        public static Spell.Active W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot R { get; private set; }

        public static List<Spell.SpellBase> AllSpell { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Active(SpellSlot.Q, 100);
            W = new Spell.Active(SpellSlot.W, 450);
            E = new Spell.Skillshot(SpellSlot.E, 875, SkillShotType.Linear, 150, 1200, 80);
            R = new Spell.Skillshot(SpellSlot.R, 1200, SkillShotType.Circular, 150, 20, 120);

            AllSpell = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
        }
        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
    }
}
