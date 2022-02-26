using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using IL2Photon.Realtime;

namespace VRC.Core
{
    public class VRCNetworkingPeer : LoadBalancingPeer
    {
        public VRCNetworkingPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static VRCNetworkingPeer Instance
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
                return field?.GetValue()?.GetValue<VRCNetworkingPeer>();
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("SendOutgoingCommands");
    }
}