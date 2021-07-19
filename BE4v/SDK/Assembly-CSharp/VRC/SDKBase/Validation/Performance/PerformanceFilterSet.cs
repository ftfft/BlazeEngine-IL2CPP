using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.SDKBase.Validation.Performance
{
    public class PerformanceFilterSet : ScriptableObject
    {
        public PerformanceFilterSet(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("PerformanceFilterSet", "VRC.SDKBase.Validation.Performance");
    }
}
