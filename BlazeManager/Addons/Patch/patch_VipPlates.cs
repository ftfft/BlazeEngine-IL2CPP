using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using UnityEngine;
using UnityEngine.UI;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _VRC_Player_DispatchedUpdate(IntPtr instance, IntPtr fTimer);
    public static class patch_VipPlates
    {
        public static void Start()
        {
            IL2Method method = null;
            try
            {
                method = VRCPlayer.Instance_Class.GetMethods().First(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == "System.Single");
                if (method == null)
                    new Exception();

                var patch = IL2Ch.Patch(method, (_VRC_Player_DispatchedUpdate)VRC_Player_DispatchedUpdate);
                patch.CreateDelegate<_VRC_Player_DispatchedUpdate>();
                ConSole.Success("Patch: VipPlates");

            }
            catch
            {
                ConSole.Error("Patch: VipPlates");
            }
        }


        public static void VRC_Player_DispatchedUpdate(IntPtr instance, IntPtr fTimer)
        {
            if (instance == IntPtr.Zero || fTimer == IntPtr.Zero)
                return;

            _delegateVRC_Player_DispatchedUpdate.Invoke(instance, fTimer);

            VRCPlayer vrcPlayer = new VRCPlayer(instance);
            VRC.Core.APIUser apiuser = vrcPlayer?.player.apiuser;
            if (apiuser == null) return;

            SocialRank rank = VRCPlayer.GetSocialRank(apiuser);
            string textRank = string.Empty;
            if (rank == SocialRank.VRChatTeam)
                textRank = "Moderator";
            else if (rank == SocialRank.Legend)
                textRank = "Legend";
            else if (rank == SocialRank.VeteranUser)
                textRank = "Veteran";
            else if (rank == SocialRank.TrustedUser)
                textRank = "Trust";
            else if (rank == SocialRank.KnownUser)
                textRank = "Known";

            if (string.IsNullOrWhiteSpace(textRank)) return;
            VRCUiShadowPlate vipPlate = vrcPlayer.vipPlate;
            vipPlate.Show();
            vipPlate.mainText.text = textRank;
            vipPlate.dropShadow.text = textRank;
        }


        public static _VRC_Player_DispatchedUpdate _delegateVRC_Player_DispatchedUpdate;
    }
}
