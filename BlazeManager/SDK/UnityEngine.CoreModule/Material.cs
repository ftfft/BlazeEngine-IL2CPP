using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Material : Object
	{
		public Material(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		private static IL2Property propertyShader = null;
		public Shader shader
		{
			get
			{
				if (propertyShader == null)
				{
					propertyShader = Instance_Class.GetProperty("shader");
					if (propertyShader == null)
						return null;
				}
				return propertyShader.GetGetMethod().Invoke(ptr)?.MonoCast<Shader>();
			}
			set
			{
				if (propertyShader == null)
				{
					propertyShader = Instance_Class.GetProperty("shader");
					if (propertyShader == null)
						return;
				}

				propertyShader.GetSetMethod().Invoke(ptr, new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
			}
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Material", "UnityEngine");
	}
}
