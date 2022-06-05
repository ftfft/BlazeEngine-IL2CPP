using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2MemberInfo : IL2Base
    {
        public IL2MemberInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IL2Type DeclaringType
        {
            get => Instance_Class.GetProperty(nameof(DeclaringType)).GetGetMethod().Invoke(ptr)?.GetValue<IL2Type>();
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("MemberInfo", "System.Reflection");
    }
}
