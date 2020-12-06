using System;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Text -> MaskableGraphic -> Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    public class Text : Graphic
    {
        public Text(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string text
        {
            get => Instance_Class.GetProperty(nameof(text)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(text)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Text", "UnityEngine.UI");
    }
}
