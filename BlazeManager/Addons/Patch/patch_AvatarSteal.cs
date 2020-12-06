using System;
using System.Threading;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine;
using UnityEngine.UI;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _UserInteractMenu_Update(IntPtr instance);
    public static class patch_AvatarSteal
    {
        public static void Start()
        {
            IL2Method method = null;
            try
            {
                method = UserInteractMenu.Instance_Class.GetMethod("Update");
                if (method == null)
                    new Exception();

                IL2Ch.Patch(method, (_UserInteractMenu_Update)UserInteractMenu_Update);
                ConSole.Success("Patch: Avatar Stealer");

            }
            catch
            {
                ConSole.Error("Patch: Avatar Stealer");
            }
        }

        public static void UserInteractMenu_Update(IntPtr ptrInstance)
        {
            if (ptrInstance == IntPtr.Zero)
                return;

            // pAvatarStealer.InvokeOriginal(ptrInstance, new IntPtr[0]);

            var __instance = new UserInteractMenu(ptrInstance);
            var menuController = __instance.menuController;
            if (menuController == null)
                return;

            var activeAvatar = menuController.activeAvatar;
            var activeUser = menuController.activeUser;
            if (activeAvatar == null
            || activeUser == null)
                return;

            __instance.cloneAvatarButton.gameObject.SetActive(false);
            if (activeAvatar.releaseStatus != "public"
            || activeUser.allowAvatarCopying)
            {
                if (sUserId != activeUser.id)
                {
                    BlazeManagerMenu.Main.singleList["ClonePublicAvatar"].setTextColor(Color.white);
                }
            }
            else
            {
                sUserId = activeUser.id;
                activeUser.allowAvatarCopying = true;
                __instance.cloneAvatarButton.interactable = true;
                BlazeManagerMenu.Main.singleList["ClonePublicAvatar"].setTextColor(Color.red);
            }
            BlazeManagerMenu.Main.singleList["ClonePublicAvatar"].gameObject.GetComponent<Button>().interactable = __instance.cloneAvatarButton.interactable;
            // patch_ForceMute.OnUpdateToggleForceMute();
        }

        private static string sUserId = string.Empty;
    }
}
