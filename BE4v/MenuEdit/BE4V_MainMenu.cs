using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.Patch;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Menu;

namespace BE4v.MenuEdit
{
    public static class BE4V_MainMenu
    {
        public static ElementMenu registerMenu = null;

        public static void BlazeEngine4VersionMenu()
        {
            registerMenu = new ElementMenu(QuickMenuUtils.menuTemplate);
            ElementGroup elementGroup = new ElementGroup("Toggle's BE4v", registerMenu);
            GlowESP.button = new ElementButton("Toggle ESP", elementGroup, GlowESP.OnClick);
            GlowESP.Refresh();
            Serilize.button = new ElementButton("Serilize", elementGroup, Serilize.OnClick);
            Serilize.Refresh();
            new ElementButton("Remove Objects", elementGroup, UserUtils.RemoveInstiatorObjects).SetSprite(LoadSprites.trashIco);
            LocalMirror.button = new ElementButton("Portable Mirror", elementGroup, LocalMirror.OnClick);
            LocalMirror.Refresh();
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


        public static class GlowESP
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Mod_GlowESP.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isGlowESP)
                    {
                        button.SetSprite(LoadSprites.onButton);
                    }
                    else
                    {
                        button.SetSprite(LoadSprites.offButton);
                    }
                }

                foreach (var player in PlayerManager.Instance.PlayersCopy)
                {
                    player.OnNetworkReady();
                }
            }
        }

        public static class Serilize
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Patch_Serilize.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isSerilize)
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.onButton);

                    if (Patch_Serilize.patch?.Enabled == false)
                        Patch_Serilize.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.offButton);

                    if (Patch_Serilize.patch?.Enabled == true)
                        Patch_Serilize.patch.Enabled = false;
                }
            }
        }

        public static class LocalMirror
        {

            public static ElementButton button = null;

            public static void OnClick()
            {
                Mod_PortableMirror.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Mod_PortableMirror.gameObject != null)
                    {
                        button.SetSprite(LoadSprites.onButton);
                    }
                    else
                    {
                        button.SetSprite(LoadSprites.offButton);
                    }
                }
            }
        }
    }

    /*
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
    */
}
