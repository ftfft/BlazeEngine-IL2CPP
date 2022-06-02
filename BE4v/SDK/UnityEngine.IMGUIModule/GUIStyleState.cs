using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class GUIStyleState : IL2Base
	{
		public GUIStyleState(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public GUIStyleState() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(ptr);
		}
		
		unsafe public static GUIStyleState GetGUIStyleState(GUIStyle sourceStyle, IntPtr source)
		{
			return Instance_Class.GetMethod(nameof(GetGUIStyleState)).Invoke(new IntPtr[] { sourceStyle == null ? IntPtr.Zero : sourceStyle.ptr, new IntPtr(&source) }).GetValue<GUIStyleState>();
		}

		unsafe public Color textColor
		{
			set => Instance_Class.GetProperty(nameof(textColor)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		// System.Void UnityEngine.GUIStyleState::set_background(UnityEngine.Texture2D)
		private delegate IntPtr _set_Background(IntPtr instance, IntPtr texture2D);
		private static _set_Background __set_Background = null;
		unsafe public Texture2D background
		{
			set
			{
				if (__set_Background == null)
                {
					__set_Background = IL2Utils.ResolveICall<_set_Background>("UnityEngine.GUIStyleState::set_background");
					if (__set_Background == null)
                    {
						"not found".RedPrefix("GUIStyleState::set_Background");
						return;
                    }
				}
				__set_Background(ptr, value == null ? IntPtr.Zero : value.ptr);
			}
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUIStyleState", "UnityEngine");
	}
}
