using BE4v.Mods;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.Patch;
using BE4v.MenuEdit.Construct;
using QuickMenuElement.Elements;

namespace BE4v.MenuEdit
{
    public static class BE4V_SelectedMenu
    {
        public static MenuElement registerMenu = null;
        public static ButtonsElement buttonsGroupAvatars = null;

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

                ForceCloneAvatar.button._Sprite = ForceCloneAvatar.buttonOriginal._Sprite;;
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
                        Utils.Avatars.ChangeAvatar(avatar);
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
