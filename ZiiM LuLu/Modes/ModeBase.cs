using EloBuddy.SDK;

namespace ZiiM.LuLu.Modes
{
    public abstract class ModeBase
    {
        // The spells that we are gonna call
        protected Spell.Skillshot Q { get { return SpellManager.Q; } }
        protected Spell.Targeted W { get { return SpellManager.W; } }
        protected Spell.Targeted E { get { return SpellManager.E; } }
        protected Spell.Targeted R { get { return SpellManager.R; } }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
