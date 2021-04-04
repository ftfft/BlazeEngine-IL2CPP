using System;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public class ApiWorld : ApiModel
    {
        public ApiWorld(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string currentInstanceIdWithTags
        {
            get => Instance_Class.GetField(nameof(currentInstanceIdWithTags)).GetValue(ptr)?.GetValue<string>();
        }

        public string authorId
        {
            get => Instance_Class.GetProperty(nameof(authorId)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(authorId)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiWorld", "VRC.Core");
    }
}