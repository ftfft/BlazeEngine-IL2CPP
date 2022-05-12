using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.Core;
using BE4v.Patch.List;
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

            elementGroup = new ElementGroup("Other tools", registerMenu);
            AutoClearRAM.button = new ElementButton("AutoClear RAM", elementGroup, delegate () { AutoClearRAM.OnClick(); });
            AutoClearRAM.Refresh();
            InfinityJump.button = new ElementButton("Infinity Jump", elementGroup, delegate () { InfinityJump.OnClick(); });
            InfinityJump.Refresh();
            BunnyHop.button = new ElementButton("BunnyHop", elementGroup, delegate () { BunnyHop.OnClick(); });
            BunnyHop.Refresh();
            GlobalUdonEvent.button = new ElementButton("Global Udon Events", elementGroup, GlobalUdonEvent.OnClick);
            GlobalUdonEvent.Refresh();

            elementGroup = new ElementGroup("First Test GRoup 3", registerMenu);
            new ElementButton("Toggle Fly Type", elementGroup, delegate () { FlyHack.ToggleType(); });
            new ElementButton("Toggle Fly Type 2", elementGroup, delegate () { FlyHack.ToggleType(); });
            new ElementButton("Toggle Fly Type 3", elementGroup, delegate () { FlyHack.ToggleType(); });
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
                Patch.List.InvisAPI.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isInvisAPI)
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.onButton);

                    if (Patch.List.InvisAPI.patch?.Enabled == false)
                        Patch.List.InvisAPI.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button.SetSprite(LoadSprites.offButton);

                    if (Patch.List.InvisAPI.patch?.Enabled == true)
                        Patch.List.InvisAPI.patch.Enabled = false;
                }
            }
        }

        public static class FakePing
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Patch.List.FakePing.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFakePing)
                    {
                        button.SetSprite(LoadSprites.onButton);

                        if (Patch.List.FakePing.patch?.Enabled == false)
                            Patch.List.FakePing.patch.Enabled = true;
                    }
                    else
                    {
                        button.SetSprite(LoadSprites.offButton);

                        if (Patch.List.FakePing.patch?.Enabled == true)
                            Patch.List.FakePing.patch.Enabled = false;
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
        
        public static class AutoClearRAM
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isAutoClear = !Status.isAutoClear;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isAutoClear)
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
        
        public static class InfinityJump
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isInfinityJump = !Status.isInfinityJump;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isInfinityJump)
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
        
        
        public static class BunnyHop
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isBHop = !Status.isBHop;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isBHop)
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
        
        public static class GlobalUdonEvent
        {
            public static ElementButton button = null;

            public static void OnClick()
            {
                Status.isGlobalUdonEvent = !Status.isGlobalUdonEvent;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isGlobalUdonEvent)
                    {
                        button.SetSprite(LoadSprites.onButton);

                        foreach (var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == false)
                                patch.Enabled = true;
                        }
                    }
                    else
                    {
                        button.SetSprite(LoadSprites.offButton);

                        foreach(var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == true)
                                patch.Enabled = false;
                        }
                    }
                }
            }
        }

    }
}