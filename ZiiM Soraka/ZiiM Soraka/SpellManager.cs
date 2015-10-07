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

        public static List<Spell.SpellBase> AllSpells { get; private set; }

        public static Dictionary<SpellSlot, Color> ColorTranslation { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 900, SkillShotType.Circular, 150, 1750, 260);
            W = new Spell.Targeted(SpellSlot.W, 500);
            E = new Spell.Skillshot(SpellSlot.E, 825, SkillShotType.Circular, 150, 0, 250);
            R = new Spell.Active(SpellSlot.R, 1000);

            AllSpells = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
            ColorTranslation = new Dictionary<SpellSlot, Color>
            {
                { SpellSlot.Q, Color.Blue.ToArgb(150) },
                { SpellSlot.W, Color.Purple.ToArgb(150) },
                { SpellSlot.E, Color.Green.ToArgb(150) },
                { SpellSlot.R, Color.Red.ToArgb(150) }

            };
        }

        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
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
