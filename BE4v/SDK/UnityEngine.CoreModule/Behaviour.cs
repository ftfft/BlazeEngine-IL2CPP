using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

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
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public bool isActiveAndEnabled
		{
			get => Instance_Class.GetProperty(nameof(isActiveAndEnabled)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Behaviour", "UnityEngine");
	}
}
