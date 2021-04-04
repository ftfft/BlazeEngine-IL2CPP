using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public class ApiAvatar : ApiModel
    {
        public ApiAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiAvatar() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public string releaseStatus
		{
            get => Instance_Class.GetProperty(nameof(releaseStatus)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(releaseStatus)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
		}

        public string authorId
        {
            get => Instance_Class.GetProperty(nameof(authorId)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(authorId)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public string assetUrl
        {
            get => Instance_Class.GetProperty(nameof(assetUrl)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(assetUrl)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public string name
        {
            get => Instance_Class.GetProperty(nameof(name)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(name)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }
        /*
        public void SaveReleaseStatus(Action<ApiContainer> onSuccess = null, Action<ApiContainer> onFailure = null)
        {
            IntPtr ptrSucc = IntPtr.Zero;
            if (onSuccess != null)
                ptrSucc = UnityEngine.Events._UnityAction.CreateDelegate(onSuccess, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);

            IntPtr ptrFail = IntPtr.Zero;
            if (onFailure != null)
                ptrFail = UnityEngine.Events._UnityAction.CreateDelegate(onFailure, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);

            Instance_Class.GetMethod(nameof(SaveReleaseStatus)).Invoke(ptr, new IntPtr[] { ptrSucc, ptrFail });
        }
        */
        public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiAvatar", "VRC.Core");
    }
}
