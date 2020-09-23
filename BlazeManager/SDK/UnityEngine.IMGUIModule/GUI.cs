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
		public static void Box(Rect position, string text, bool isRusText = false)
		{
			if (m1_Box == null)
			{
				m1_Box = Instance_Class.GetMethod("Box", m => m.GetParameters().Length == 2);
				if (m1_Box == null)
					return;
			}
			m1_Box.Invoke(new IntPtr[] { position.MonoCast(), isRusText ? IL2Import.StringToIntPtrRU(text) : IL2Import.StringToIntPtr(text) });
		}
		/*

		public static void Box(Rect position, string text, GUIStyle style)
		{
		}

		public static void Box(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/
		public static void Label(Rect position, string text, bool isRusText = false)
		{
			Label(position, text, s_Skin.label, isRusText);
		}

		private static IL2Method m1_Label;
		public static void Label(Rect position, string text, GUIStyle style, bool isRusText = false)
		{

			if (m1_Label == null)
			{
				m1_Label = Instance_Class.GetMethod("Label", m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text");
				if (m1_Label == null)
					return;
			}
			m1_Label.Invoke(new IntPtr[] { position.MonoCast(), isRusText ? IL2Import.StringToIntPtrRU(text) : IL2Import.StringToIntPtr(text), style.ptr });
		}
		/*
		public static void Label(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/
		private static IL2Method m1_Button;
		public static bool Button(Rect position, IntPtr text)
		{
			if (m1_Button == null)
			{
				m1_Button = Instance_Class.GetMethod("Button", m => m.GetParameters().Length == 2);
				if (m1_Button == null)
					return false;
			}
			return m1_Button.Invoke(new IntPtr[] { position.MonoCast(), text }).MonoCast<bool>();
		}

		public static bool Button(Rect position, string text, bool isRusText = false)
		{
			if (m1_Button == null)
			{
				m1_Button = Instance_Class.GetMethod("Button", m => m.GetParameters().Length == 2);
				if (m1_Button == null)
					return false;
			}
			return m1_Button.Invoke(new IntPtr[] { position.MonoCast(), isRusText ? IL2Import.StringToIntPtrRU(text) : IL2Import.StringToIntPtr(text) }).MonoCast<bool>();
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
