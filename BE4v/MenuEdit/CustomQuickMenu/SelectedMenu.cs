using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.Patch;
using BE4v.Mods.Min;
using BE4v.MenuEdit.Construct;
using QuickMenuElement.Elements;
using BE4v.Utils;

namespace CustomQuickMenu.Menus
{
    public static class SelectedMenu
    {
        public static MenuElement registerMenu = null;
        public static ButtonsElement buttonsGroupAvatars = null;
        public static ButtonsElement buttonsGroupBE4v_1 = null;
        public static ButtonsElement buttonsGroupUserActions = null;
        public static ButtonsElement buttonsGroupDevTools = null;

        public static void BlazeEngine4VersionMenu()
        {
            if (registerMenu == null)
            {
                registerMenu = new MenuElement();
                registerMenu.gameObject = QuickMenuUtils.selectedMenuTemplate.gameObject;
            }

            if (buttonsGroupAvatars == null)
            {
                buttonsGroupAvatars = new ButtonsElement();
                buttonsGroupAvatars.gameObject = registerMenu.verticalLayoutGroup.transform.Find("Buttons_AvatarActions").gameObject;
            }

            if (ForceCloneAvatar.button == null)
            {
                ForceCloneAvatar.button = buttonsGroupAvatars.AddButton("ForceCloneAvatar", ForceCloneAvatar.OnClick);

                ForceCloneAvatar.buttonOriginal = buttonsGroupAvatars["CloneAvatar"];
                ForceCloneAvatar.buttonOriginal.gameObject.SetActive(false);

                ForceCloneAvatar.button._Sprite = ForceCloneAvatar.buttonOriginal._Sprite;
            }

            if (buttonsGroupUserActions == null)
            {
                buttonsGroupUserActions = new ButtonsElement();
                buttonsGroupUserActions.gameObject = registerMenu.verticalLayoutGroup.transform.Find("Buttons_UserActions").gameObject;
                // buttonsGroupUserActions["GiftVRCPlus"].gameObject.Destroy();
            }
            

            if (buttonsGroupDevTools == null)
            {
                buttonsGroupDevTools = new ButtonsElement();
                buttonsGroupDevTools.gameObject = registerMenu.verticalLayoutGroup.transform.Find("Buttons_DevTools").gameObject;
            }
            registerMenu.AddHeader("BE4v Buttons").gameObject.transform.SetSiblingIndex(1);
            buttonsGroupBE4v_1 = registerMenu.AddButtonsGroup("BE4v_1");
            buttonsGroupBE4v_1.gameObject.transform.SetSiblingIndex(2);
            try
            {
                if (TeleportToPlayer.button == null)
                {
                    TeleportToPlayer.button = buttonsGroupBE4v_1.AddButton("Teleport", TeleportToPlayer.OnClick);
                    TeleportToPlayer.button._Sprite = buttonsGroupDevTools["TeleportTo"]._Sprite;
                }
            }
            catch { }
            try
            {
                if (SitOnHeadToggle.button == null)
                {
                    SitOnHeadToggle.button = buttonsGroupBE4v_1.AddButton("Sit On", SitOnHeadToggle.OnClick);
                    SitOnHeadToggle.button._Sprite = LoadSprites.sitonIco;
                }
            }
            catch { }

            try
            {
                if (DownloadVRCA.button == null)
                {
                    DownloadVRCA.button = buttonsGroupBE4v_1.AddButton("Download VRCA", DownloadVRCA.OnClick);
                    // DownloadVRCA.button._Sprite = LoadSprites.sitonIco;
                }
            }
            catch { }
        }

        public static class TeleportToPlayer
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                string displayName = UserUtils.QM_GetSelectedUserName();
                if (!string.IsNullOrEmpty(displayName))
                {
                    Player selectedPlayer = UserUtils.GetPlayerByName(displayName);
                    if (selectedPlayer != null)
                    {
                        VRC.Player.Instance.transform.position = selectedPlayer.transform.position;
                    }
                }
            }
        }

        public static class SitOnHeadToggle
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                string displayName = UserUtils.QM_GetSelectedUserName();
                if (!string.IsNullOrEmpty(displayName))
                {
                    VRCPlayer selectedPlayer = UserUtils.GetPlayerByName(displayName)?.Components;
                    if (selectedPlayer != null)
                    {
                        if (SitOnHead.SelectUser != selectedPlayer)
                            SitOnHead.SelectUser = selectedPlayer;
                        else
                            SitOnHead.SelectUser = null;
                    }
                }
            }
        }
        
        public static class DownloadVRCA
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                string displayName = UserUtils.QM_GetSelectedUserName();
                if (!string.IsNullOrEmpty(displayName))
                {
                    Player selectedPlayer = UserUtils.GetPlayerByName(displayName);
                    var avatar = selectedPlayer?.Components?.AvatarModel;
                    if (avatar != null)
                    {
                        string url = avatar.assetUrl;
                        if (Avatars.IsValidUrl(url))
                            Avatars.OpenUrlBrowser(url);
                    }
                }
            }
        }

        public static class ForceCloneAvatar
        {
            public static QMButton button = null;
            public static QMButton buttonOriginal = null;

            public static void OnClick()
            {
                if (button == null) return;
                string displayName = UserUtils.QM_GetSelectedUserName();
                if (!string.IsNullOrEmpty(displayName))
                {
                    Player selectedPlayer = UserUtils.GetPlayerByName(displayName);
                    var avatar = selectedPlayer?.Components?.AvatarModel;
                    if (avatar != null)
                    {
                        BE4v.Utils.Avatars.ChangeAvatar(avatar);
                    }
                }
            }

            public static void Update()
            {
                if (button == null) return;
                if (buttonOriginal == null) return;
                string displayName = UserUtils.QM_GetSelectedUserName();
                if (!string.IsNullOrEmpty(displayName))
                {
                    Player selectedPlayer = UserUtils.GetPlayerByName(displayName);
                    if (selectedPlayer != null)
                    {
                        if (selectedPlayer.Components.AvatarModel.releaseStatus == "public")
                        {
                            button.gameObject.SetActive(true);
                            buttonOriginal.gameObject.SetActive(false);
                            if (selectedPlayer.user.allowAvatarCopying)
                            {
                                button._Text = "Clone Avatar";
                            }
                            else
                            {
                                button._Text = "Force Clone Avatar";
                            }
                        }
                        else
                        {
                            button.gameObject.SetActive(false);
                            buttonOriginal.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
