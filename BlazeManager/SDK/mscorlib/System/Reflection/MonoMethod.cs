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
    public class MonoMethod : IL2Base
    {
        public MonoMethod(IntPtr ptr) : base(ptr) => base.ptr = ptr;

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

            IL2Object @object = null;
            @object = methodMakeGenericMethod.Invoke(IL2Import.il2cpp_method_get_object(ptr), new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) });
            if (@object == null)
                return IntPtr.Zero;

            unsafe
            {
                return *((IntPtr*)@object.ptr + 2);
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("MonoMethod", "System.Reflection");
    }
}
