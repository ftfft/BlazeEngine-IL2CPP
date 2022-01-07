using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine
{
	public sealed class SpriteRenderer : Renderer
	{
		public SpriteRenderer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Sprite sprite
        {
            get => Instance_Class.GetProperty(nameof(sprite)).GetGetMethod().Invoke(ptr)?.GetValue<Sprite>();
            set => Instance_Class.GetProperty(nameof(sprite)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("SpriteRenderer", "UnityEngine");
	}
}
