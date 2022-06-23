using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.UI.Elements;

namespace VRC.UI.Core
{
    public class UIElement : MonoBehaviour
    {
        public UIElement(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = UIMenu.Instance_Class.BaseType;
    }
}