using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    public class VRC_Pickup : VRC.SDKBase.VRC_Pickup
    {
        public VRC_Pickup(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrcsdk2]].GetClass("VRC_Pickup", "VRCSDK2");
    }
}
