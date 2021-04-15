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
            buttons.Add("FlyToggle", new QuickButton("UIElementsMenu", 0, 2, "Fly:", OnClick_FlyToggle, "Toggle:"));
            buttons.Add("FlyType", new QuickButton("UIElementsMenu", 1, 2, "Fly Type:", OnClick_FlyType, "Toggle:"));
            toggler.Add("InfinityJump", new QuickToggler("UIElementsMenu", 2, 1, "Infinity Jump", OnClick_InfinityJumpToggle, "off", "Toggle: Module Infinity jump"));
            toggler.Add("InvisAPI", new QuickToggler("UIElementsMenu", -1, 0, "Invis API", OnClick_InvisAPIToggle, "off", "Toggle: Enabled module for offline mode"));
            
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
            if (Status.isFly)
            {
                buttons["FlyToggle"].setToolTip("Toggle: Disable fly hack");
                buttons["FlyToggle"].setButtonText("Fly:\n<color=red>On</color>");
                buttons["FlyType"].gameObject.SetActive(true);
                return;
            }
            buttons["FlyToggle"].setToolTip("Toggle: Enable fly hack");
            buttons["FlyToggle"].setButtonText("Fly:\n<color=red>Off</color>");
            buttons["FlyType"].gameObject.SetActive(false);
        }

        private static void OnClick_FlyType()
        {
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
