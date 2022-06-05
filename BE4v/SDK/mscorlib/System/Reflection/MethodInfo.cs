using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2MethodInfo : IL2MethodBase
    {
        public IL2MethodInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;
		public MemberTypes MemberType
		{
			get => Instance_Class.GetProperty(nameof(MemberType)).GetGetMethod().Invoke(ptr).GetValuе<MemberTypes>();
		}

        public IL2MethodInfo GetBaseDefinition()
        {
            return Instance_Class.GetMethod(nameof(GetBaseDefinition)).Invoke(ptr)?.GetValue<IL2MethodInfo>();
        }


        public static new IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("MethodInfo", "System.Reflection");
    }
}
