using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System
{
    public class IL2ObjectSystem : IL2Base
    {
        public IL2ObjectSystem(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Object", "System");
    }
}
