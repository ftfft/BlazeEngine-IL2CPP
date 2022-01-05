using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class RectMask2D : UIBehaviour
    {
        public RectMask2D(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("RectMask2D", "UnityEngine.UI");
    }
}
