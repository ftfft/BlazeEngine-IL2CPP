using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Renderer : MonoBehaviour
	{
		public Renderer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		private static IL2Property propertyMaterial = null;
		public Material material
		{
			get
			{
				if (propertyMaterial == null)
				{
					propertyMaterial = Instance_Class.GetProperty("material");
					if (propertyMaterial == null)
						return null;
				}
				return propertyMaterial.GetGetMethod().Invoke(ptr)?.MonoCast<Material>();
			}
			set
			{
				if (propertyMaterial == null)
				{
					propertyMaterial = Instance_Class.GetProperty("material");
					if (propertyMaterial == null)
						return;
				}
				propertyMaterial.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
			}
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Renderer", "UnityEngine");
	}
}
