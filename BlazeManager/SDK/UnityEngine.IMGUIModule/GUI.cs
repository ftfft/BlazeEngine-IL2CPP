using System;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	public class GUI
	{

		private static IL2Method m1_Box;
		public static void Box(Rect position, string text) => Box(position.MonoCast(), new IL2String(text).ptr);
		public static void Box(Rect position, IntPtr text) => Box(position.MonoCast(), text);
		public static void Box(IntPtr position, string text) => Box(position, new IL2String(text).ptr);
		public static void Box(IntPtr position, IntPtr text)
		{
			if (m1_Box == null)
			{
				m1_Box = Instance_Class.GetMethod("Box", m => m.GetParameters().Length == 2);
				if (m1_Box == null)
					return;
			}
			m1_Box.Invoke(new IntPtr[] { position, text });
		}
		/*

		public static void Box(Rect position, string text, GUIStyle style)
		{
		}

		public static void Box(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/

		private static IL2Method m1_Label;
		public static void Label(Rect position, string text) => Label(position.MonoCast(), new IL2String(text).ptr, s_Skin.label.ptr);
		public static void Label(Rect position, IntPtr text) => Label(position.MonoCast(), text, s_Skin.label.ptr);
		public static void Label(IntPtr position, string text) => Label(position, new IL2String(text).ptr, s_Skin.label.ptr);
		public static void Label(IntPtr position, IntPtr text) => Label(position, text, s_Skin.label.ptr);
		public static void Label(Rect position, IntPtr text, IntPtr style) => Label(position.MonoCast(), text, style);
		public static void Label(Rect position, string text, IntPtr style) => Label(position.MonoCast(), new IL2String(text).ptr, style);
		public static void Label(Rect position, string text, GUIStyle style) => Label(position.MonoCast(), new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, string text, IntPtr style) => Label(position, new IL2String(text).ptr, style);
		public static void Label(IntPtr position, string text, GUIStyle style) => Label(position, new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, IntPtr text, GUIStyle style) => Label(position, new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, IntPtr text, IntPtr style)
		{

			if (m1_Label == null)
			{
				m1_Label = Instance_Class.GetMethod("Label", m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text");
				if (m1_Label == null)
					return;
			}
			m1_Label.Invoke(new IntPtr[] { position, text, style });
		}
		/*
		public static void Label(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/
		private static IL2Method m1_Button;
		public static bool Button(Rect position, string text) => Button(position.MonoCast(), new IL2String(text).ptr);
		public static bool Button(Rect position, IntPtr text) => Button(position.MonoCast(), text);
		public static bool Button(IntPtr position, string text) => Button(position, new IL2String(text).ptr);
		public static bool Button(IntPtr position, IntPtr text)
		{
			if (m1_Button == null)
			{
				m1_Button = Instance_Class.GetMethod("Button", m => m.GetParameters().Length == 2);
				if (m1_Button == null)
					return false;
			}
			return m1_Button.Invoke(new IntPtr[] { position, text }).MonoCast<bool>();
		}

		/*
		// Token: 0x06000050 RID: 80 RVA: 0x0000218C File Offset: 0x0000038C
		[Address(RVA = "0x18182E560", Offset = "0x182CB60")]
		public static bool Button(Rect position, GUIContent content, GUIStyle style)
		{
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002190 File Offset: 0x00000390
		[Address(RVA = "0x18182E480", Offset = "0x182CA80")]
		internal static bool Button(Rect position, int id, GUIContent content, GUIStyle style)
		{
		}
		*/
		private static IL2Field fieldS_Skin;
		private static GUISkin s_Skin
		{
			get
			{
				if (fieldS_Skin == null)
				{
					fieldS_Skin = Instance_Class.GetField("s_Skin");
					if (fieldS_Skin == null)
						return null;
				}
				return fieldS_Skin.GetValue().MonoCast<GUISkin>();
			}
		}

		public static IL2Type Instance_Class = Assemblies.a["UnityEngine.IMGUIModule"].GetClass("GUI", "UnityEngine");
	}
}
