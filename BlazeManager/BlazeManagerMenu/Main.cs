using System;
using System.Collections.Generic;
using VRC.Core;
using Addons.Mods;
using Addons.Patch;
using UnityEngine;
using UnityEngine.UI;
using Addons.Avatars;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class Main
    {
        /*
         * :: QuickMenu List ::
         * -> ShortcutMenu
         * -> UserInteractMenu
         * -> UIElementsMenu
         */
        internal static void CreateMenu()
        {
            QuickMenuStuff.CreateCustomMenu(new string[] {
                "UIElementsMenu2",
                "UIElementsMenu3",
                "UIElementsMenu4",
                "BlazeChangeColor"
            });

            Edit_QuickMenu_UIElementsMenu.Start();
            Edit_QuickMenu_ShortcutMenu.Start();

            #region UIElement
 
            togglerList.Add("GlobalDynamicBones", new QMToggleButton("UIElementsMenu", 3, 0, "Global\nDynamic Bones\non", patch_GlobalDynamicBones.Toggle_Enable, "off", "Toggle: Global Dynamic Bones"));
            patch_GlobalDynamicBones.RefreshStatus();
            togglerList.Add("Fly Enabled", new QMToggleButton("UIElementsMenu", 4, 0, "Fly on", FlyMode.Toggle_Enable, "Fly off", "Toggle: Fly mode"));
            togglerList.Add("Invis API", new QMToggleButton("UIElementsMenu", 1, 1, "InvisAPI on", patch_InvisAPI.Toggle_Enable, "off", "Toggle: Offline mode"));
            patch_InvisAPI.RefreshStatus();
            togglerList.Add("No Portal Join", new QMToggleButton("UIElementsMenu", 2, 1, "NoPortalJoin\non", patch_NoPortal.Toggle_Enable_Join, "off", "Toggle: Block join in portal"));
            patch_NoPortal.RefreshStatusJoin();
            togglerList.Add("AntiBlock", new QMToggleButton("UIElementsMenu", 3, 1, "AntiBlock\non", patch_AntiBlock.Toggle_Enable, "off", "Toggle: Show blocked players"));
            patch_AntiBlock.RefreshStatus();
            togglerList.Add("Photon Serilize", new QMToggleButton("UIElementsMenu", 1, 2, "Serilize on", patch_Network.Toggle_Enable_Serilize, "off", "Toggle: Photon Serilize"));
            patch_Network.RefreshStatus_Serilize();
            togglerList.Add("No Portal Spawn", new QMToggleButton("UIElementsMenu", 2, 2, "NoPortalSpawn\non", patch_NoPortal.Toggle_Enable_Spawn, "off", "Toggle: Auto-remove spawned portals"));
            patch_NoPortal.RefreshStatusSpawn();
            togglerList.Add("Fast Join", new QMToggleButton("UIElementsMenu", 3, 2, "Fast Join\non", patch_Network.Toggle_FastJoin, "off", "Toggle: Fast Join"));
            patch_Network.RefreshStatus_FastJoin();
            togglerList.Add("Fly Mode", new QMToggleButton("UIElementsMenu", 4, 1, "Fly:\nDirectional", FlyMode.Toggle_Mode, "Fly: Default", "Toggle: NoClip / Fly"));
            FlyMode.RefreshStatus();
            togglerList.Add("Infinity Jump", new QMToggleButton("UIElementsMenu", 4, 2, "Infinity\nJump", InfinityJump.Toggle_Enable, "disabled", "Toggle: Infinity jump"));
            #endregion

            #region UIElement4
            togglerList.Add("Force Mute Friend", new QMToggleButton("UIElementsMenu2", 1, 0, "Force Mute Friend\non", patch_ForceMute.Toggle_Enable_ForceMute, "off", "Toggle: Force Mute Friend"));
            patch_ForceMute.RefreshStatus_ForceMute_Friends();
            #endregion

            #region UIElement4
            togglerList.Add("RPC Block", new QMToggleButton("UIElementsMenu4", 1, 0, "RPC Block\non", patch_EventManager.Toggle_Enable, "off", "Toggle: RPC Block"));
            patch_EventManager.RefreshStatus();
            togglerList.Add("Hide Pickup", new QMToggleButton("UIElementsMenu4", 2, 0, "Hide Pickup\non", NoLocalPickup.Toggle_Enable, "off", "Toggle: Hide all pickup objects"));
            NoLocalPickup.RefreshStatus();
            togglerList.Add("Steam Spoof", new QMToggleButton("UIElementsMenu4", 3, 0, "Steam Spoof\non", patch_Network.Toggle_SteamSpoof, "off", "Toggle: Steam Spoofer"));
            patch_Network.RefreshStatus_SteamSpoof();
            togglerList.Add("VoiceDotFade", new QMToggleButton("UIElementsMenu4", 4, 0, "Voice Fade\non", VoiceDotFade.Toggle_Enable, "off", "Toggle: Effect voice fade"));
            VoiceDotFade.RefreshStatus();
            togglerList.Add("NoMove", new QMToggleButton("UIElementsMenu4", 1, 1, "No Move Players\non", patch_Network.Toggle_Enable_NoMove, "off", "Toggle: RPC Block"));
            patch_Network.RefreshStatus_NoMove();
            togglerList.Add("DeathMap", new QMToggleButton("UIElementsMenu4", 4, 2, "DeathMap", patch_Network.Toggle_Enable_DeathMap, "disabled", "Toggle: Close connect to map"));
            patch_Network.RefreshStatus_DeathMap();
            #endregion

            new QMSingleButton("ShortcutMenu", 0, 0, "Remove\nDynamic Objects", () =>
            {
                Addons.UserUtils.RemoveInstiatorObjects();
            }, "");

            togglerList.Add("ESP Capsule", new QMToggleButton("ShortcutMenu", 0, 1, "ESP Capsule\non", patch_AntiBlock.Toggle_Enable_ESP_Capsule, "off", "Toggle: ESP Capsule"));

            singleList.Add("LocalMirror", new QMSingleButton("ShortcutMenu", 5, 0, "SpawnMirror", () =>
            {
                if (PortableMirror._isEnable)
                    PortableMirror.OnDestroy();
                else
                    PortableMirror.OnCreate();
            }, ""));
            PortableMirror.UpdateStatus();

            new QMSingleButton("ShortcutMenu", 5, 1, "Spawn\nFlashlight", () =>
            {
                Addons.UserUtils.SpawnDynLight(VRC.Player.Instance.transform);
            }, "Spawn flashlight (Local).");

            new QMSingleButton("ShortcutMenu", 5, 2, "Select\nyourself", () =>
            {
                QuickTools.SelectUserAPI(VRC.Player.Instance.apiuser);
            }, "Select yourself.");


            singleList.Add("ClonePublicAvatar", new QMSingleButton("UserInteractMenu", 5, 0, "Clone\nPublic\nAvatar", () => { }, "Clone User Avatar"));
            Transform button = QuickTools.quickTransform.Find("UserInteractMenu/CloneAvatarButton");
            var clickEvent = button.GetComponent<Button>().onClick;
            button.GetComponentInChildren<Text>().text = "";
            singleList["ClonePublicAvatar"].gameObject.GetComponent<Button>().onClick = clickEvent;

            new QMSingleButton("UserInteractMenu", 6, 0, "<color=red>Download\n.vrca</color>", () =>
            {
                ApiAvatar apiAvatar = UnityEngine.Object.FindObjectOfType<UserInteractMenu>()?.menuController?.activeAvatar;
                if (apiAvatar != null)
                {
                    string url = apiAvatar.assetUrl;
                    if (AvatarStatus.IsValidUrl(url))
                        AvatarStatus.OpenUrlBrowser(url);
                    return;
                }
            }, "Open browse for download .vrca");
            togglerList.Add("Force Mute", new QMToggleButton("UserInteractMenu", 4, 2, "ForceMute\non", patch_ForceMute.OnPlayerToggleForceMute, "off", "Toggle: Force Mute"));

            // new Quaternion(0, 0, 45, 0) - верх ногами
            // new QMLineButton("ShortcutMenu", -1.1f, -1, "Test Player", () => { Console.WriteLine("temp_player"); }, "Test", new Quaternion(0, -15, -5, 45));
            // new QMLineButton("ShortcutMenu", 6.1f, -1, "Test Player 2", () => { Console.WriteLine("temp_player"); }, "Test", new Quaternion(0, 15, 5, 45));

            QuickMenuStuff.ChangeColorMenu(Color.green, Color.white);
            QuickMenuStuff.ChangeColorButtons(Color.green, Color.green);
        }

        internal static Dictionary<string, QMToggleButton> togglerList = new Dictionary<string, QMToggleButton>();
        internal static Dictionary<string, QMSingleButton> singleList = new Dictionary<string, QMSingleButton>();
    }
}
