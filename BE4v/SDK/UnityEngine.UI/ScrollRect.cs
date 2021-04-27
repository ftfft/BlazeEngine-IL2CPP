using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class ScrollRect : UIBehaviour
    {
        public ScrollRect(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("ScrollRect", "UnityEngine.UI");
    }
}
