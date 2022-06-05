using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2RuntimeMethodInfo : IL2MethodBase
    {
        public IL2RuntimeMethodInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("RuntimeMethodInfo", "System.Reflection");
    }
}
