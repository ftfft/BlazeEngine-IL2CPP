using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRCSDK2
{
    public class VRC_PlayerApi : MonoBehaviour
    {
        public VRC_PlayerApi(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool isMaster
        {
            get => Instance_Class.GetProperty(nameof(isMaster)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool isModerator
        {
            get => Instance_Class.GetProperty(nameof(isModerator)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool isSuper
        {
            get => Instance_Class.GetProperty(nameof(isSuper)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrcsdk2]].GetClass("VRC_PlayerApi", "VRCSDK2");
    }
}
