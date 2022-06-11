using System;
using System.Linq;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using IL2Photon.Pun;
using SharpDisasm.Udis86;

namespace BE4v.Patch.List
{
    public class OnMasterClientSwitched : IPatch
    {
        public delegate void _OnMasterClientSwitched(IntPtr instance, IntPtr newMasterClient);

        public void Start()
        {
            IL2Method method = NetworkManager.Instance_Class.GetMethod("OnMasterClientSwitched");
            if (method != null)
            {
                patch = new IL2Patch(method, (_OnMasterClientSwitched)___OnMasterClientSwitched);
                __OnMasterClientSwitched = patch.CreateDelegate<_OnMasterClientSwitched>();
            }
            else
                throw new NullReferenceException();
        }

        public static void ___OnMasterClientSwitched(IntPtr instance, IntPtr newMasterClient)
        {
            if (instance == IntPtr.Zero)
                return;
            IL2Photon.Realtime.Player player = new IL2Photon.Realtime.Player(newMasterClient);
            VRC.PlayerManager.MasterId = player.ActorNumber;
            ("New master Instance: " + VRC.PlayerManager.MasterId).RedPrefix("Debug");
            __OnMasterClientSwitched(instance, newMasterClient);
        }

        public static IL2Patch patch;

        public static _OnMasterClientSwitched __OnMasterClientSwitched;
    }
}
