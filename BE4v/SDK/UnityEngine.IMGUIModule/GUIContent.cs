using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class GUIContent : IL2Base
	{
		public GUIContent(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public GUIContent() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(ptr);
		}
		public GUIContent(string text) : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "text").Invoke(ptr, new IntPtr[] { new IL2String(text).ptr });
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUIContent", "UnityEngine");
	}
}
