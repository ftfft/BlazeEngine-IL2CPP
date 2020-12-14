using System;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine.UI;

namespace UnityEngine
{
	public sealed class GUILayoutOption : IL2Base
	{
		public GUILayoutOption(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		internal GUILayoutOption(Type type, IntPtr value) : base(IntPtr.Zero)
		{
			ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetConstructor(x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { type.MonoCast(), value });
		}


		internal Type type
		{
			get => Instance_Class.GetField(nameof(type)).GetValue(ptr).unbox_Unmanaged<Type>();
			set => Instance_Class.GetField(nameof(type)).SetValue(ptr, value.MonoCast());
		}
		

		internal IntPtr value
		{
			get
			{
				IL2Object result = Instance_Class.GetField(nameof(value)).GetValue(ptr);
				return (result == null) ? IntPtr.Zero : result.ptr;
			}
			set => Instance_Class.GetField(nameof(value)).SetValue(ptr, value.MonoCast());
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

		public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityengineimguimodule]].GetClass("GUILayoutOption", "UnityEngine");
	}
}
