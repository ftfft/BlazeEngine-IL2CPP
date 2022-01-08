using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    public class Image : Graphic
    {
        public Image(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Sprite sprite
        {
            get => Instance_Class.GetProperty(nameof(sprite)).GetGetMethod().Invoke(ptr)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(sprite)).GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
        }
        
        public Sprite overrideSprite
        {
            get => Instance_Class.GetProperty(nameof(overrideSprite)).GetGetMethod().Invoke(ptr)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(overrideSprite)).GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
        }

        public Material material
        {
            get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(ptr)?.GetValue<Material>();
            set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Image", "UnityEngine.UI");
    }
}
