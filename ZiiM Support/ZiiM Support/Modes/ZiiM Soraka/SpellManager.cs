using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace ZiiM.Soraka
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Active R { get; private set; }

        public static List<Spell.SpellBase> AllSpell { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 900, SkillShotType.Circular, 150, 1750, 260);
            W = new Spell.Targeted(SpellSlot.W, 500);
            E = new Spell.Skillshot(SpellSlot.E, 825, SkillShotType.Circular, 150, 0, 250);
            R = new Spell.Active(SpellSlot.R, 25000);

            AllSpell = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E });
        }
        public static void Initialize()
        {
        }
    }
}
