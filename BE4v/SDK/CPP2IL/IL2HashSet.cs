using System;
using System.Reflection;

namespace BE4v.SDK.CPP2IL
{
	unsafe public class IL2HashSet : IL2Base
	{
		public IL2HashSet(IntPtr ptrNew) : base(ptrNew) =>
			ptr = ptrNew;

		public void Clear()
		{
			Instance_Class.GetMethod(nameof(Clear)).Invoke(ptr, ex: false);
		}

		public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("HashSet`1", "System.Collections.Generic");
	}
}
