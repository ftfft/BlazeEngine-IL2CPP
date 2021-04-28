using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.Networking
{
    public class FlatBufferNetworkSerializer : VRCNetworkBehaviour
    {
        public FlatBufferNetworkSerializer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPlayerJoined") != null && x.GetMethod("OnNetworkReady") != null && x.BaseType?.FullName == VRCNetworkBehaviour.Instance_Class.FullName);
    }
}