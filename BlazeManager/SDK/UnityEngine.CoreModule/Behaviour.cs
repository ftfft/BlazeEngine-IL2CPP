using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Behaviour : Component
	{
		public Behaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public bool enabled
		{
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public bool isActiveAndEnabled
		{
			get => Instance_Class.GetProperty(nameof(isActiveAndEnabled)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
		}

		public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("Behaviour", "UnityEngine");
	}
}
