using System;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;
using System.Linq;
using VRC.UI;
using VRC.Core;
using UnityEngine;

namespace BE4v.Patch
{
    public delegate void _VRC_UI_PageUserInfo_SetUserRelationshipState(IntPtr instance, IntPtr friendType);
    public static class Patch_Event_OnShowProfile
    {
        public static void Start()
        {
            try
            {
                IL2Method method = PageUserInfo.Instance_Class?.GetMethods(x => x.GetParameters().Length == 1).First(x => x.GetParameters()[0].ReturnType.Name.StartsWith(x.ReflectedType.FullName + "."));
                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_VRC_UI_PageUserInfo_SetUserRelationshipState)VRC_UI_PageUserInfo_SetUserRelationshipState);
                _delegateVRC_UI_PageUserInfo_SetUserRelationshipState = patch.CreateDelegate<_VRC_UI_PageUserInfo_SetUserRelationshipState>();
                "[Event] PUI State (Patch)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "[Event] PUI State (Patch)".RedPrefix(TMessage.BadPatch);
            }
        }
        public static void VRC_UI_PageUserInfo_SetUserRelationshipState(IntPtr instance, IntPtr friendType)
        {
            _delegateVRC_UI_PageUserInfo_SetUserRelationshipState.Invoke(instance, friendType);
            APIUser user = PageUserInfo.Instance?.user;
            if (user == null) return;
            StatusUserButtons(user);
        }

        private static void StatusUserButtons(APIUser user)
        {
            if (user.id == APIUser.CurrentUser.id
            || string.IsNullOrEmpty(user.location)
            || user.location == "private"
            || user.location == "offline")
            {
                // CloneAvatar.SetActive(false);
                BE4V_UserPanel.UserDropPortal.gameObject.SetActive(false);
                return;
            }
            // CloneAvatar.SetActive(true);
            BE4V_UserPanel.UserDropPortal.gameObject.SetActive(true);
        }


        public static IL2Patch patch;

        public static _VRC_UI_PageUserInfo_SetUserRelationshipState _delegateVRC_UI_PageUserInfo_SetUserRelationshipState;
    }
}
