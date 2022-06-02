﻿using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class GUISkin : ScriptableObject
	{
		public GUISkin(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public GUISkin() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public GUIStyle label
		{
			get => Instance_Class.GetProperty(nameof(label)).GetGetMethod().Invoke(ptr)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(label)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}
		public GUIStyle box
		{
			get => Instance_Class.GetProperty(nameof(box)).GetGetMethod().Invoke(ptr)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(box)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUISkin", "UnityEngine");
	}
}
