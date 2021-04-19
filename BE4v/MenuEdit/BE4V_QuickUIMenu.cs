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

        public static void Start()
        {
            if (buttons != null) return;
            @menuname = "UIElementsMenu";
            buttons = new Dictionary<string, QuickButton>();
            toggler = new Dictionary<string, QuickToggler>();
            toggler.Add("FlyToggle", new QuickToggler(@menuname, 3, 0, "Fly hack", OnClick_FlyToggle, "off", "Toggle: Module Fly Hack"));
            buttons.Add("FlyType", new QuickButton(@menuname, 4, 0, "Fly Type:", OnClick_FlyType, "Toggle:"));
            toggler.Add("SHToggle", new QuickToggler(@menuname, 3, 1, "SpeedHack", OnClick_SHToggle, "off", "Toggle: Module SpeedHack"));
            toggler.Add("InfinityJump", new QuickToggler(@menuname, 2, 1, "Infinity Jump", OnClick_InfinityJumpToggle, "off", "Toggle: Module Infinity jump"));
            toggler.Add("InvisAPI", new QuickToggler(@menuname, -1, 0, "Invis API", OnClick_InvisAPIToggle, "off", "Toggle: Enabled module for offline mode"));
            
            /* * [ SET BACK BUTTON ] * */
            GameObject gameObject = QuickMenu.Instance.transform.Find("UIElementsMenu/BackButton").gameObject;
            var click = gameObject.GetComponent<Button>().onClick;
            gameObject.SetActive(false);
            buttons.Add("BackButton", new QuickButton("UIElementsMenu", 4, 2, "Back", nulled, "Go Back to the Quick Menu"));
            buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */
            
            OnClick_FlyToggle_Refresh();
            OnClick_FlyType_Refresh();
            OnClick_InfinityJumpToggle_Refresh();
            OnClick_InvisAPIToggle_Refresh();
            OnClick_SHToggle_Refresh();
        }

        private static void nulled()
        { }

        private static void OnClick_InfinityJumpToggle()
        {
            Mod_InfinityJump.Toggle();
        }
        
        public static void OnClick_InfinityJumpToggle_Refresh()
        {
            toggler["InfinityJump"].SetToggleToOn(Status.isInfinityJump);
        }
        
        private static void OnClick_InvisAPIToggle()
        {
            patch_InvisAPI.Toggle();
        }
        
        public static void OnClick_InvisAPIToggle_Refresh()
        {
            toggler["InvisAPI"].SetToggleToOn(Status.isInvisAPI);
        }
        
        private static void OnClick_FlyToggle()
        {
            Mod_Fly.Toggle();
        }

        public static void OnClick_FlyToggle_Refresh()
        {
            toggler["FlyToggle"].SetToggleToOn(Status.isFly);
            buttons["FlyType"].gameObject.SetActive(Status.isFly);
        }

        private static void OnClick_SHToggle()
        {
            Mod_SpeedHack.Toggle();
        }
        public static void OnClick_SHToggle_Refresh()
        {
            toggler["SHToggle"].SetToggleToOn(Status.isSpeedHack);
        }

        private static void OnClick_FlyType()
        {
            Mod_Fly.ToggleType();
        }

        public static void OnClick_FlyType_Refresh()
        {
            if (Status.isFlyType)
            {
                buttons["FlyType"].setToolTip("Toggle: Change type fly hack to Fly");
                buttons["FlyType"].setButtonText("Fly Type:\n<color=red>NoClip</color>");
                return;
            }
            buttons["FlyType"].setToolTip("Toggle: Change type fly hack to NoClip");
            buttons["FlyType"].setButtonText("Fly Type:\n<color=red>Fly</color>");
        }

        public static Dictionary<string, QuickButton> buttons;
        public static Dictionary<string, QuickToggler> toggler;
    }
}
