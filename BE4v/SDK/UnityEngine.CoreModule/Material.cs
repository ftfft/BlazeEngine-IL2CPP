using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Material : Object
	{
		public Material(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public Shader shader
		{
			get => Instance_Class.GetProperty(nameof(shader)).GetGetMethod().Invoke(ptr)?.GetValue<Shader>();
			set => Instance_Class.GetProperty(nameof(shader)).GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
		}
		
		public Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).GetValuе<Color>();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Material", "UnityEngine");
	}
}
