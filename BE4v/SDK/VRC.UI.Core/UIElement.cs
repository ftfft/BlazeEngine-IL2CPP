using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Elements;

namespace VRC.UI.Core
{
    public class UIElement : MonoBehaviour
    {
        public UIElement(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = UIMenu.Instance_Class.BaseType;
    }
}