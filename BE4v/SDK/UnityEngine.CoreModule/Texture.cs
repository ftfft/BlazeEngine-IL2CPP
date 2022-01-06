using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public class Texture : Object
	{
		public Texture(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public virtual int width
		{
			get => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke(ptr).GetValuе<int>();
			set => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public virtual int height
		{
			get => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke(ptr).GetValuе<int>();
			set => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Texture", "UnityEngine");
	}
}
