using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class Sprite : Object
	{
		public Sprite(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public Texture2D texture
		{
			get => Instance_Class.GetProperty(nameof(texture)).GetGetMethod().Invoke(ptr)?.GetValue<Texture2D>();
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Sprite", "UnityEngine");
	}
}
