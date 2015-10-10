using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

// Using the config like this makes your life easier, trust me
using Settings = ZiiM.Vi.Config.Misc.AutoUlt;


namespace ZiiM.Vi.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }
        public override void Execute()
        {
        }
    }
}
