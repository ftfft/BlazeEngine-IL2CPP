using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class LayoutGroup : UIBehaviour
    {
        public LayoutGroup(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("LayoutGroup", "UnityEngine.UI");
    }
}
