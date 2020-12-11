using System;
using BlazeIL.il2cpp;

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

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityengineui]].GetClass("Image", "UnityEngine.UI");
    }
}
