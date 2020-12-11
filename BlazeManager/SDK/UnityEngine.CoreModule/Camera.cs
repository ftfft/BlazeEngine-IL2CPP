using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class Camera : MonoBehaviour
    {
        public Camera(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static Camera main
        {
            get => Instance_Class.GetProperty(nameof(main)).GetGetMethod().Invoke()?.unbox<Camera>();
        }

        public static Camera current
        {
            get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke()?.unbox<Camera>();
        }

        public Ray ScreenPointToRay(Vector3 pos)
        {
            return Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { pos.MonoCast() }).unbox_Unmanaged<Ray>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("Camera", "UnityEngine");
    }
}
