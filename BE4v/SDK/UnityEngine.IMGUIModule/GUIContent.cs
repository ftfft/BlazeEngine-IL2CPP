using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class GUIContent : IL2Object
	{
		public GUIContent(IntPtr ptr) : base(ptr) { }

		public GUIContent() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(Pointer);
		}
		public GUIContent(string text) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "text").Invoke(Pointer, new IntPtr[] { new IL2String(text).ptr });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUI"].GetClass("GUIContent", "UnityEngine");
	}
}
