using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRTK.UnityEventHelper
{
    //  VRTK_UnityEvents<VRTK_UIPointer> -> MonoBehaviour
    public class VRTK_UIPointer_UnityEvents : MonoBehaviour
    {
        public VRTK_UIPointer_UnityEvents(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByNesestTypedName("UIPointerEvent");
    }
}