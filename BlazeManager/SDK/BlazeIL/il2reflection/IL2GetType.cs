using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    internal class IL2GetType
    {
        internal static IL2TypeObject IL2Typeof(Type type)
        {
            IL2Type ilType = null;

            ilType = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.mscorlib]].GetClass(type.Name, type.Namespace);
            if (ilType == null)
                ilType = (IL2Type)type.GetFields().First(x => x.IsStatic && x.FieldType == typeof(IL2Type)).GetValue(null);

            return IL2Typeof(ilType);
        }
        internal static IL2TypeObject IL2Typeof(IL2Type klass)
        {
            IntPtr ptr = IL2Import.il2cpp_class_get_type(klass.ptr);
            if (ptr == IntPtr.Zero)
                return null;

            IntPtr result = IL2Import.il2cpp_type_get_object(ptr);
            if (ptr == IntPtr.Zero)
                return null;

            return new IL2TypeObject(result);
        }
    }
}
