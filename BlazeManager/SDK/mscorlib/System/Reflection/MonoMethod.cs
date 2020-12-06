using System;
using System.Linq;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace System.Reflection
{
    public class MonoMethod : IL2Base
    {
        public MonoMethod(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr MakeGenericMethod(Type[] types) => MakeGenericMethod(types.Select(x => IL2GetType.IL2Typeof(x).ptr).ToArray());
        public IntPtr MakeGenericMethod(IntPtr[] intPtrs)
        {
            IL2Object @object = null;
            @object = Instance_Class.GetMethod(nameof(MakeGenericMethod)).Invoke(IL2Import.il2cpp_method_get_object(ptr), new IntPtr[] { intPtrs.ArrayToIntPtr(IL2SystemClass.Type) });
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
