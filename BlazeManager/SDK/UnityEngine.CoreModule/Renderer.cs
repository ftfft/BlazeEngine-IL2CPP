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

		public Material material
		{
			get => Instance_Class.GetProperty(nameof(material)).GetGetMethod().Invoke(ptr)?.unbox<Material>();
			set => Instance_Class.GetProperty(nameof(material)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("Renderer", "UnityEngine");
	}
}
