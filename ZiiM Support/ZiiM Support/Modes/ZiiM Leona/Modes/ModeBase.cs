﻿using EloBuddy.SDK;

namespace ZiiM.Leona.Modes
{
    public abstract class ModeBase
    {
        // The spells that we are gonna call
        protected Spell.Active Q { get { return SpellManager.Q; } }
        protected Spell.Active W { get { return SpellManager.W; } }
        protected Spell.Skillshot E { get { return SpellManager.E; } }
        protected Spell.Skillshot R { get { return SpellManager.R; } }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
