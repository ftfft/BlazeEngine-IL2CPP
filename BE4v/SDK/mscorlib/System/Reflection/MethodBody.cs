using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2MethodBody : IL2Base
    {
        public IL2MethodBody(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public byte[] GetILAsByteArray()
        {
            return Instance_Class.GetMethod(nameof(GetILAsByteArray)).Invoke(ptr).UnboxArraу<byte>();
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("MethodBody", "System.Reflection");
    }
}
