using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class LayoutGroup : UIBehaviour
    {
        public LayoutGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public TextAnchor childAlignment
		{
			get => Instance_Class.GetProperty(nameof(childAlignment)).GetGetMethod().Invoke(ptr).GetValuе<TextAnchor>();
			set => Instance_Class.GetProperty(nameof(childAlignment)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("LayoutGroup", "UnityEngine.UI");
    }
}
