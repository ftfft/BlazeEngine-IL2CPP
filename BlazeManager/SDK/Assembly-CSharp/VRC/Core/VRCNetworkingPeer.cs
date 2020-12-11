using System;
using System.Linq;
using BlazeIL.il2cpp;
using IL2Photon.Realtime;

namespace VRC.Core
{
    public class VRCNetworkingPeer : IL2Base // LoadBalancingPeer
    {
        public VRCNetworkingPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static VRCNetworkingPeer Instance
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
                return field?.GetValue()?.unbox<VRCNetworkingPeer>();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().First(x => x.GetMethod("SendOutgoingCommands") != null);
    }
}