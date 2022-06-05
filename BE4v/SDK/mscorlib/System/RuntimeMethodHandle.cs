using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System
{
    public class IL2RuntimeMethodHandle : IL2Base
    {
        public IL2RuntimeMethodHandle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public IntPtr value
        {
            get => Instance_Class.GetField(nameof(value)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(value)).SetValue(ptr, new IntPtr(&value));
        }


        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("RuntimeMethodHandle", "System");
    }
}
