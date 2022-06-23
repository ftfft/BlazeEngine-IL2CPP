using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase.Validation.Performance
{
    public class PerformanceScannerSet : ScriptableObject
    {
        public PerformanceScannerSet(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("PerformanceScannerSet", "VRC.SDKBase.Validation.Performance");
    }
}
