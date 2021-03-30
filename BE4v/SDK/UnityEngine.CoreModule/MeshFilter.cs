using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MeshFilter : Component
	{
		public MeshFilter(IntPtr ptr) : base(ptr) => base.ptr = ptr;


		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("MeshFilter", "UnityEngine");
	}
}
