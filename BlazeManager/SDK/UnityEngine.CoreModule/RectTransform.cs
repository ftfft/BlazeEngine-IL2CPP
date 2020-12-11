using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Vector2 anchoredPosition
        {
            get => Instance_Class.GetProperty(nameof(anchoredPosition)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector2>();
            set => Instance_Class.GetProperty(nameof(anchoredPosition)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Vector2 sizeDelta
        {
            get => Instance_Class.GetProperty(nameof(sizeDelta)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector2>();
            set => Instance_Class.GetProperty(nameof(sizeDelta)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("RectTransform", "UnityEngine");
    }
}
