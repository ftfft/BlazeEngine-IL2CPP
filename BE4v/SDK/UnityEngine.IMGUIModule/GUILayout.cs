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


		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUILayout", "UnityEngine");
	}
}
