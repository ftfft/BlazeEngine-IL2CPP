using System;
using BlazeIL;
using BlazeIL.il2cpp;

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
			get => Instance_Class.GetProperty(nameof(shader)).GetGetMethod().Invoke(ptr)?.unbox<Shader>();
			set => Instance_Class.GetProperty(nameof(shader)).GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
		}
		
		public Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Color>();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Material", "UnityEngine");
	}
}
