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
        public static ElementGroup elementGroup = null;
        public static ElementButton buttonRemoveObjects = null;

        public static bool BlazeEngine4VersionMenu()
        {
            if (registerMenu == null)
            {
                registerMenu = new ElementMenu(QuickMenuUtils.menuTemplate);
                return false;
            }
            if (elementGroup == null)
            {
                elementGroup = new ElementGroup("Toggle's BE4v", registerMenu);
                return false;
            }
            if (GlowESP.button == null)
            {
                GlowESP.button = new ElementButton("Toggle ESP", elementGroup, GlowESP.OnClick);
                GlowESP.Refresh();
                return false;
            }
            if (Serilize.button == null)
            {
                Serilize.button = new ElementButton("Serilize", elementGroup, Serilize.OnClick);
                Serilize.Refresh();
                return false;
            }
            if (buttonRemoveObjects == null)
            {
                buttonRemoveObjects = new ElementButton("Remove Objects", elementGroup, UserUtils.RemoveInstiatorObjects);
                buttonRemoveObjects.SetSprite(LoadSprites.trashIco);
                return false;
            }
            if (LocalMirror.button == null)
            {
                LocalMirror.button = new ElementButton("Portable Mirror", elementGroup, LocalMirror.OnClick);
                LocalMirror.Refresh();
                return false;
            }
            return true;
        }

        public static class GlowESP
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isGlowESP = !Status.isGlowESP;
                Refresh();
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

                VRC.Player localPlayer = VRC.Player.Instance;
                if (localPlayer != null)
                {
                    foreach (var player in PlayerManager.Instance.PlayersCopy)
                    {
                        if (player == localPlayer) continue;
                        Patch.List.OnPlayerUpdateSync.ESPUpdate(player);
                    }
                }
            }
        }

        public static class Serilize
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Patch.List.Serilize.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isSerilize)
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.onButton);

                    if (Patch.List.Serilize.patch?.Enabled == false)
                        Patch.List.Serilize.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.offButton);

                    if (Patch.List.Serilize.patch?.Enabled == true)
                        Patch.List.Serilize.patch.Enabled = false;
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
