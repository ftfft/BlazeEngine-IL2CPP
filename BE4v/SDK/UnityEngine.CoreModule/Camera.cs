using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public sealed class Camera : MonoBehaviour
    {
        public Camera(IntPtr ptr) : base(ptr) { }

        public static Camera main
        {
            get => Instance_Class.GetProperty(nameof(main)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        public static Camera current
        {
            get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke()?.GetValue<Camera>();
        }

        unsafe public Ray ScreenPointToRay(Vector3 pos)
        {
            return Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1).Invoke<Ray>(this, new IntPtr[] { new IntPtr(&pos) }).GetValue();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Camera", "UnityEngine");
    }
}
