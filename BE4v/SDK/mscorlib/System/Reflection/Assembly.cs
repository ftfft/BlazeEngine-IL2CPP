using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2AssemblyCore : IL2Base
    {
        public IL2AssemblyCore(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Assembly", "System.Reflection");
    }
}
