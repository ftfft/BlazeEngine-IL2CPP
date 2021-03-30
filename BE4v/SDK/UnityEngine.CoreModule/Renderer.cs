using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Renderer : MonoBehaviour
	{
		public Renderer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public Material material
		{
			get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(ptr)?.GetValue<Material>();
			set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Renderer", "UnityEngine");
	}
}
