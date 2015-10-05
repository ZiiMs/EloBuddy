using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ZiiM.Sona
{
    public static class Config
    {
        private const string MenuName = "ZiiM's Sona";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("ZiiM's Sona!");
            Menu.AddLabel("Hope you enjoy!");
            Menu.AddLabel("Created by: ZiiM!!");

            // Initialize the modes
            Modes.Initialize();
            
            //Autoheal and others
            Misc.Initialize();
            
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
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useR;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false)); // Default false
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseQ", new CheckBox("Use Q", false));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
            public static class LaneClear
            {
                public static bool UseQ
                {
                    get { return Menu["LaneClearUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["LaneClearMana"].Cast<Slider>().CurrentValue; }
                }

                static LaneClear()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Lane Clear");
                    Menu.Add("LaneClearUseQ", new CheckBox("Use Q", false));

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("LaneClearMana", new Slider("Maximum mana usage in percent ({0}%)", 90));
                }

                public static void Initialize()
                {
                }
            }
        }
    public static class Misc
        {
            private static Menu Menu;

            public static bool UseW
            {
                get { return Menu["MiscUseW"].Cast<CheckBox>().CurrentValue; }
            }
            public static int Mana
            {
                get { return Menu["AutoHealMana"].Cast<Slider>().CurrentValue; }
            }
            public static int MinHP
            {
                get { return Menu["HPBar"].Cast<Slider>().CurrentValue; }
            }
            public static int Allies
            {
                get { return Menu["MinAllies"].Cast<Slider>().CurrentValue; }
            }

            static Misc()
            {
                // Here is another option on how to use the menu, but I prefer the
                // way that I used in the combo class
                Menu = Config.Menu.AddSubMenu("Misc");

                Menu.AddGroupLabel("AutoHeal");
                Menu.Add("MiscUseW", new CheckBox("AutoHeal"));

                // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                // in the display name will replace it with 0=current 1=min and 2=max value
                Menu.Add("AutoHealMana", new Slider("Minimum HP before using heal ({0}%)", 90));
                Menu.Add("HPBar", new Slider("Minimum HP before using heal ({0}%)", 10));
                Menu.Add("MinAllies", new Slider("Amount of allies in range", 3, 1, 5));
            }

            public static void Initialize()
            {
            }
        }
    public static class Drawing
        {
            private static Menu Menu { get; set; }

            private static readonly CheckBox _drawQ;
            private static readonly CheckBox _drawW;
            private static readonly CheckBox _drawE;
            private static readonly CheckBox _drawEleaving;
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

                _drawQ = Menu.Add("drawQ", new CheckBox("Draw Q(Blue)"));
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
