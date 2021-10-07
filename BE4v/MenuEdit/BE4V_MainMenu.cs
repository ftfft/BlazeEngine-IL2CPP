using BE4v.MenuEdit.Construct;
using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using UnityEngine;
using VRC;

namespace BE4v.MenuEdit
{
    public static class BE4V_MainMenu
    {
        public static void Delete()
        {

            foreach (Transform transform in QuickMenu.Instance.transform)
            {
                //Console.WriteLine(transform.gameObject.name);
                switch (transform.gameObject.name)
                {
                    case "NotificationInteractMenu": continue;
                    case "EmoteMenu": goto case "be4v_destroy";
                    case "ModerationMenu": goto case "be4v_destroy";
                    case "UserIconMenu": goto case "be4v_destroy";
                    case "UserIconCameraMenu": goto case "be4v_destroy";
                    case "be4v_destroy":
                        {
                            UnityEngine.Object.Destroy(transform.gameObject);
                            break;
                        }
                }
                foreach (Transform transform1 in transform)
                { 
                    switch (transform1.gameObject.name)
                    {
                        case "EmoteButton": goto case "be4v_destroy";
                        case "UserIconButton": goto case "be4v_destroy";
                        case "UserIconCameraButton": goto case "be4v_destroy";
                        case "CustomizeNameplateButton": goto case "be4v_destroy";
                        case "HeaderContainer":
                            {
                                foreach (Transform transform2 in transform1)
                                {
                                    if (transform2.gameObject.name == "VRCPlusBanner")
                                        UnityEngine.Object.Destroy(transform2.gameObject);
                                }
                                break;
                            }
                        case "VRCPlusThankYou": goto case "be4v_destroy";
                        case "VRCPlusMiniBanner": goto case "be4v_destroy";
                        case "ReportWorldButton": goto case "be4v_destroy";
                        case "DevToolsButton": goto case "be4v_destroy";
                        case "GalleryButton": goto case "be4v_destroy";
                        case "be4v_destroy":
                            {
                                UnityEngine.Object.Destroy(transform1.gameObject);
                                break;
                            }
                        case "SitButton":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(1, 0);
                                break;
                            }
                        case "CalibrateButton":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(1, 0);
                                break;
                            }
                        case "SettingsButton":
                            {
                                QuickButton quickButton = new QuickButton(transform1.gameObject);
                                quickButton.MoveLocation(-1, 0);
                                break;
                            }
                        case "EmojiButton":
                            {
                                QuickButton quickButton = new QuickButton(transform1.gameObject);
                                quickButton.MoveLocation(-1, 0);
                                break;
                            }
                        case "QMInfoToggle":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(-2, 2);
                                break;
                            }
                        case "Toggle_States_ShowTrustRank_Colors":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(-1, 0);
                                break;
                            }
                    }
                }
            }
            FileDebug.debugGameObject("QuickMenu", QuickMenu.Instance.gameObject);
            "QuickMenu element's".RedPrefix("Destroy");
        }

        public static void Start()
        {
            new QuickButton("ShortcutMenu", -1, 0, "Remove\nCreated\nObjects", UserUtils.RemoveInstiatorObjects, "Clear all portals, created object's on map");
            // new QuickButton("ShortcutMenu", 4, -1, "Open GUI\nBE4v", ClickClass_OpenGUI.Click, "Open GUI Window for Cheat Client");
            ClickClass_GlowESP.quickTogglerGlowESP = new QuickToggler("ShortcutMenu", -1, 1, "Glow ESP", ClickClass_GlowESP.OnClick_GlowESP, "Off", "Toggle mod Glow ESP");
            ClickClass_LocalMirror.quickButtonLocalMirror = new QuickButton("ShortcutMenu", 4, 0, "Mrr", ClickClass_LocalMirror.OnClick_PortableMirror, "");
            // ClickClass_GAIN.quickTogglerGAIN = new QuickToggler("ShortcutMenu", 4, 1, "GAIN", ClickClass_GAIN.ButtonToggle, "Off", "Toggle ::: GAIN MODE :::");
            BE4V_QuickUIMenu.Start();
            BE4V_QuickUIMenu_T2.Start();
            ClickClass_GlowESP.OnClick_GlowESP_Refresh();
            ClickClass_LocalMirror.OnClick_PortableMirror_Refresh();
            ClickClass_OpenGUI.UpdateStatus();
        }

    }



    public static class MSGClass_QuickMenu
    {
        public static string pathPrevArrow = "QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/PreviousArrow_Button";

        public static string pathNextArrow = "QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button";

        public static string msgBackButton_name = "Back";

        public static string msgBackButton_ToolTip = "Go Back to the Quick Menu";

    }



    public static class ClickClass_OpenGUI
    {
        public static void Click()
        {
            DumpForm form = new DumpForm();
            form.Show();
            form.Activate();
        }

        public static void UpdateStatus()
        {

        }

        public static bool isEnabled = false;
    }
    public static class ClickClass_GAIN
    {
        public static void ButtonToggle()
        {
            
        }

        public static QuickToggler quickTogglerGAIN;
    }
    
    public static class ClickClass_ChangeMenu
    {
        public static void To_UIElementsMenu_1()
        {
            QuickMenu_Utils.ShowQuickmenuPage(BE4V_QuickUIMenu.menuname);
        }
        public static void To_UIElementsMenu_2()
        {
            QuickMenu_Utils.ShowQuickmenuPage(BE4V_QuickUIMenu_T2.menuname);
        }
    }

    public static class ClickClass_LocalMirror
    {
        public static void OnClick_PortableMirror()
        {
            Mod_PortableMirror.Toggle();
        }

        public static void OnClick_PortableMirror_Refresh()
        {
            if (Mod_PortableMirror.gameObject != null)
            {
                quickButtonLocalMirror.setButtonText("<color=red>Remove</color>\nLocal Mirror");
                quickButtonLocalMirror.setToolTip("Remove Portable Mirror (Local)");
                return;
            }
            quickButtonLocalMirror.setButtonText("<color=green>Create</color>\nLocal Mirror");
            quickButtonLocalMirror.setToolTip("Create Portable Mirror (Local)");
        }

        public static QuickButton quickButtonLocalMirror;
    }

    public static class ClickClass_GlowESP
    {
        public static void OnClick_GlowESP()
        {
            Mod_GlowESP.Toggle();
        }

        public static void OnClick_GlowESP_Refresh()
        {
            quickTogglerGlowESP.SetToggleToOn(Status.isGlowESP);
            foreach(var player in PlayerManager.Instance.PlayersCopy)
            {
                // player.Components?.RefreshState();
            }
        }

        public static QuickToggler quickTogglerGlowESP;
    }
}
