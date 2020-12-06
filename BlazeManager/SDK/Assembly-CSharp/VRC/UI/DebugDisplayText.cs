using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC.UI
{
    public class DebugDisplayText : MonoBehaviour
    {
        public DebugDisplayText(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("DebugDisplayText", "VRC.UI");
    }
}
