using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        public VerticalLayoutGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public VerticalLayoutGroup() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public void CalculateLayoutInputHorizontal()
		{
			Instance_Class.GetMethod(nameof(CalculateLayoutInputHorizontal)).Invoke(ptr);
		}

		public void CalculateLayoutInputVertical()
		{
			Instance_Class.GetMethod(nameof(CalculateLayoutInputVertical)).Invoke(ptr);
		}

		public void SetLayoutHorizontal()
		{
			Instance_Class.GetMethod(nameof(SetLayoutHorizontal)).Invoke(ptr);
		}

		public void SetLayoutVertical()
		{
			Instance_Class.GetMethod(nameof(SetLayoutVertical)).Invoke(ptr);
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("VerticalLayoutGroup", "UnityEngine.UI");
    }
}
