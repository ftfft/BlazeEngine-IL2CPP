using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class Graphics : IL2Base
	{
		public Graphics(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static void Blit(Texture source, RenderTexture dest)
		{
			Instance_Class.GetMethod(nameof(Blit), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { source.ptr, dest.ptr });
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Graphics", "UnityEngine");
	}
}
