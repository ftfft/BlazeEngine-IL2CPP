using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class Coroutine : YieldInstruction
	{
		public Coroutine(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public Coroutine() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Coroutine", "UnityEngine");
	}
}
