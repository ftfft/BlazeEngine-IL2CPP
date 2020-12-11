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

        public IntPtr MakeGenericType(Type[] types) => MakeGenericType(types.Select(x => IL2GetType.IL2Typeof(x).ptr).ToArray());
        public IntPtr MakeGenericType(IntPtr[] intPtrs)
        {
            return IL2Import.il2cpp_class_from_system_type(Instance_Class.GetMethod(nameof(MakeGenericType)).Invoke(IL2GetType.IL2Typeof(new IL2Type(ptr)).ptr, new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) }).ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.mscorlib]].GetClass("RuntimeType", "System");
    }
}
