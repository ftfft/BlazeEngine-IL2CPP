using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.IO
{
    public class IL2Encoding : IL2Base
    {
        public IL2Encoding(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Encoding ASCII
        {
            get => Instance_Class.GetProperty(nameof(ASCII)).GetGetMethod().Invoke()?.GetValue<IL2Encoding>();
        }

        public virtual IntPtr GetBytes(string s)
        {
            return Instance_Class.GetMethod(nameof(GetBytes),
                x => x.GetParameters().Length == 1
                && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName).Invoke(ptr, new IntPtr[] { new IL2String(s).ptr }).ptr;
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Encoding", "System.Text");
    }
}
