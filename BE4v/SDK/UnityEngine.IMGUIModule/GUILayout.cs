using System;
using System.Linq;
using System.Text;
using BE4v.SDK.CPP2IL;
using UnityEngine.UI;

namespace UnityEngine
{
	public class GUILayout
	{
		public static void Label(string text, params GUILayoutOption[] options)
		{
			Instance_Class.GetMethod(nameof(Label), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "text").Invoke(new IntPtr[] { new IL2String(text).ptr, (options == null || options.Length == 0) ? IntPtr.Zero : options.Select(x => x.ptr).ToArray().ArrayToIntPtr(GUILayoutOption.Instance_Class) });
		}

		unsafe public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
		{
			return Instance_Class.GetMethod(nameof(BeginScrollView), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { new IntPtr(&scrollPosition), (options == null || options.Length == 0) ? IntPtr.Zero : options.Select(x => x.ptr).ToArray().ArrayToIntPtr(GUILayoutOption.Instance_Class) }).GetValuе<Vector2>();
		}

		public static void EndScrollView()
		{
			Instance_Class.GetMethod(nameof(EndScrollView), x => x.GetParameters().Length == 0).Invoke();
		}

		public static void BeginHorizontal(params GUILayoutOption[] options)
		{
			Instance_Class.GetMethod(nameof(BeginHorizontal), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { (options == null || options.Length == 0) ? IntPtr.Zero : options.Select(x => x.ptr).ToArray().ArrayToIntPtr(GUILayoutOption.Instance_Class) });
		}

		public static void EndHorizontal()
		{
			Instance_Class.GetMethod(nameof(EndHorizontal)).Invoke();
		}

		unsafe public static void BeginArea(Rect screenRect)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { new IntPtr(&screenRect) });
		}

		unsafe public static void BeginArea(Rect screenRect, GUIStyle style)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "style").Invoke(new IntPtr[] { new IntPtr(&screenRect), style == null ? IntPtr.Zero : style.ptr });
		}

		unsafe public static void BeginArea(Rect screenRect, Texture image)
		{
			Instance_Class.GetMethod(nameof(BeginArea), x => x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "image").Invoke(new IntPtr[] { new IntPtr(&screenRect), image == null ? IntPtr.Zero : image.ptr });
		}

		public static void EndArea()
		{
			Instance_Class.GetMethod(nameof(EndArea)).Invoke();
		}

		public static bool Button(string text, params GUILayoutOption[] options)
		{
			IL2Object obj = Instance_Class.GetMethod(nameof(Label), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "text").Invoke(new IntPtr[] { new IL2String(text).ptr, (options == null || options.Length == 0) ? IntPtr.Zero : options.Select(x => x.ptr).ToArray().ArrayToIntPtr(GUILayoutOption.Instance_Class) });
			if (obj == null)
				return false;

			return obj.GetValuе<bool>();
		}

		public static void Box(Texture image, params GUILayoutOption[] options)
		{
			Instance_Class.GetMethod(nameof(Box), x => x.GetParameters().Length == 2 && x.GetParameters()[0].Name == "image").Invoke(new IntPtr[] { image == null ? IntPtr.Zero : image.ptr, (options == null || options.Length == 0) ? IntPtr.Zero : options.Select(x => x.ptr).ToArray().ArrayToIntPtr(GUILayoutOption.Instance_Class) });
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUILayout", "UnityEngine");
	}
}
