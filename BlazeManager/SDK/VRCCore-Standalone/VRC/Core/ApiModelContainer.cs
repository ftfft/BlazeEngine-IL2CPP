using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiModelContainer<T> : ApiDictContainer where T : ApiModel
    {
        public ApiModelContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiModelContainer() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            IL2Method method = Instance_Class.GetConstructor(x => x.GetParameters().Length == 0);
            method.Invoke(ptr, new IntPtr[] { method.ptr });
        }

        public ApiModelContainer(T target) : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            IL2Method method = Instance_Class.GetConstructor(x => x.GetParameters().Length == 1);
            method.Invoke(ptr, new IntPtr[] { target.ptr, method.ptr });
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("ApiModelContainer`1", "VRC.Core").MakeGenericType(new Type[] { typeof(T) });
    }
}
