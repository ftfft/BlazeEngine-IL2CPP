using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Reflection
{
    public class IL2MethodBase : IL2MemberInfo
    {
        public IL2MethodBase(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2ParameterInfo[] GetParameters()
        {
            return Instance_Class.GetMethod("GetParameters").Invoke(ptr)?.UnboxArray<IL2ParameterInfo>();
        }

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2RuntimeMethodHandle MethodHandle
        {
            get => Instance_Class.GetProperty(nameof(MethodHandle)).GetGetMethod().Invoke(ptr).GetValue<IL2RuntimeMethodHandle>();
        }

        /// <summary>
        ///     Not supported IL2CPP
        /// </summary>
        public IL2MethodBody GetMethodBody()
        {
            return Instance_Class.GetMethod(nameof(GetMethodBody), x => !x.IsStatic).Invoke(ptr)?.GetValue<IL2MethodBody>();
        }

        unsafe public static IL2MethodBody GetMethodBody(IntPtr handle)
        {
            return Instance_Class.GetMethod(nameof(GetMethodBody), x => x.IsStatic).Invoke(new IntPtr[] { new IntPtr(&handle) })?.GetValue<IL2MethodBody>();
        }

        public static new IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("MethodBase", "System.Reflection");
    }
}
