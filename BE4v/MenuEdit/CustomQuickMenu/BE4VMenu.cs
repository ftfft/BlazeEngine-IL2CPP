using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.Core;
using BE4v.Patch.List;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using QuickMenuElement.Elements;
using BE4v.Utils;

namespace CustomQuickMenu.Menus
{
    public static class BE4VMenu
    {
        public static MenuElement registerMenu = null;

        public static void BlazeEngine4VersionMenu()
        {
            registerMenu = MenuElement.Create("BlazeEngine4Version");
            
            new ElementHorizontalButton("BlazeEngine4Version", delegate () { registerMenu.Open(); }).SetSprite(LoadSprites.be4vLogo);

            registerMenu.AddHeader("Networking Tools");
            ButtonsElement butttonsGroup = registerMenu.AddButtonsGroup("Networking Tools");
            // InvisAPI.button = new ElementButton("Invis API", elementGroup, InvisAPI.OnClick);
            // InvisAPI.Refresh();
            //RPCBlock.button = butttonsGroup.AddButton("RPC Block", RPCBlock.OnClick);
            //RPCBlock.Refresh();
            FakePing.button = butttonsGroup.AddButton("Fake Ping", FakePing.OnClick);
            FakePing.Refresh();
            //AutoClearRAM.button = butttonsGroup.AddButton("AutoClear RAM", AutoClearRAM.OnClick);
            //AutoClearRAM.Refresh();
            SendAvatarData.button = butttonsGroup.AddButton("Send Avatars Data", SendAvatarData.OnClick);
            SendAvatarData.Refresh();
            //DeathMap.button = butttonsGroup.AddButton("Death Map", DeathMap.OnClick);
            //DeathMap.Refresh();

            registerMenu.AddHeader("Movement Tools");
            butttonsGroup = registerMenu.AddButtonsGroup("Movement Tools");
            FlyType.button = butttonsGroup.AddButton("Fly Type", FlyType.OnClick);
            FlyType.Refresh();
            InfinityJump.button = butttonsGroup.AddButton("JetPack", InfinityJump.OnClick);
            InfinityJump.Refresh();
            BunnyHop.button = butttonsGroup.AddButton("BunnyHop", BunnyHop.OnClick);
            BunnyHop.Refresh();
            ForceJump.button = butttonsGroup.AddButton("ForceJump", ForceJump.OnClick);


            registerMenu.AddHeader("ESP Tools");
            butttonsGroup = registerMenu.AddButtonsGroup("ESP Tools");
            ESP_Nameplates.button = butttonsGroup.AddButton("ESP Nameplates", ESP_Nameplates.OnClick);
            ESP_Nameplates.Refresh();
            // GlobalUdonEvent.button = new ElementButton("Global Udon Events", elementGroup, GlobalUdonEvent.OnClick);
            // GlobalUdonEvent.Refresh();

            // elementGroup = new ElementGroup("First Test GRoup 3", registerMenu);
            // ConsoleLog.button = new ElementButton("Log Events", elementGroup, ConsoleLog.OnClick);
            // ConsoleLog.Refresh();
        }

        public static class RPCBlock
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        public static class FlyType
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                FlyHack.ToggleType();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFlyType)
                    {
                        button._Text = "<color=red>NoClip</color>\nFly Type:";
                    }
                    else
                    {
                        button._Text = "<color=red>FlyHack</color>\nFly Type:";
                    }
                }
            }
        }

        public static class InvisAPI
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.InvisAPI.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isInvisAPI)
                {
                    if (button != null)
                        button._Sprite = LoadSprites.onButton;

                    if (BE4v.Patch.List.InvisAPI.patch?.Enabled == false)
                        BE4v.Patch.List.InvisAPI.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button._Sprite = LoadSprites.offButton;

                    if (BE4v.Patch.List.InvisAPI.patch?.Enabled == true)
                        BE4v.Patch.List.InvisAPI.patch.Enabled = false;
                }
            }
        }

        public static class FakePing
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.FakePing.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFakePing)
                    {
                        button._Sprite = LoadSprites.onButton;

                        if (BE4v.Patch.List.FakePing.patch?.Enabled == false)
                            BE4v.Patch.List.FakePing.patch.Enabled = true;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;

                        if (BE4v.Patch.List.FakePing.patch?.Enabled == true)
                            BE4v.Patch.List.FakePing.patch.Enabled = false;
                    }
                }
            }
        }

        public static class DeathMap
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        public static class AutoClearRAM
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        public static class InfinityJump
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        
        public static class BunnyHop
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        public static class ForceJump
        {
            public static QMButton button = null;
            public static void OnClick()
            {
                VRCPlayer player = VRCPlayer.Instance;
                if (player == null) return;
                if (player.GetComponent<PlayerModComponentJump>() != null) return;
                player.gameObject.AddComponent<PlayerModComponentJump>();
            }
        }
        
        public static class GlobalUdonEvent
        {
            public static QMButton button = null;

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
                        button._Sprite = LoadSprites.onButton;

                        foreach (var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == false)
                                patch.Enabled = true;
                        }
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;

                        foreach(var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == true)
                                patch.Enabled = false;
                        }
                    }
                }
            }
        }

        public static class ESP_Nameplates
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isNameplatesESP = !Status.isNameplatesESP;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isNameplatesESP)
                    {
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }

                VRC.Player localPlayer = VRC.Player.Instance;
                if (localPlayer != null)
                {
                    Threads.UpdatePlayers();
                    foreach (var player in NetworkSanity.NetworkSanity.players)
                    {
                        if (player == localPlayer) continue;
                        ESPUtils.ESP_ForPlayer(player);
                    }
                }
            }
        }
        public static class ConsoleLog
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isLog = !Status.isLog;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isLog)
                    {
                        button._Sprite = LoadSprites.onButton;

                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }

        public static class SendAvatarData
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.SendAvatarData = !Status.SendAvatarData;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.SendAvatarData)
                    {
                        button._Sprite = LoadSprites.onButton;

                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }

    }
}