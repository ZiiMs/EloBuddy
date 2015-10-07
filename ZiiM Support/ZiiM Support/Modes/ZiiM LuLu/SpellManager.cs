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

        public static Dictionary<SpellSlot, Color> ColorTranslatio { get; private set; }

        static SpellManager()
        {
            // Initialize spells
            Q = new Spell.Skillshot(SpellSlot.Q, 925, SkillShotType.Linear, 150, 1400, 80);

            // TODO: Uncomment the other spells to initialize them
            W = new Spell.Targeted(SpellSlot.W, 650);
            E = new Spell.Targeted(SpellSlot.E, 650);
            R = new Spell.Targeted(SpellSlot.R, 900);

            AllSpell = new List<Spell.SpellBase>(new Spell.SpellBase[] { Q, W, E, R });
            ColorTranslatio = new Dictionary<SpellSlot, Color>
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

        public static Color GetColo(this Spell.SpellBase spell)
        {
            return ColorTranslatio.ContainsKey(spell.Slot) ? ColorTranslatio[spell.Slot] : Color.Wheat;
        }
    }
}
