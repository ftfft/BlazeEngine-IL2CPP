using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    // Text -> MaskableGraphic -> Graphic
    public class Text : Graphic
    {
        public Text(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Text() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public string text
        {
            get => Instance_Class.GetProperty(nameof(text)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(text)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Text", "UnityEngine.UI");
    }
}
