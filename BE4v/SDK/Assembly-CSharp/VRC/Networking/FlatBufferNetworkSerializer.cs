using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.Networking
{
    public class FlatBufferNetworkSerializer : VRCNetworkBehaviour
    {
        public FlatBufferNetworkSerializer(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPlayerJoined") != null && x.GetMethod("OnNetworkReady") != null && x.BaseType == VRCNetworkBehaviour.Instance_Class);
    }
}