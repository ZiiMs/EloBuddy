using EloBuddy.SDK;

namespace ZiiM.Ekko.Modes
{
    public abstract class ModeBase
    {
        // The spells that we are gonna call
        protected Spell.Skillshot Q { get { return SpellManager.Q; } }
        protected Spell.Skillshot W { get { return SpellManager.W; } }
        protected Spell.Skillshot E { get { return SpellManager.E; } }
        protected Spell.Active R { get { return SpellManager.R; } }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
