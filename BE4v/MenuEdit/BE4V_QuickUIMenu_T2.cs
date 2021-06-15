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
    public static class BE4V_QuickUIMenu_T2
    {
        public static string @menuname;
        public static Dictionary<string, QuickButton> buttons;
        public static Dictionary<string, QuickToggler> toggler;

        public static void Start()
        {
            if (buttons != null) return;
            @menuname = "UIElementsMenu_T2";
            QuickMenu_Utils.CreateQuickMenu(@menuname);
            buttons = new Dictionary<string, QuickButton>();
            toggler = new Dictionary<string, QuickToggler>();
            /* * [ Col -1 ] * */
            toggler.Add("RPCBlock", new QuickToggler(@menuname, -1, 1, "RPC Block", ClickClass_InfinityJump.OnClick_InfinityJumpToggle, "off", "Toggle: Module RPC Block"));
            /* * * * ** * * * */

            /* * [ Col 4 ] * */
            toggler.Add("InfinityJump", new QuickToggler(@menuname, 4, 0, "Infinity Jump", ClickClass_InfinityJump.OnClick_InfinityJumpToggle, "off", "Toggle: Module Infinity jump"));
            toggler.Add("AntiBlock", new QuickToggler(@menuname, 4, 1, "Anti Block", ClickClass_AntiBlock.OnClick_AntiBlockToggle, "off", "Toggle: Enabled module Anti-Block\nShow blocked users"));
            /* * * * * * * * */

            /* * [ SET BACK BUTTON ] * */
            GameObject gameObject = QuickMenu.Instance.transform.Find(BE4V_QuickUIMenu.@menuname + "/BackButton").gameObject;
            var click = gameObject.GetComponent<Button>().onClick;
            gameObject.SetActive(false);
            buttons.Add("BackButton", new QuickButton(@menuname, 4, 2, "Back", null, "Go Back to the Quick Menu"));
            buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */
            /*
            ClickClass_FlyHack.OnClick_FlyToggle_Refresh();
            ClickClass_FlyHack.OnClick_FlyType_Refresh();
            ClickClass_InfinityJump.OnClick_InfinityJumpToggle_Refresh();
            ClickClass_InvisAPI.OnClick_InvisAPIToggle_Refresh();
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
            ClickClass_Serilize.OnClick_SerilizeToggle_Refresh();
            ClickClass_FakePing.OnClick_FakePingToggle_Refresh();
            ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones_Refresh();
            ClickClass_NoPortalJoin.OnClick_NoPortalJoin_Refresh();
            ClickClass_AntiBlock.OnClick_AntiBlockToggle_Refresh();
            */

            ClickClass_InfinityJump.OnClick_InfinityJumpToggle_Refresh();
            ClickClass_AntiBlock.OnClick_AntiBlockToggle_Refresh();

            Image imgPrev = QuickMenu.Instance.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/PreviousArrow_Button").GetComponentInChildren<Image>();
            Image imgNext = QuickMenu.Instance.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponentInChildren<Image>();

            QuickButton button = new QuickButton(@menuname, -1, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_1, "Change to Prev menu");

            button.gameObject.GetComponentInChildren<Image>().sprite = imgPrev.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgPrev.material;
            button.gameObject.transform.localScale = new Vector3(-1, 1);

            button = new QuickButton(@menuname, 4, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_1, "Change to Next menu");
            button.gameObject.GetComponentInChildren<Image>().sprite = imgNext.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgNext.material;
        }
    }


    public static class ClickClass_AntiBlock
    {
        public static void OnClick_AntiBlockToggle()
        {
            Patch_AntiBlock.Toggle();
        }

        public static void OnClick_AntiBlockToggle_Refresh()
        {
            BE4V_QuickUIMenu_T2.toggler["AntiBlock"].SetToggleToOn(Status.isAntiBlock);
            if (Status.isAntiBlock)
            {
                foreach (var player in VRC.PlayerManager.Instance.PlayersCopy)
                {
                    player.Components?.RefreshState();
                }
                BE4V_QuickUIMenu_T2.toggler["AntiBlock"].setOffText("on");
                //if (!Patch_AntiBlock.patch.Enabled)
                //    Patch_AntiBlock.patch.Enabled = true;
            }
            else
            {
                foreach (var player in VRC.PlayerManager.Instance.PlayersCopy)
                {
                    player.OnNetworkReady();
                }
                BE4V_QuickUIMenu_T2.toggler["AntiBlock"].setOffText("off");
                //if (Patch_AntiBlock.patch.Enabled)
                //    Patch_AntiBlock.patch.Enabled = false;
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
            BE4V_QuickUIMenu_T2.toggler["InfinityJump"].SetToggleToOn(Status.isInfinityJump);
            if (Status.isInfinityJump)
            {
                BE4V_QuickUIMenu_T2.toggler["InfinityJump"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu_T2.toggler["InfinityJump"].setOffText("off");
            }
        }
    }

}
