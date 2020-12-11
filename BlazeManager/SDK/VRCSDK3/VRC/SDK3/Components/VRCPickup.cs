using System;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.SDK3.Components
{
    public class VRCPickup : Component
    {
        public VRCPickup(IntPtr ptr) : base(ptr) => base.ptr = ptr;
        
        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrcsdk3]].GetClass("VRCPickup", "VRC.SDK3.Components");
    }
}
