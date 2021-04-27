using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRCSDK2
{
    public class VRC_Pickup : VRC.SDKBase.VRC_Pickup
    {
        public VRC_Pickup(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["VRCSDK2"].GetClass("VRC_Pickup", "VRCSDK2");
    }
}
