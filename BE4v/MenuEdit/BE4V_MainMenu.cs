﻿using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using BE4v.MenuEdit.Construct.Menu;

namespace BE4v.MenuEdit
{
    public static class BE4V_MainMenu
    {
        public static ElementMenu registerMenu = null;

        public static ElementButtonGroup registerGroupMenu = null;

        public static ElementButton toggleFlyType = null;

        public static void BlazeEngine4VersionMenu()
        {
            registerMenu = new ElementMenu("BlazeEngine4Version");
            new ElementHorizontalButton("BlazeEngine4Version", delegate () { registerMenu.Open(); });
            
            registerGroupMenu = new ElementButtonGroup("First Test GRoup", registerMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });

            registerGroupMenu = new ElementButtonGroup("First Test GRoup 2", registerGroupMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });

            registerGroupMenu = new ElementButtonGroup("First Test GRoup 3", registerGroupMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
        }

        public static void Delete()
        {
            Transform menu = QuickMenu.Instance.transform;
            Transform toggle_safeMode = menu.Find("Container/Window/Toggle_SafeMode");
            if (toggle_safeMode != null)
                toggle_safeMode.gameObject.Destroy();

            // Transform transform = menu.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard");
            /*
            // Items:
            // - Container
            foreach(Transform menuTransform in menu)
            {
                // Items:
                // Menu Collider
                // Back Window
                // ThankYouCharacter
                // Window
                foreach (Transform containerTransform in menuTransform)
                {
                    if (containerTransform.name == "Window")
                    {

                        foreach (Transform windowTransform in containerTransform)
                        {
                            if (windowTransform.name == "Toggle_SafeMode")
                                windowTransform.gameObject.Destroy();
                        }
                    }
                }
            }
            */

            //            if (transform != null)
            //                transform.gameObject.SetActive(false);
            /*
            menu.Find("ThankYouCharacter").Destroy();
            var submenu = menu.Find("VRC+_Banners");
            while (submenu != null)
            {
                submenu?.Destroy();
                submenu = menu.Find("VRC+_Banners");
            }
            */
            // FileDebug.debugGameObject("QuickMenu", QuickMenu.Instance.gameObject);
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
