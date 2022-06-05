using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2ParameterInfo : IL2Base
    {
        public IL2ParameterInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public IL2Object DefaultValue
		{
			get => Instance_Class.GetProperty(nameof(DefaultValue)).GetGetMethod().Invoke(ptr);
		}

		public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("ParameterInfo", "System.Reflection");
    }
}
