using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class Shader : Object
	{
		public Shader(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static Shader Find(string name)
		{
			return Instance_Class.GetMethod(nameof(Find)).Invoke(new IntPtr[] { new IL2String(name).ptr })?.GetValue<Shader>();
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Shader", "UnityEngine");
	}
}
