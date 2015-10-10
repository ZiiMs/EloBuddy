using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace ZiiM.Vi
{
    public static class SpellManager
    {
        // You will need to edit the types of spells you have for each champ as they
        // don't have the same type for each champ, for example Xerath Q is chargeable,
        // right now it's  set to Active.
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Targeted R { get; private set; }

        public static List<Spell.SpellBase> AllSpells { get; private set; }

        public static Dictionary<SpellSlot, Color> ColorTranslation { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 250, SkillShotType.Linear, 250, 1500, 55);
            E = new Spell.Skillshot(SpellSlot.E, 400, SkillShotType.Linear, 250, null, 350);
            R = new Spell.Targeted(SpellSlot.R, 800);

            AllSpells = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, E, R });
            ColorTranslation = new Dictionary<SpellSlot, Color>
            {
                { SpellSlot.Q, Color.Blue.ToArgb(150) },
                { SpellSlot.E, Color.Green.ToArgb(150) },
                { SpellSlot.R, Color.Red.ToArgb(150) }
            };
        }

        public static void Initialize()
        {
        }
        private static Color ToArgb(this Color color, byte a)
        {
            return new ColorBGRA(color.R, color.G, color.B, a);
        }

        public static Color GetColor(this Spell.SpellBase spell)
        {
            return ColorTranslation.ContainsKey(spell.Slot) ? ColorTranslation[spell.Slot] : Color.Wheat;
        }
    }
}
