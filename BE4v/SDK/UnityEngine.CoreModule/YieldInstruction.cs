using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class YieldInstruction : IL2Base
	{
		public YieldInstruction(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public YieldInstruction() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("YieldInstruction", "UnityEngine");
	}
}
