using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class WaitForSeconds : YieldInstruction
	{
		public WaitForSeconds(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public WaitForSeconds(float seconds) : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { new IntPtr(&seconds) });
		}

		unsafe public float m_Seconds
        {
			get => Instance_Class.GetField(nameof(m_Seconds)).GetValue(ptr).GetValuе<float>();
			set => Instance_Class.GetField(nameof(m_Seconds)).SetValue(ptr, new IntPtr(&value));
        }

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("WaitForSeconds", "UnityEngine");
	}
}
