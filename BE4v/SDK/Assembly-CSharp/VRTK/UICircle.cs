using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using UnityEngine.UI;

namespace VRTK
{
    public class UICircle : Graphic
    {
        public UICircle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByFieldName("setTexture");
    }
}
