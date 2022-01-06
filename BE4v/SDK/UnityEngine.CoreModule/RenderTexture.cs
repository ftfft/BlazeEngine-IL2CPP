using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class RenderTexture : Texture
	{
		public RenderTexture(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public static RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite)
		{
			return Instance_Class.GetMethod(nameof(GetTemporary), x => x.GetParameters().Length == 5
			&& x.GetParameters()[3].ReturnType.Name == "UnityEngine.RenderTextureFormat" && x.GetParameters()[4].ReturnType.Name == "UnityEngine.RenderTextureReadWrite").Invoke(new IntPtr[] { new IntPtr(&width), new IntPtr(&height), new IntPtr(&depthBuffer), new IntPtr(&format), new IntPtr(&readWrite) })?.GetValue<RenderTexture>();
		}


		public static RenderTexture active
		{
			get => Instance_Class.GetProperty(nameof(active)).GetGetMethod().Invoke()?.GetValue<RenderTexture>();
			set => Instance_Class.GetProperty(nameof(active)).GetSetMethod().Invoke(new IntPtr[] { value.ptr });
		}

		public static void ReleaseTemporary(RenderTexture temp)
		{
			Instance_Class.GetMethod(nameof(ReleaseTemporary)).Invoke(new IntPtr[] { temp.ptr });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("RenderTexture", "UnityEngine");
	}
}
