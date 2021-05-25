using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using System;
using System.Text;
using UnityEngine.UI;

namespace UnityEngine
{
	public sealed class GUILayoutOption : IL2Base
	{
		public GUILayoutOption(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		unsafe internal GUILayoutOption(Type type, IntPtr value) : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { new IntPtr(&type), value });
		}


		unsafe internal Type type
		{
			get => Instance_Class.GetField(nameof(type)).GetValue(ptr).GetValuе<Type>();
			set => Instance_Class.GetField(nameof(type)).SetValue(ptr, new IntPtr(&value));
		}
		

		unsafe internal IntPtr value
		{
			get
			{
				IL2Object result = Instance_Class.GetField(nameof(value)).GetValue(ptr);
				return (result == null) ? IntPtr.Zero : result.ptr;
			}
			set => Instance_Class.GetField(nameof(value)).SetValue(ptr, new IntPtr(&value));
		}

		internal enum Type
		{
			fixedWidth,
			fixedHeight,
			minWidth,
			maxWidth,
			minHeight,
			maxHeight,
			stretchWidth,
			stretchHeight,
			alignStart,
			alignMiddle,
			alignEnd,
			alignJustify,
			equalSize,
			spacing
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUILayoutOption", "UnityEngine");
	}
}
