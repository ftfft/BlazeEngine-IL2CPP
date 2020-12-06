using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiModel : IL2Base
    {
        public ApiModel(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string id
        {
            get => Instance_Class.GetProperty(nameof(id)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(id)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }    
    
        public bool Populated
        {
            get => Instance_Class.GetProperty(nameof(Populated)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiModel", "VRC.Core");
    }
}