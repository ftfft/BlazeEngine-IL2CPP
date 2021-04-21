using BE4v.MenuEdit.Construct;
using BE4v.Mods;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using BE4v.Patch;

namespace BE4v.MenuEdit
{
    public static class BE4V_QuickUIMenu
    {
        private static string @menuname;
        public static Dictionary<string, QuickButton> buttons;
        public static Dictionary<string, QuickToggler> toggler;

        public static void Start()
        {
            if (buttons != null) return;
            @menuname = "UIElementsMenu";
            buttons = new Dictionary<string, QuickButton>();
            toggler = new Dictionary<string, QuickToggler>();
            toggler.Add("FlyToggle", new QuickToggler(@menuname, 3, 0, "Fly hack", ClickClass_FlyHack.OnClick_FlyToggle, "off", "Toggle: Module Fly Hack"));
            buttons.Add("FlyType", new QuickButton(@menuname, 4, 0, "Fly Type:", ClickClass_FlyHack.OnClick_FlyType, "Toggle:"));
            toggler.Add("SHToggle", new QuickToggler(@menuname, 3, 1, "SpeedHack", ClickClass_SpeedHack.OnClick_SHToggle, "off", "Toggle: Module SpeedHack"));
            /* * * * */
            buttons.Add("SHButtonPlus", new QuickButton(@menuname, 5, 0, "+++", ClickClass_SpeedHack.OnClick_SHButtonPlus, "Plus xMove for SpeedHack"));
            RectTransform rectTransform = buttons["SHButtonPlus"].gameObject.transform.MonoCast<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y / 2);
            buttons["SHButtonPlus"].MoveLocation(-1, 0.75f);
            /* * * * */
            buttons.Add("SHButtonMinus", new QuickButton(@menuname, 5, 0.5f, "---", ClickClass_SpeedHack.OnClick_SHButtonMinus, "Minus xMove for SpeedHack"));
            rectTransform = buttons["SHButtonMinus"].gameObject.transform.MonoCast<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y / 2);
            buttons["SHButtonMinus"].MoveLocation(-1, 0.75f);
            /* * * * */
            toggler.Add("InfinityJump", new QuickToggler(@menuname, 2, 1, "Infinity Jump", ClickClass_InfinityJump.OnClick_InfinityJumpToggle, "off", "Toggle: Module Infinity jump"));
            toggler.Add("InvisAPI", new QuickToggler(@menuname, -1, 0, "Invis API", ClickClass_InvisAPI.OnClick_InvisAPIToggle, "off", "Toggle: Enabled module for offline mode"));
            toggler.Add("Serilize", new QuickToggler(@menuname, -1, 1, "Serilize", ClickClass_Serilize.OnClick_SerilizeToggle, "off", "Toggle: Enabled module Serilize"));
            toggler.Add("FakePing", new QuickToggler(@menuname, 0, 2, "Fake Ping", ClickClass_FakePing.OnClick_FakePingToggle, "off", "Toggle: Enabled module Fake Ping (777)"));

            /* * [ SET BACK BUTTON ] * */
            GameObject gameObject = QuickMenu.Instance.transform.Find(@menuname + "/BackButton").gameObject;
            var click = gameObject.GetComponent<Button>().onClick;
            gameObject.SetActive(false);
            buttons.Add("BackButton", new QuickButton("UIElementsMenu", 4, 2, "Back", nulled, "Go Back to the Quick Menu"));
            buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */

            ClickClass_FlyHack.OnClick_FlyToggle_Refresh();
            ClickClass_FlyHack.OnClick_FlyType_Refresh();
            ClickClass_InfinityJump.OnClick_InfinityJumpToggle_Refresh();
            ClickClass_InvisAPI.OnClick_InvisAPIToggle_Refresh();
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
            ClickClass_Serilize.OnClick_SerilizeToggle_Refresh();
            ClickClass_FakePing.OnClick_FakePingToggle_Refresh();
        }

        private static void nulled()
        { }

    }

    public static class ClickClass_FakePing
    {
        public static void OnClick_FakePingToggle()
        {
            Patch_FakePing.Toggle();
        }

        public static void OnClick_FakePingToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["FakePing"].SetToggleToOn(Status.isFakePing);
            if (Status.isFakePing)
            {
                BE4V_QuickUIMenu.toggler["FakePing"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["FakePing"].setOffText("off");
            }
        }
    }
    public static class ClickClass_Serilize
    {
        public static void OnClick_SerilizeToggle()
        {
            Patch_Serilize.Toggle();
        }

        public static void OnClick_SerilizeToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["Serilize"].SetToggleToOn(Status.isSerilize);
            if (Status.isSerilize)
            {
                BE4V_QuickUIMenu.toggler["Serilize"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["Serilize"].setOffText("off");
            }
        }
    }
    

    public static class ClickClass_InfinityJump
    {
        public static void OnClick_InfinityJumpToggle()
        {
            Mod_InfinityJump.Toggle();
        }

        public static void OnClick_InfinityJumpToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["InfinityJump"].SetToggleToOn(Status.isInfinityJump);
            if (Status.isInfinityJump)
            {
                BE4V_QuickUIMenu.toggler["InfinityJump"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["InfinityJump"].setOffText("off");
            }
        }
    }

    public static class ClickClass_InvisAPI
    {
        public static void OnClick_InvisAPIToggle()
        {
            Patch_InvisAPI.Toggle();
        }

        public static void OnClick_InvisAPIToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["InvisAPI"].SetToggleToOn(Status.isInvisAPI);
            if (Status.isInvisAPI)
            {
                BE4V_QuickUIMenu.toggler["InvisAPI"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["InvisAPI"].setOffText("off");
            }
        }
    }

    public static class ClickClass_SpeedHack
    {
        public static void OnClick_SHButtonPlus()
        {
            Mod_SpeedHack.fSpeed++;
            OnClick_SHToggle_Refresh();
        }

        public static void OnClick_SHButtonMinus()
        {
            Mod_SpeedHack.fSpeed--;
            OnClick_SHToggle_Refresh();
        }

        public static void OnClick_SHToggle()
        {
            Mod_SpeedHack.Toggle();
        }
        public static void OnClick_SHToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["SHToggle"].SetToggleToOn(Status.isSpeedHack);
            BE4V_QuickUIMenu.buttons["SHButtonPlus"].gameObject.SetActive(Status.isSpeedHack);
            BE4V_QuickUIMenu.buttons["SHButtonMinus"].gameObject.SetActive(Status.isSpeedHack);
            if (Status.isSpeedHack)
            {
                BE4V_QuickUIMenu.toggler["SHToggle"].setOffText("x" + Mod_SpeedHack.fSpeed);
            }
            else
            {
                BE4V_QuickUIMenu.toggler["SHToggle"].setOffText("off");
            }
        }

    }

    public static class ClickClass_FlyHack
    {
        public static void OnClick_FlyToggle()
        {
            Mod_Fly.Toggle();
        }

        public static void OnClick_FlyToggle_Refresh()
        {
            BE4V_QuickUIMenu.toggler["FlyToggle"].SetToggleToOn(Status.isFly);
            if (Status.isFly)
            {
                BE4V_QuickUIMenu.toggler["FlyToggle"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["FlyToggle"].setOffText("off");
            }
            BE4V_QuickUIMenu.buttons["FlyType"].gameObject.SetActive(Status.isFly);
        }

        public static void OnClick_FlyType()
        {
            Mod_Fly.ToggleType();
        }

        public static void OnClick_FlyType_Refresh()
        {
            if (Status.isFlyType)
            {
                BE4V_QuickUIMenu.buttons["FlyType"].setToolTip("Toggle: Change type fly hack to Fly");
                BE4V_QuickUIMenu.buttons["FlyType"].setButtonText("Fly Type:\n<color=red>NoClip</color>");
                return;
            }
            BE4V_QuickUIMenu.buttons["FlyType"].setToolTip("Toggle: Change type fly hack to NoClip");
            BE4V_QuickUIMenu.buttons["FlyType"].setButtonText("Fly Type:\n<color=red>Fly</color>");
        }
    }
}
