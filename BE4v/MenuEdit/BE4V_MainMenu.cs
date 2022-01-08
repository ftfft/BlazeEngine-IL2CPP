using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
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
        public static ElementMenu mainMenu = null;

        public static ElementGroup groupMainMenu = null;

        public static ElementButton buttonToggleESP = null;

        public static ElementButton buttonRPCBlock = null;

        public static ElementButton buttonPortableMirror = null;

        public static ElementMenu registerMenu = null;

        public static ElementGroup registerGroupMenu = null;

        public static ElementButton toggleFlyType = null;

        public static ElementHorizontalButton elem = null;

        public static void BlazeEngine4VersionMenu()
        {
            mainMenu = new ElementMenu(QuickMenuUtils.menuTemplate);
            groupMainMenu = new ElementGroup("Toggle's BE4v", mainMenu);
            buttonToggleESP = new ElementButton("Toggle ESP", groupMainMenu, ClickClass_GlowESP.OnClick_GlowESP);
            ClickClass_GlowESP.OnClick_GlowESP_Refresh();
            buttonRPCBlock = new ElementButton("RPC Block", groupMainMenu, ClickClass_RPCBlock.OnClick_RPCBlockToggle);
            ClickClass_RPCBlock.OnClick_RPCBlockToggle_Refresh();
            new ElementButton("Toggle Fly Type 3", groupMainMenu, delegate () { Mod_Fly.ToggleType(); });
            buttonPortableMirror = new ElementButton("Portable Mirror", groupMainMenu, ClickClass_LocalMirror.OnClick_PortableMirror);
            ClickClass_LocalMirror.OnClick_PortableMirror_Refresh();


            registerMenu = new ElementMenu("BlazeEngine4Version");
            elem = new ElementHorizontalButton("BlazeEngine4Version", delegate () { registerMenu.Open(); });

            elem.SetSprite(LoadSprites.be4vLogo);

            registerGroupMenu = new ElementGroup("First Test GRoup 1", registerMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });

            registerGroupMenu = new ElementGroup("First Test GRoup 3", registerMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });

            registerGroupMenu = new ElementGroup("First Test GRoup 3", registerMenu);
            new ElementButton("Toggle Fly Type", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", registerGroupMenu, delegate () { Mod_Fly.ToggleType(); });
        }

        public static void Delete()
        {
            Transform menu = QuickMenu.Instance.transform;
            Transform transform = menu.Find("Container/Window/Toggle_SafeMode");
            if (transform != null)
                transform.gameObject.Destroy();

            transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/VRC+_Banners");
            if (transform != null)
                transform.gameObject.Destroy();

            transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners");
            if (transform != null)
                transform.gameObject.Destroy();

            "QuickMenu element's".RedPrefix("Destroy");
        }

        public static void Start()
        {
            // new QuickButton("ShortcutMenu", -1, 0, "Remove\nCreated\nObjects", UserUtils.RemoveInstiatorObjects, "Clear all portals, created object's on map");
            // new QuickButton("ShortcutMenu", 4, -1, "Open GUI\nBE4v", ClickClass_OpenGUI.Click, "Open GUI Window for Cheat Client");
            // ClickClass_GlowESP.quickTogglerGlowESP = new QuickToggler("ShortcutMenu", -1, 1, "Glow ESP", ClickClass_GlowESP.OnClick_GlowESP, "Off", "Toggle mod Glow ESP");
            // ClickClass_LocalMirror.quickButtonLocalMirror = new QuickButton("ShortcutMenu", 4, 0, "Mrr", ClickClass_LocalMirror.OnClick_PortableMirror, "");
            // ClickClass_GAIN.quickTogglerGAIN = new QuickToggler("ShortcutMenu", 4, 1, "GAIN", ClickClass_GAIN.ButtonToggle, "Off", "Toggle ::: GAIN MODE :::");
            // BE4V_QuickUIMenu.Start();
            // BE4V_QuickUIMenu_T2.Start();
            ClickClass_GlowESP.OnClick_GlowESP_Refresh();
            ClickClass_LocalMirror.OnClick_PortableMirror_Refresh();
            ClickClass_OpenGUI.UpdateStatus();
        }

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

        // public static QuickToggler quickTogglerGAIN;
    }

    public static class ClickClass_LocalMirror
    {
        public static void OnClick_PortableMirror()
        {
            Mod_PortableMirror.Toggle();
        }

        public static void OnClick_PortableMirror_Refresh()
        {
            if (BE4V_MainMenu.buttonPortableMirror != null)
            {
                if (Mod_PortableMirror.gameObject != null)
                {
                    BE4V_MainMenu.buttonPortableMirror.SetSprite(LoadSprites.onButton);
                }
                else
                {
                    BE4V_MainMenu.buttonPortableMirror.SetSprite(LoadSprites.offButton);
                }
            }
        }

        //public static QuickButton quickButtonLocalMirror;
    }

    public static class ClickClass_GlowESP
    {
        public static void OnClick_GlowESP()
        {
            Mod_GlowESP.Toggle();
        }

        public static void OnClick_GlowESP_Refresh()
        {
            if (BE4V_MainMenu.buttonToggleESP != null)
            {
                if (Status.isGlowESP)
                {
                    BE4V_MainMenu.buttonToggleESP.SetSprite(LoadSprites.onButton);
                }
                else
                {
                    BE4V_MainMenu.buttonToggleESP.SetSprite(LoadSprites.offButton);
                }
            }

            foreach (var player in PlayerManager.Instance.PlayersCopy)
            {
                player.OnNetworkReady();
            }
        }
    }

    public static class ClickClass_RPCBlock
    {
        public static void OnClick_RPCBlockToggle()
        {
            Status.isRPCBlock = !Status.isRPCBlock;
            OnClick_RPCBlockToggle_Refresh();
        }

        public static void OnClick_RPCBlockToggle_Refresh()
        {
            if (BE4V_MainMenu.buttonRPCBlock != null)
            {
                if (Status.isRPCBlock)
                {
                    BE4V_MainMenu.buttonRPCBlock.SetSprite(LoadSprites.onButton);
                }
                else
                {
                    BE4V_MainMenu.buttonRPCBlock.SetSprite(LoadSprites.offButton);
                }
            }
        }
    }
}
