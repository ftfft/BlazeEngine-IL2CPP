using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	// ScriptableObject -> Object
	public sealed class GUIStyle : IL2Base
	{
		public GUIStyle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static IL2Type Instance_Class = Assemblies.a["UnityEngine.IMGUIModule"].GetClass("GUIStyle", "UnityEngine");
	}
}
