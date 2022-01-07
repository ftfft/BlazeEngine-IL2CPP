using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public sealed class CanvasRenderer : Component
    {
        public CanvasRenderer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public void SetTexture(Texture texture)
        {
            Instance_Class.GetMethod(nameof(SetTexture)).Invoke(ptr, new IntPtr[] { texture.ptr });
        }

        public void SetAlphaTexture(Texture texture)
        {
            Instance_Class.GetMethod(nameof(SetAlphaTexture)).Invoke(ptr, new IntPtr[] { texture.ptr });
        }


        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UIModule"].GetClass("CanvasRenderer", "UnityEngine");
    }
}
