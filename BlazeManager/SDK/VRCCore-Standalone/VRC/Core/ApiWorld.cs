using System;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiWorld : ApiModel
    {
        public ApiWorld(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string currentInstanceIdWithTags
        {
            get => Instance_Class.GetField(nameof(currentInstanceIdWithTags)).GetValue(ptr)?.unbox_ToString().ToString();
        }

        public string authorId
        {
            get => Instance_Class.GetProperty(nameof(authorId)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(authorId)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorld", "VRC.Core");
    }
}