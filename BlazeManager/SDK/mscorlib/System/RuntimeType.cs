using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace System
{
    public class RuntimeType : IL2Base
    {
        public RuntimeType(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodMakeGenericType;
        public IntPtr MakeGenericType(Type[] types)
        {
            IntPtr[] ptrs = new IntPtr[types.Length];
            for (int i = 0; i < types.Length; i++)
                ptrs[i] = IL2GetType.IL2Typeof(types[i]).ptr;
            return MakeGenericType(ptrs);
        }
        public IntPtr MakeGenericType(IntPtr[] intPtrs)
        {
            if (methodMakeGenericType == null)
            {
                methodMakeGenericType = Instance_Class.GetMethod("MakeGenericType");
                if (methodMakeGenericType == null)
                    return IntPtr.Zero;
            }

            IL2Object @object = null;
            @object = methodMakeGenericType.Invoke(IL2GetType.IL2Typeof(new IL2Type(ptr)).ptr, new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) });
            if (@object == null)
                return IntPtr.Zero;

            return IL2Import.il2cpp_class_from_system_type(@object.ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("RuntimeType", "System");
    }
}
