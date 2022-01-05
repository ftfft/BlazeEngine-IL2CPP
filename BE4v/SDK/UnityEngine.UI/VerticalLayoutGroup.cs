using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class VerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
    {
        public VerticalLayoutGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("VerticalLayoutGroup", "UnityEngine.UI");
    }
}
