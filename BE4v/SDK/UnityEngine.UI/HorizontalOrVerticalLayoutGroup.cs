using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup
    {
        public HorizontalOrVerticalLayoutGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public bool childControlHeight
		{
			get => Instance_Class.GetProperty(nameof(childControlHeight)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(childControlHeight)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

	public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("HorizontalOrVerticalLayoutGroup", "UnityEngine.UI");
    }
}
