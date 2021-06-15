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
        public static string @menuname;
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

            /* Col -1 */
            toggler.Add("InvisAPI", new QuickToggler(@menuname, -1, 0, "Invis API", ClickClass_InvisAPI.OnClick_InvisAPIToggle, "off", "Toggle: Enabled module for offline mode"));
            toggler.Add("Serilize", new QuickToggler(@menuname, -1, 1, "Serilize", ClickClass_Serilize.OnClick_SerilizeToggle, "off", "Toggle: Enabled module Serilize"));
            toggler.Add("FakePing", new QuickToggler(@menuname, -1, 2, "Fake Ping", ClickClass_FakePing.OnClick_FakePingToggle, "off", "Toggle: Enabled module Fake Ping (777)"));
            /* * * * */

            toggler.Add("GlobalDynamicBones", new QuickToggler(@menuname, 2, 2, "Global\nDynamic Bones", ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones, "off", "Toggle: Enabled module Global Dynamic Bones"));
            toggler.Add("NoPortalJoin", new QuickToggler(@menuname, 3, 2, "No Portal Join", ClickClass_NoPortalJoin.OnClick_NoPortalJoin, "off", "Toggle: Enabled module No Portal Join"));

            /* * [ SET BACK BUTTON ] * */
            GameObject gameObject = QuickMenu.Instance.transform.Find(@menuname + "/BackButton").gameObject;
            var click = gameObject.GetComponent<Button>().onClick;
            gameObject.SetActive(false);
            buttons.Add("BackButton", new QuickButton(@menuname, 4, 2, "Back", null, "Go Back to the Quick Menu"));
            buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */

            ClickClass_FlyHack.OnClick_FlyToggle_Refresh();
            ClickClass_FlyHack.OnClick_FlyType_Refresh();
            ClickClass_InvisAPI.OnClick_InvisAPIToggle_Refresh();
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
            ClickClass_Serilize.OnClick_SerilizeToggle_Refresh();
            ClickClass_FakePing.OnClick_FakePingToggle_Refresh();
            ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones_Refresh();
            ClickClass_NoPortalJoin.OnClick_NoPortalJoin_Refresh();

            Image imgPrev = QuickMenu.Instance.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/PreviousArrow_Button").GetComponentInChildren<Image>();
            Image imgNext = QuickMenu.Instance.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponentInChildren<Image>();

            QuickButton button = new QuickButton(@menuname, -1, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_2, "Change to Prev menu");

            button.gameObject.GetComponentInChildren<Image>().sprite = imgPrev.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgPrev.material;
            button.gameObject.transform.localScale = new Vector3(-1, 1);

            button = new QuickButton(@menuname, 4, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_2, "Change to Next menu");
            button.gameObject.GetComponentInChildren<Image>().sprite = imgNext.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgNext.material;
        }
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
                if (!Patch_FakePing.patch.Enabled)
                    Patch_FakePing.patch.Enabled = true;
            }
            else
            {
                BE4V_QuickUIMenu.toggler["FakePing"].setOffText("off");
                if (Patch_FakePing.patch.Enabled)
                    Patch_FakePing.patch.Enabled = false;
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
                if (!Patch_Serilize.patch.Enabled)
                    Patch_Serilize.patch.Enabled = true;
            }
            else
            {
                BE4V_QuickUIMenu.toggler["Serilize"].setOffText("off");
                if (Patch_Serilize.patch.Enabled)
                    Patch_Serilize.patch.Enabled = false;
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
                if (!Patch_InvisAPI.patch.Enabled)
                    Patch_InvisAPI.patch.Enabled = true;
            }
            else
            {
                BE4V_QuickUIMenu.toggler["InvisAPI"].setOffText("off");
                if (Patch_InvisAPI.patch.Enabled)
                    Patch_InvisAPI.patch.Enabled = false;
            }
        }
    }
    
    public static class ClickClass_NoPortalJoin
    {
        public static void OnClick_NoPortalJoin()
        {
            Patch_NoPortalJoin.Toggle();
        }

        public static void OnClick_NoPortalJoin_Refresh()
        {
            BE4V_QuickUIMenu.toggler["NoPortalJoin"].SetToggleToOn(Status.isNoPortalJoin);
            if (Status.isNoPortalJoin)
            {
                BE4V_QuickUIMenu.toggler["NoPortalJoin"].setOffText("on");
                if (!Patch_NoPortalJoin.patch.Enabled)
                    Patch_NoPortalJoin.patch.Enabled = true;
            }
            else
            {
                BE4V_QuickUIMenu.toggler["NoPortalJoin"].setOffText("off");
                if (Patch_NoPortalJoin.patch.Enabled)
                    Patch_NoPortalJoin.patch.Enabled = false;
            }
        }
    }
    
    
    public static class ClickClass_GlobalDynamicBones
    {
        public static void OnClick_GlobalDynamicBones()
        {
            Patch_GlobalDynamicBones.Toggle();
        }

        public static void OnClick_GlobalDynamicBones_Refresh()
        {
            BE4V_QuickUIMenu.toggler["GlobalDynamicBones"].SetToggleToOn(Status.isGlobalDynamicBones);
            if (Status.isGlobalDynamicBones)
            {
                BE4V_QuickUIMenu.toggler["GlobalDynamicBones"].setOffText("on");
                if (!Patch_GlobalDynamicBones.patch.Enabled)
                    Patch_GlobalDynamicBones.patch.Enabled = true;
            }
            else
            {
                BE4V_QuickUIMenu.toggler["GlobalDynamicBones"].setOffText("off");
                if (Patch_GlobalDynamicBones.patch.Enabled)
                    Patch_GlobalDynamicBones.patch.Enabled = false;
            }
        }
    }

    public static class ClickClass_SpeedHack
    {
        public static void OnClick_SHButtonPlus()
        {
            if (Status.iSpeedHackSpeed < 100)
                Status.iSpeedHackSpeed++;
            OnClick_SHToggle_Refresh();
        }

        public static void OnClick_SHButtonMinus()
        {
            if (Status.iSpeedHackSpeed > 1)
                Status.iSpeedHackSpeed--;
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
                BE4V_QuickUIMenu.toggler["SHToggle"].setOffText("x" + Status.iSpeedHackSpeed);
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
