using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace System.Reflection
{
    public class IL2MethodInfo : IL2Base
    {
        public IL2MethodInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodMakeGenericMethod;
        public IntPtr MakeGenericMethod(Type[] types)
        {
            IntPtr[] ptrs = new IntPtr[types.Length];
            for (int i = 0; i < types.Length; i++)
                ptrs[i] = IL2GetType.IL2Typeof(types[i]).ptr;
            return MakeGenericMethod(ptrs);
        }
        public IntPtr MakeGenericMethod(IntPtr[] intPtrs)
        {
            if (methodMakeGenericMethod == null)
            {
                methodMakeGenericMethod = Instance_Class.GetMethod("MakeGenericMethod");
                if (methodMakeGenericMethod == null)
                    return IntPtr.Zero;
            }

            return methodMakeGenericMethod.Invoke(ptr, new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) }, true).ptr;
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("MethodInfo", "System.Reflection");
    }
}
