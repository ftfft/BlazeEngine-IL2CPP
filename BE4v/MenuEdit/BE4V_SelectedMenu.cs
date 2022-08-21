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
    public static class BE4V_SelectedMenu
    {
        public static ElementMenu registerMenu = null;
        public static ElementGroup elementGroup = null;
        public static ElementButton buttonRemoveObjects = null;

        public static void BlazeEngine4VersionMenu()
        {
            if (registerMenu == null)
                registerMenu = new ElementMenu(QuickMenuUtils.selectedMenuTemplate);

            if (elementGroup == null)
                elementGroup = new ElementGroup(registerMenu.verticalLayoutGroup.transform.Find("Buttons_AvatarActions").gameObject);

            // ScrollRect/Viewport/VerticalLayoutGroup/Buttons_AvatarActions/Button_CloneAvatar

            if (ForceCloneAvatar.button == null)
            {
                ForceCloneAvatar.button = new ElementButton("ForceCloneAvatar", elementGroup, ForceCloneAvatar.OnClick);

                ForceCloneAvatar.buttonOriginal = new ElementButton(elementGroup.gameObject.transform.Find("Button_CloneAvatar").gameObject);
                ForceCloneAvatar.buttonOriginal.gameObject.SetActive(false);
                
                ForceCloneAvatar.button.SetSprite(ForceCloneAvatar.buttonOriginal.GetSprite());
            }
        }

        public static class ForceCloneAvatar
        {
            public static ElementButton button = null;
            public static ElementButton buttonOriginal = null;

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
                                button.SetText("Clone Avatar");
                            }
                            else
                            {
                                button.SetText("Force Clone Avatar");
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
