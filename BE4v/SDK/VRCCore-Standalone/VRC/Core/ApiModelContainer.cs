using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public class ApiModelContainer<T> : ApiDictContainer where T : ApiModel
    {
        public ApiModelContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiModelContainer() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            IL2Method method = Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0);
            method.Invoke(ptr, new IntPtr[] { method.ptr });
        }

        public ApiModelContainer(T target) : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            IL2Method method = Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1);
            method.Invoke(ptr, new IntPtr[] { target.ptr, method.ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiModelContainer`1", "VRC.Core"); //.MakeGenericType(new Type[] { typeof(T) });
    }
}
