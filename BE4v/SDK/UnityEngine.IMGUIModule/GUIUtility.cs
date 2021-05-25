using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class GUIUtility : IL2Base
	{
		public GUIUtility(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static string systemCopyBuffer
		{
			get => Instance_Class.GetProperty(nameof(systemCopyBuffer)).GetGetMethod().Invoke().GetValue<string>();
			set => Instance_Class.GetProperty(nameof(systemCopyBuffer)).GetSetMethod().Invoke(new IntPtr[] { new IL2String(value).ptr });
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUIUtility", "UnityEngine");
	}
}
