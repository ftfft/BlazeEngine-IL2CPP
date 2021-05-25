using BE4v.SDK.CPP2IL;
using System;
using System.Text;

namespace UnityEngine
{
	public class GUI
	{
		unsafe public static Color contentColor
		{
			get => Instance_Class.GetProperty(nameof(contentColor)).GetGetMethod().Invoke().GetValuе<Color>();
			set => Instance_Class.GetProperty(nameof(contentColor)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public static void Box(Rect position, string text) => Box(new IntPtr(&position), new IL2String(text).ptr);
		unsafe public static void Box(Rect position, IntPtr text) => Box(new IntPtr(&position), text);
		public static void Box(IntPtr position, string text) => Box(position, new IL2String(text).ptr);
		public static void Box(IntPtr position, IntPtr text)
		{
			Instance_Class.GetMethod(nameof(Box), m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text").Invoke(new IntPtr[] { position, text, s_Skin.box.ptr });
		}

		/*

		public static void Box(Rect position, string text, GUIStyle style)
		{
		}

		public static void Box(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/

		unsafe public static void Label(Rect position, string text) => Label(new IntPtr(&position), new IL2String(text).ptr, s_Skin.label.ptr);
		unsafe public static void Label(Rect position, IntPtr text) => Label(new IntPtr(&position), text, s_Skin.label.ptr);
		public static void Label(IntPtr position, string text) => Label(position, new IL2String(text).ptr, s_Skin.label.ptr);
		public static void Label(IntPtr position, IntPtr text) => Label(position, text, s_Skin.label.ptr);
		unsafe public static void Label(Rect position, IntPtr text, IntPtr style) => Label(new IntPtr(&position), text, style);
		unsafe public static void Label(Rect position, string text, IntPtr style) => Label(new IntPtr(&position), new IL2String(text).ptr, style);
		unsafe public static void Label(Rect position, string text, GUIStyle style) => Label(new IntPtr(&position), new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, string text, IntPtr style) => Label(position, new IL2String(text).ptr, style);
		public static void Label(IntPtr position, string text, GUIStyle style) => Label(position, new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, IntPtr text, GUIStyle style) => Label(position, new IL2String(text).ptr, style.ptr);
		public static void Label(IntPtr position, IntPtr text, IntPtr style)
		{
			Instance_Class.GetMethod(nameof(Label), m => m.GetParameters().Length == 3 && m.GetParameters()[1].Name == "text").Invoke(new IntPtr[] { position, text, style });
		}
		/*
		public static void Label(Rect position, GUIContent content, GUIStyle style)
		{
		}
		*/
		unsafe public static bool Button(Rect position, string text) => Button(new IntPtr(&position), new IL2String(text).ptr);
		unsafe public static bool Button(Rect position, IntPtr text) => Button(new IntPtr(&position), text);
		public static bool Button(IntPtr position, string text) => Button(position, new IL2String(text).ptr);
		public static bool Button(IntPtr position, IntPtr text)
		{
			return Instance_Class.GetMethod(nameof(Button), m => m.GetParameters().Length == 2).Invoke(new IntPtr[] { position, text }).GetValuе<bool>();
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
		private static GUISkin s_Skin
		{
			get => Instance_Class.GetField(nameof(s_Skin)).GetValue()?.GetValue<GUISkin>();
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUI", "UnityEngine");
	}
}
