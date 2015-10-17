using EloBuddy.SDK;

namespace ZiiM.Vi.Modes
{
    public abstract class ModeBase
    {
        // The spells that we are gonna call
        protected Spell.Chargeable Q { get { return SpellManager.Q; } }
        protected Spell.Skillshot Q2 { get { return SpellManager.Q2; } }
        protected Spell.Skillshot E { get { return SpellManager.E; } }
        protected Spell.Targeted R { get { return SpellManager.R; } }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
