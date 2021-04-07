using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.MenuEdit.Construct;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Patch
{
    public delegate void _UserInteractMenu_Update(IntPtr instance);
    public static class Patch_ForceCloneAvatar
    {
        public static void Start()
        {
            IL2Method method = null;
            try
            {
                method = UserInteractMenu.Instance_Class.GetMethod("Update");
                if (method == null)
                    new Exception();

                IL2Patch patch = new IL2Patch(method, (_UserInteractMenu_Update)UserInteractMenu_Update);
                _delegateUserInteractMenu_Update = patch.CreateDelegate<_UserInteractMenu_Update>();
                "Force Clone Avatar".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Force Clone Avatar".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void UserInteractMenu_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            _delegateUserInteractMenu_Update.Invoke(instance);
            
            var __instance = new UserInteractMenu(instance);
            var menuController = __instance.menuController;
            if (menuController == null)
                return;

            var activeAvatar = menuController.activeAvatar;
            var activeUser = menuController.activeUser;
            if (activeAvatar == null
            || activeUser == null)
            {
                userId = string.Empty;
                return;
            }

            if (cloneAvatarButton == null)
            {
                Transform transform = QuickMenu_Utils.UserInteractMenu.buttonCloneAvatar;

                if (transform == null)
                {
                    Console.WriteLine("CloneAvatarButton: Not found");
                    return;
                }
                cloneAvatarButton = new QuickButton(transform.gameObject);
                if (cloneAvatarButton == null)
                    return;
            }
            bool nonPublicRelease = activeAvatar.releaseStatus != "public";
            if (nonPublicRelease
            || activeUser.allowAvatarCopying)
            {
                if (nonPublicRelease) userId = string.Empty;
                if (userId != activeUser.id)
                {
                    cloneAvatarButton.setButtonText("Clone\nPublic\nAvatar");
                }
            }
            else
            {
                userId = activeUser.id;
                activeUser.allowAvatarCopying = true;
                cloneAvatarButton.gameObject.GetComponent<Button>().interactable = true;
                cloneAvatarButton.setButtonText("Clone\nAvatar");
            }
        }

        private static string userId = string.Empty;

        private static QuickButton cloneAvatarButton = null;

        private static _UserInteractMenu_Update _delegateUserInteractMenu_Update = null;
    }
}
