using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public class ApiWorldInstance : IL2Base
    {
        public ApiWorldInstance(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "_count").Invoke(ptr, new IntPtr[] { world.ptr, new IL2String(_idWithTags).ptr, _count.MonoCast() });
        }

        public string GetInstanceCreator()
        {
            return Instance_Class.GetMethod(nameof(GetInstanceCreator)).Invoke(ptr)?.GetValue<string>();
        }

        public ApiWorld instanceWorld
        {
            get => Instance_Class.GetField(nameof(instanceWorld)).GetValue(ptr)?.GetValue<ApiWorld>();
        }

        public string idWithTags
        {
            get => Instance_Class.GetField(nameof(idWithTags)).GetValue(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiWorldInstance", "VRC.Core");
    }
}