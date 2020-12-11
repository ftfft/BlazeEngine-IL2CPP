using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRC.Animation
{
    public class VRCMotionState : MonoBehaviour
    {
        public VRCMotionState(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCMotionState", "VRC.Animation");
    }
}
