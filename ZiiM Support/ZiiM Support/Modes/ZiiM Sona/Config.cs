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
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R", false));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                //Making the Checkboxs and Sliders
                private static readonly CheckBox _useQ;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                static Harass()
                {
                    Menu.AddGroupLabel("Harass");
                    _useQ = Menu.Add("harassUseQ", new CheckBox("Use Q", false));
                    _Mana = Menu.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                static LaneClear()
                {
                    //Label
                    Menu.AddGroupLabel("Lane Clear");

                    // UseQ for laneclear checkbox
                    _useQ = Menu.Add("LaneClearUseQ", new CheckBox("Use Q", false));

                    // Mana usage bar
                    _Mana = Menu.Add("LaneClearMana", new Slider("Maximum mana usage in percent ({0}%)", 90));
                }

                public static void Initialize()
                {
                }
            }
        }
        public static class Misc
        {
            private static Menu Menu;

            private static readonly CheckBox _useW;
            private static readonly CheckBox _Healself;
            private static readonly Slider _Mana;
            private static readonly Slider _MinHP;
            private static readonly Slider _Allies;


            public static bool UseW
            {
                get { return _useW.CurrentValue; }
            }
            public static bool HealSelf
            {
                get { return _Healself.CurrentValue; }
            }
            public static int Mana
            {
                get { return _Mana.CurrentValue; }
            }
            public static int MinHP
            {
                get { return _MinHP.CurrentValue; }
            }
            public static int Allies
            {
                get { return _Allies.CurrentValue; }
            }

            static Misc()
            {
                // Here is another option on how to use the menu, but I prefer the
                // way that I used in the combo class
                Menu = Config.Menu.AddSubMenu("Misc");

                Menu.AddGroupLabel("AutoHeal");
                _useW = Menu.Add("MiscUseW", new CheckBox("AutoHeal"));
                _Healself = Menu.Add("HealSelf", new CheckBox("Heal your self"));

                // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                // in the display name will replace it with 0=current 1=min and 2=max value
                _Mana = Menu.Add("AutoHealMana", new Slider("Dont use heal below this amount of Mana ({1}%)", 30));
                _MinHP = Menu.Add("HPBar", new Slider("Dont heal unless they are below this amount of health ({1}%)", 15));
                _Allies = Menu.Add("MinAllies", new Slider("Amount of allies in range before healing", 1, 1, 4));
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