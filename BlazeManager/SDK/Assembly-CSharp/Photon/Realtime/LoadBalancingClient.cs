using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using IL2ExitGames.Client.Photon;
using IL2Photon.Pun;
using VRC.Core;

namespace IL2Photon.Realtime
{
    public class LoadBalancingClient : IL2Base
    {
        public LoadBalancingClient(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool OpRaiseEvent(byte eventCode, IntPtr customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Object result = Instance_Class.GetMethod(nameof(OpRaiseEvent))?.Invoke(ptr, new IntPtr[] { eventCode.MonoCast(), customEventContent, raiseEventOptions.ptr, sendOptions.MonoCast() });
            if (result == null)
                return default;
            return result.unbox_Unmanaged<bool>();
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass(VRCNetworkingClient.Instance_Class.BaseType.FullName);
    }
}