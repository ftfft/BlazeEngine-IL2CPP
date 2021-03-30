using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    public class Image : Graphic
    {
        public Image(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr sprite
        {
            get => Instance_Class.GetProperty(nameof(sprite)).GetGetMethod().Invoke(ptr).ptr;
            set => Instance_Class.GetProperty(nameof(sprite)).GetSetMethod().Invoke(ptr, new IntPtr[] { value });
        }

        public IntPtr material
        {
            get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(ptr).ptr;
            set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(ptr, new IntPtr[] { value });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Image", "UnityEngine.UI");
    }
}
