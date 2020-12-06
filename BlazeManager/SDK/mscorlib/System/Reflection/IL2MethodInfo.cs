using System;
using BlazeTools;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using System.Linq;

namespace System.Reflection
{
    public class IL2MethodInfo : IL2Base
    {
        public IL2MethodInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr MakeGenericMethod(Type[] types) => MakeGenericMethod(types.Select(x => IL2GetType.IL2Typeof(x).ptr).ToArray());
        public IntPtr MakeGenericMethod(IntPtr[] intPtrs)
        {
            return Instance_Class.GetMethod(nameof(MakeGenericMethod)).Invoke(ptr, new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) }, true).ptr;
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("MethodInfo", "System.Reflection");
    }
}
