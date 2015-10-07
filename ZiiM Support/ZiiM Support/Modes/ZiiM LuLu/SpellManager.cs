using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace ZiiM.LuLu
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Targeted W { get; private set; }
        public static Spell.Targeted E { get; private set; }
        public static Spell.Targeted R { get; private set; }

        public static List<Spell.SpellBase> AllSpell { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 925, SkillShotType.Linear, 150, 1400, 80);

            // TODO: Uncomment the other spells to initialize them
            W = new Spell.Targeted(SpellSlot.W, 650);
            E = new Spell.Targeted(SpellSlot.E, 650);
            R = new Spell.Targeted(SpellSlot.R, 900);

            AllSpell = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
        }
        public static void Initialize()
        {
            // This Allows us to call this program to be loaded in our initiliazing program
        }
    }
}
