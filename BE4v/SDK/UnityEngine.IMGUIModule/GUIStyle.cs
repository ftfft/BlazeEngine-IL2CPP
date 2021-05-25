using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class GUIStyle : ScriptableObject
	{
		public GUIStyle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUIStyle", "UnityEngine");
	}
}
