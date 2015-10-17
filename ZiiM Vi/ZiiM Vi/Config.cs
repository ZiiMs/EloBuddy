using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ZiiM.Vi
{
    public static class Config
    {
        private const string MenuName = "ZiiM's Vi";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("ZiiM's Vi!");
            Menu.AddLabel("Hope you enjoy!");
            Menu.AddSeparator();
            Menu.AddLabel("Created by: ZiiM");
            Menu.AddLabel("Damage Indicator Created by: Fluxy");


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

                // LaneClear
                LaneClear.Initialize();
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
                private static readonly CheckBox _useR;


                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
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
                    _useE = Menu.Add("comboUseE", new CheckBox("Use E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Use R"));
                }

                public static void Initialize()
                {
                }
            }
            public static class JungleClear
            {
                //Making the Checkboxs and Sliders
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

                static JungleClear()
                {
                    Menu.AddGroupLabel("JungleClear");
                    _useQ = Menu.Add("JungleClearUseQ", new CheckBox("Use Q"));
                    _useE = Menu.Add("JungleClearUseE", new CheckBox("Use E"));
                }

                public static void Initialize()
                {
                }
            }
            public static class LaneClear
            {
                //Making the Checkboxs and Sliders
                private static readonly CheckBox _useE;
                private static readonly Slider _Mana;
                private static readonly Slider _MinInQ;

                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int Mana
                {
                    get { return _Mana.CurrentValue; }
                }
                public static int MinInQ
                {
                    get { return _MinInQ.CurrentValue; }
                }

                static LaneClear()
                {
                    Menu.AddGroupLabel("LaneClear");
                    _useE = Menu.Add("LaneClearUseE", new CheckBox("Use E"));
                    _Mana = Menu.Add("LaneClearMana", new Slider("Dont LaneClear under this amount of Mana ({0}%)", 75));
                    _MinInQ = Menu.Add("LaneClearMinInQ", new Slider("Wont cast Q unless this many minions is in range ({0}%)", 3, 1, 10));
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
                    _useE = Menu.Add("harassUseE", new CheckBox("Use E"));
                    _Mana = Menu.Add("harassMana", new Slider("Dont harass under this amount of Mana ({0}%)", 30));
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

                AutoUlt.Initialize();
                Menu.AddSeparator();

            }
            public static void Initialize()
            {
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

                    _MinHP = Menu.Add("HPBar", new Slider("Ult people below this amount of health ({0}%)", 15));

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
            private static readonly CheckBox _DamageInd;

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
            public static bool DamageInd
            {
                get { return _DamageInd.CurrentValue; }
            }

            static Drawing()
            {
                Menu = Config.Menu.AddSubMenu("Drawing");

                _drawQ = Menu.Add("drawQ", new CheckBox("Draw Q(Blue)"));
                _drawW = Menu.Add("drawW", new CheckBox("Draw W(Purple)"));
                _drawE = Menu.Add("drawE", new CheckBox("Draw E(Green)"));
                _drawR = Menu.Add("drawR", new CheckBox("Draw R(Red)", false));
                _DamageInd = Menu.Add("drawDamageInd", new CheckBox("Damage Indicator"));
            }

            public static void Initialize()
            {
            }
        }
    }
}
