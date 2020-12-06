using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	public sealed class Screen
	{
		public static int width
		{
			get => Instance_Class.GetProperty(nameof(width)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
		}

		public static int height
		{
			get => Instance_Class.GetProperty(nameof(height)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
		}

		public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Screen", "UnityEngine");
	}
}
