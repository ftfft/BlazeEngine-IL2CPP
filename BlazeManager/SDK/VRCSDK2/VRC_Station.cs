using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    public class VRC_Station : VRC.SDKBase.VRCStation
    {
        public VRC_Station(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a["VRCSDK2"].GetClass("VRC_Station", "VRCSDK2");
    }
}
