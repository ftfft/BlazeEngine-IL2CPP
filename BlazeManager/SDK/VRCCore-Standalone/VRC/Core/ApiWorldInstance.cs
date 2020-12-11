using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiWorldInstance : IL2Base
    {
        public ApiWorldInstance(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor(x => x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "_count").Invoke(ptr, new IntPtr[] { world.ptr, new IL2String(_idWithTags).ptr, _count.MonoCast() });
        }

        public string GetInstanceCreator()
        {
            return Instance_Class.GetMethod(nameof(GetInstanceCreator)).Invoke(ptr)?.unbox_ToString().ToString();
        }

        public ApiWorld instanceWorld
        {
            get => Instance_Class.GetField(nameof(instanceWorld)).GetValue(ptr)?.unbox<ApiWorld>();
        }

        public string idWithTags
        {
            get => Instance_Class.GetField(nameof(idWithTags)).GetValue(ptr)?.unbox_ToString().ToString();
        }
        
        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("ApiWorldInstance", "VRC.Core");
    }
}