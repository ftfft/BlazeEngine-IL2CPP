using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptr) : base(ptr) { }

        unsafe public Vector2 anchoredPosition
        {
            get => Instance_Class.GetProperty(nameof(anchoredPosition)).GetGetMethod().Invoke<Vector2>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(anchoredPosition)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public Vector2 sizeDelta
        {
            get => Instance_Class.GetProperty(nameof(sizeDelta)).GetGetMethod().Invoke<Vector2>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(sizeDelta)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("RectTransform", "UnityEngine");
    }
}
