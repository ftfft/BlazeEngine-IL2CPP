using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Elements;

namespace VRC.UI.Core.Styles
{
    public class StyleElement : MonoBehaviour
    {
        public StyleElement(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Class Instance_Class = Instance_Class = Assembler.list["VRC.UI.Core"].GetClass("StyleElement", "VRC.UI.Core.Styles");
    }
}