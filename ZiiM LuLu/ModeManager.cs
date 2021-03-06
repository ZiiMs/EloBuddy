using System;
using System.Collections.Generic;
using ZiiM.LuLu.Modes;
using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Utils;

namespace ZiiM.LuLu
{
    public static class ModeManager
    {
        private static List<ModeBase> Modes { get; set; }

        static ModeManager()
        {
            // Initialize properties
            Modes = new List<ModeBase>();

            // Load all modes
            // Order matter here! You would want something like PermaActive being called first
            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
                new Combo(),
                new Harass(),
                new LaneClear(),
                new JungleClear(),
                new Flee()
            });

            // Listen to events we need
            Game.OnTick += OnTick;
        }

        public static void Initialize()
        {
        }

        private static void OnTick(EventArgs args)
        {
            // Execute all modes
            Modes.ForEach(mode =>
            {
                try
                {
                    // Precheck if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    // Please enable the debug window to see and solve the exceptions that might occur!
                    Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}
