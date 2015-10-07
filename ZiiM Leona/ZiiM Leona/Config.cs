using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ZiiM.Leona
{
    public static class Config
    {
        private const string MenuName = "ZiiM's Leona";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("ZiiM's Leona!");
            Menu.AddLabel("Hope you enjoy!");
            Menu.AddSeparator();
            Menu.AddLabel("Created by: ZiiM");

            // Initialize the modes
            Modes.Initialize();

            //Drawing
            Drawing.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                Menu.AddSeparator();

                // Laneclear
                LaneClear.Initialize();
                Menu.AddSeparator();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Use W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R"));
                }

                public static void Initialize()
                {
                }
            }
            public static class LaneClear
            {
                //Making the Checkboxs and Sliders
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                static LaneClear()
                {
                    Menu.AddGroupLabel("LaneClear");
                    _useQ = Menu.Add("LaneClearUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("LaneClearUseW", new CheckBox("Use W", false));
                    _Mana = Menu.Add("LaneClearMana", new Slider("Dont harass under this amount of Mana ({1}%)", 30));
                }

                public static void Initialize()
                {
                }
            }
            public static class Harass
            {
                //Making the Checkboxs and Sliders
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    _useQ = Menu.Add("harassUseQ", new CheckBox("Use Q"));
                    _useW = Menu.Add("harassUseW", new CheckBox("Use W", false));
                    _useE = Menu.Add("harassUseE", new CheckBox("Use E"));
                    _Mana = Menu.Add("harassMana", new Slider("Dont harass under this amount of Mana ({1}%)", 30));
                }

                public static void Initialize()
                {
                }
            }
        }
        public static class Drawing
        {
            private static Menu Menu { get; set; }

            private static readonly CheckBox _drawQ;
            private static readonly CheckBox _drawW;
            private static readonly CheckBox _drawE;
            private static readonly CheckBox _drawR;

            public static bool DrawQ
            {
                get { return _drawQ.CurrentValue; }
            }
            public static bool DrawW
            {
                get { return _drawW.CurrentValue; }
            }
            public static bool DrawE
            {
                get { return _drawE.CurrentValue; }
            }
            public static bool DrawR
            {
                get { return _drawR.CurrentValue; }
            }

            static Drawing()
            {
                Menu = Config.Menu.AddSubMenu("Drawing");

                _drawQ = Menu.Add("drawQ", new CheckBox("Draw Q(Blue)", false));
                _drawW = Menu.Add("drawW", new CheckBox("Draw W(Purple)"));
                _drawE = Menu.Add("drawE", new CheckBox("Draw E(Green)"));
                _drawR = Menu.Add("drawR", new CheckBox("Draw R(Red)", false));
            }

            public static void Initialize()
            {
            }
        }
    }
}