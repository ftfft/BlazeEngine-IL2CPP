using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using VRC.Core;

namespace Addons.Patch
{
    public delegate bool _USpeakPhotonSender_ForceMute(IntPtr instance, IntPtr pPlayer);
    public class patch_ForceMute
    {
        public static void OnPlayerToggleForceMute()
        {
            APIUser apiUser = UnityEngine.Object.FindObjectOfType<UserInteractMenu>()?.menuController?.activeUser;
            if (apiUser == null) return;

            if (forceMuteList.Contains(apiUser.id))
                forceMuteList.Remove(apiUser.id);
            else
                forceMuteList.Add(apiUser.id);
            OnUpdateToggleForceMute();
        }

        public static void OnUpdateToggleForceMute()
        {
            APIUser apiUser = UnityEngine.Object.FindObjectOfType<UserInteractMenu>()?.menuController?.activeUser;
            if (apiUser == null) return;

            bool toggle = forceMuteList.Contains(apiUser.id);
            BlazeManagerMenu.Main.togglerList["Force Mute"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Force Mute"].btnOff.SetActive(!toggle);
        }

        public static void Toggle_Enable_ForceMute()
        {
            BlazeManager.SetForPlayer("Force Mute Friend", !BlazeManager.GetForPlayer<bool>("Force Mute Friend"));
            RefreshStatus_ForceMute_Friends();
        }

        public static void RefreshStatus_ForceMute_Friends()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Force Mute Friend");
            BlazeManagerMenu.Main.togglerList["Force Mute Friend"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Force Mute Friend"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                foreach(var method in USpeakPhotonSender3D.Instance_Class.GetMethods(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName && x.ReturnType.Name == "System.Boolean"))
                    IL2Ch.Patch(method, (_USpeakPhotonSender_ForceMute)USpeakPhotonSender_ForceMute);
                ConSole.Success("Patch: ForceMute");
            }
            catch
            {
                ConSole.Error("Patch: ForceMute");
            }
        }

        public static bool USpeakPhotonSender_ForceMute(IntPtr instance, IntPtr pPlayer)
        {
            if (pPlayer == IntPtr.Zero) return true;
            VRC.Player player = new VRC.Player(pPlayer);
            if (player == VRC.Player.Instance) return false;
            IL2String userid = new IL2String(player.userId_Pointer);
            if (userid.ptr == IntPtr.Zero) return true;
            if (BlazeManager.GetForPlayer<bool>("Force Mute Friend"))
            {
                if (!APIUser.IsFriendsWith(userid.ptr)) return true;
            }
            // if (ModerationManager.Instance.IsBlockedEitherWay(userid.ptr)) return true;
            if (UserUtils.kos_list.Contains(userid.ToString())) return true;
            return forceMuteList.Contains(userid.ToString());
        }

        public static List<string> forceMuteList = new List<string>();
    }
}
