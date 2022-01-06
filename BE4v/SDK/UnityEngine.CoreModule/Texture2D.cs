using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class Texture2D : Texture
	{
		public Texture2D(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public Texture2D(int width, int height) : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { new IntPtr(&width), new IntPtr(&height) });
		}

		unsafe public void ReadPixels(Rect source, int destX, int destY)
		{
			Instance_Class.GetMethod(nameof(ReadPixels), x => x.GetParameters().Length == 3).Invoke(ptr, new IntPtr[] { new IntPtr(&source), new IntPtr(&destX), new IntPtr(&destY) });
		}

		public void Apply()
		{
			Instance_Class.GetMethod(nameof(Apply), x => x.GetParameters().Length == 0).Invoke(ptr);
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Texture2D", "UnityEngine");
	}
}
