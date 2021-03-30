using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class Screen
	{
		public static int width
		{
			get => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke().GetValuе<int>();
		}

		public static int height
		{
			get => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke().GetValuе<int>();
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Screen", "UnityEngine");
	}
}
