using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class CanvasGroup : Behaviour
	{
		public CanvasGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public CanvasGroup() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		unsafe public float alpha
		{
			get => Instance_Class.GetProperty(nameof(alpha)).GetGetMethod().Invoke(ptr).GetValuе<float>();
			set => Instance_Class.GetProperty(nameof(alpha)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool interactable
		{
			get => Instance_Class.GetProperty(nameof(interactable)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(interactable)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool blocksRaycasts
		{
			get => Instance_Class.GetProperty(nameof(blocksRaycasts)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(blocksRaycasts)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool ignoreParentGroups
		{
			get => Instance_Class.GetProperty(nameof(ignoreParentGroups)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(ignoreParentGroups)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return Instance_Class.GetMethod(nameof(IsRaycastLocationValid)).Invoke(ptr, new IntPtr[] { new IntPtr(&sp), (eventCamera == null) ? IntPtr.Zero : eventCamera.ptr }).GetValuе<bool>();
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UIModule"].GetClass("CanvasGroup", "UnityEngine");
	}
}
