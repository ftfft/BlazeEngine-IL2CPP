using System;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;

namespace System.Linq
{
    public static class IL2Enumerable
    {
        public static IL2List<T> ToList<T>(IntPtr array)
        {
            IL2Method method = Instance_Class.GetMethod("ToList", x => x.GetParameters().Length == 1);
            IL2Object result = method.Invoke(new IntPtr[] { array, method.ptr });
            if (result == null) 
                return null;
            return new IL2List<T>(result.ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.systemcore]].GetClass("Enumerable", "System.Linq");
    }
}
