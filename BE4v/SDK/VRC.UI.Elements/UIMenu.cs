using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;

namespace VRC.UI.Elements
{
    public class UIMenu : UIElement
    {
        public UIMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public MenuStateController MenuStateController
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty("MenuStateController");
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(MenuStateController.Instance_Class)).Name = "MenuStateController";
                    if (property == null)
                        return null;
                }
                return property.GetGetMethod().Invoke(ptr).GetValue<MenuStateController>();
            }
        }

        public static new IL2Class Instance_Class = QuickMenu.Instance_Class.BaseType;
    }
}