using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.SDKBase.Validation.Performance
{
    public class PerformanceScannerSet : ScriptableObject
    {
        public PerformanceScannerSet(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("PerformanceScannerSet", "VRC.SDKBase.Validation.Performance");
    }
}
