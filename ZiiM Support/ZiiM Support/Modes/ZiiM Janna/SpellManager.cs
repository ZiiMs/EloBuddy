using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace ZiiM.Janna
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Active R { get; private set; }

        public static List<Spell.SpellBase> AllSpell { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 965, SkillShotType.Linear, 10, 900, 120);

            // TODO: Uncomment the other spells to initialize them
            W = new Spell.Targeted(SpellSlot.W, 550);
            E = new Spell.Targeted(SpellSlot.E, 750);
            R = new Spell.Active(SpellSlot.R, 675);

            AllSpell = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
        }
        public static void Initialize()
        {
        }
    }
}
