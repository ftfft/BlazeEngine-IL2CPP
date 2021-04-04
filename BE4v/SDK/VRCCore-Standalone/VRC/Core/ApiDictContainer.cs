using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public class ApiDictContainer : ApiContainer
    {
        public ApiDictContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiDictContainer() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiDictContainer", "VRC.Core");
    }
}
