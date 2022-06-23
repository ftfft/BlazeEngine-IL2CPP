using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class Graphics : IL2Object
	{
		public Graphics(IntPtr ptr) : base(ptr) { }

		public static void Blit(Texture source, RenderTexture dest)
		{
			Instance_Class.GetMethod(nameof(Blit), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { source == null ? IntPtr.Zero : source.Pointer, dest == null ? IntPtr.Zero : dest.Pointer });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Graphics", "UnityEngine");
	}
}
