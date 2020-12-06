using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
	// ScriptableObject -> Object
	public sealed class GUISkin : Object
	{
		public GUISkin(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public GUIStyle label
		{
			get => Instance_Class.GetProperty(nameof(label)).GetGetMethod().Invoke(ptr)?.unbox<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(label)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.IMGUIModule"].GetClass("GUISkin", "UnityEngine");
	}
}
