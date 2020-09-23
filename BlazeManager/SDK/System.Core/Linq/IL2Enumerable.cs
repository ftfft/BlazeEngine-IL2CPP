using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;

namespace System.Linq
{
    public static class IL2Enumerable
    {
        private static IL2Method methodToList = null;
        public static IL2List<T> ToList<T>(IntPtr array)
        {
            if (methodToList == null)
            {
                methodToList = Instance_Class.GetMethod("ToList", x => x.GetParameters().Length == 1);
                if (methodToList == null)
                    return null;
            }
            IL2Object obj = methodToList.Invoke(new IntPtr[] { array, methodToList.ptr });
            if (obj == null) return null;
            
            return new IL2List<T>(obj.ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a["System.Core"].GetClass("Enumerable", "System.Linq");
    }
}
