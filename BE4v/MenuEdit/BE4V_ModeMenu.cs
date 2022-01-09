using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.Patch;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using BE4v.MenuEdit.Construct.Menu;

namespace BE4v.MenuEdit
{
    public static class BE4V_ModeMenu
    {
        public static ElementMenu registerMenu = null;

        public static void BlazeEngine4VersionMenu()
        {
            registerMenu = new ElementMenu("BlazeEngine4Version");
            new ElementHorizontalButton("BlazeEngine4Version", delegate () { registerMenu.Open(); }).SetSprite(LoadSprites.be4vLogo);

            ElementGroup elementGroup = new ElementGroup("Networking Tools", registerMenu);
            InvisAPI.button = new ElementButton("Invis API", elementGroup, InvisAPI.OnClick);
            InvisAPI.Refresh();
            RPCBlock.button = new ElementButton("RPC Block", elementGroup, RPCBlock.OnClick);
            RPCBlock.Refresh();
            FakePing.button = new ElementButton("Fake Ping", elementGroup, FakePing.OnClick);
            FakePing.Refresh();
            DeathMap.button = new ElementButton("Death Map", elementGroup, DeathMap.OnClick);
            DeathMap.Refresh();

            elementGroup = new ElementGroup("First Test GRoup 3", registerMenu);
            new ElementButton("Toggle Fly Type", elementGroup, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", elementGroup, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", elementGroup, delegate () { Mod_Fly.ToggleType(); });

            elementGroup = new ElementGroup("First Test GRoup 3", registerMenu);
            new ElementButton("Toggle Fly Type", elementGroup, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", elementGroup, delegate () { Mod_Fly.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", elementGroup, delegate () { Mod_Fly.ToggleType(); });
        }

        public static class RPCBlock
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isRPCBlock = !Status.isRPCBlock;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isRPCBlock)
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

        public static class InvisAPI
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Patch_InvisAPI.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isInvisAPI)
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.onButton);

                    if (Patch_InvisAPI.patch?.Enabled == false)
                        Patch_InvisAPI.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.offButton);

                    if (Patch_InvisAPI.patch?.Enabled == true)
                        Patch_InvisAPI.patch.Enabled = false;
                }
            }
        }

        public static class FakePing
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Patch_FakePing.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isRPCBlock)
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

        public static class DeathMap
        {
            public static ElementButton button = null;

            public static bool isEnabled = false;

            public static void OnClick()
            {
                isEnabled = !isEnabled;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (isEnabled)
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
}