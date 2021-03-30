using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Vector2 anchoredPosition
        {
            get => Instance_Class.GetProperty(nameof(anchoredPosition)).GetGetMethod().Invoke(ptr).GetValuе<Vector2>();
            set => Instance_Class.GetProperty(nameof(anchoredPosition)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Vector2 sizeDelta
        {
            get => Instance_Class.GetProperty(nameof(sizeDelta)).GetGetMethod().Invoke(ptr).GetValuе<Vector2>();
            set => Instance_Class.GetProperty(nameof(sizeDelta)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("RectTransform", "UnityEngine");
    }
}
