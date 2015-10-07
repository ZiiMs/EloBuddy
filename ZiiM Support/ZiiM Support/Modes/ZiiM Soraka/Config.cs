using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ZiiM.Soraka
{
    public static class Config
    {
        private const string MenuName = "ZiiM's Soraka";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("ZiiM's Soraka!");
            Menu.AddLabel("Hope you enjoy!");
            Menu.AddSeparator();
            Menu.AddLabel("Created by: ZiiM");

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
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }

                static Combo()
                {
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Use Q"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                //Making the Checkboxs and Sliders
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;
                private static readonly Slider _Mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
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
                    _useE = Menu.Add("harassUseE", new CheckBox("Use E", false));
                    _Mana = Menu.Add("harassMana", new Slider("Dont harass under this amount of Mana ({1}%)", 30));
                }

                public static void Initialize()
                {
                }
            }
        }
        public static class Misc
        {
            private static Menu Menu;

            static Misc()
            {

                Menu = Config.Menu.AddSubMenu("Misc");

                AutoHeal.Initialize();
                Menu.AddSeparator();
                AutoUlt.Initialize();


            }
            public static void Initialize()
            {
            }

            public static class AutoHeal
            {
                private static readonly CheckBox _useW;
                private static readonly Slider _MinWHP;


                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static int MinWHP
                {
                    get { return _MinWHP.CurrentValue; }
                }
                static AutoHeal()
                {

                    Menu.AddGroupLabel("AutoHeal");
                    _useW = Menu.Add("AutoHealUseE", new CheckBox("AutoHeal"));
                    _MinWHP = Menu.Add("AutoHealHPBar", new Slider("Heal people below this amount of health ({0}%)", 10));

                }
                public static void Initialize()
                {
                }
            }
            public static class AutoUlt
            {
                private static readonly CheckBox _useR;
                private static readonly Slider _MinHP;


                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }
                public static int MinHP
                {
                    get { return _MinHP.CurrentValue; }
                }

                static AutoUlt()
                {

                    Menu.AddGroupLabel("AutoUlt");
                    _useR = Menu.Add("AutoUltUseR", new CheckBox("AutoUlt"));
                    _MinHP = Menu.Add("HPBar", new Slider("Ult people below this amount of health ({0}%)", 10));

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

            static Drawing()
            {
                Menu = Config.Menu.AddSubMenu("Drawing");

                _drawQ = Menu.Add("drawQ", new CheckBox("Draw Q(Blue)"));
                _drawW = Menu.Add("drawW", new CheckBox("Draw W(Purple)"));
                _drawE = Menu.Add("drawE", new CheckBox("Draw E(Green)"));
            }

            public static void Initialize()
            {
            }
        }
    }
}