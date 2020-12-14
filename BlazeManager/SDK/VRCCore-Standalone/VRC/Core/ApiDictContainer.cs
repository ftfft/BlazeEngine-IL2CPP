using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiDictContainer : ApiContainer
    {
        public ApiDictContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiDictContainer() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor().Invoke(ptr);
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("ApiDictContainer", "VRC.Core");
    }
}
