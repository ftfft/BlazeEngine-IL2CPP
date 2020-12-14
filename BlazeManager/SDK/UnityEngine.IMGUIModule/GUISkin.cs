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
		public GUIStyle box
		{
			get => Instance_Class.GetProperty(nameof(box)).GetGetMethod().Invoke(ptr)?.unbox<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(box)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityengineimguimodule]].GetClass("GUISkin", "UnityEngine");
	}
}
