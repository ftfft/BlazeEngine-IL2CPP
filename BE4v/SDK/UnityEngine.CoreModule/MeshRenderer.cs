using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MeshRenderer : Renderer
	{
		public MeshRenderer(IntPtr ptr) : base(ptr) => base.ptr = ptr;



		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("MeshRenderer", "UnityEngine");
	}
}
