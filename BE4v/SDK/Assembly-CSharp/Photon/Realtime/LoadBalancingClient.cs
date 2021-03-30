using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;
using VRC.Core;


namespace IL2Photon.Realtime
{
    public class LoadBalancingClient : IL2Base
    {
        public LoadBalancingClient(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        /*
        public bool OpRaiseEvent(byte eventCode, IntPtr customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Object result = Instance_Class.GetMethod(nameof(OpRaiseEvent))?.Invoke(ptr, new IntPtr[] { eventCode.MonoCast(), customEventContent, raiseEventOptions.ptr, sendOptions.MonoCast() });
            if (result == null)
                return default;
            return result.GetValuе<bool>();
        }
        */
        public static IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRCNetworkingClient.Instance_Class.BaseType.FullName);
    }
}