using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;


namespace ZiiM.Leona.Modes
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
