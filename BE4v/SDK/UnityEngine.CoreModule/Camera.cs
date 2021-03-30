using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine
{
    public sealed class Camera : MonoBehaviour
    {
        public Camera(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static Camera main
        {
            get => Instance_Class.GetProperty(nameof(main)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        public static Camera current
        {
            get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        public Ray ScreenPointToRay(Vector3 pos)
        {
            return Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { pos.MonoCast() }).GetValuå<Ray>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Camera", "UnityEngine");
    }
}
