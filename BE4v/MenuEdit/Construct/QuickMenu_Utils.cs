using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public static class QuickMenu_Utils
    {
        public static GameObject CreateQuickMenu(string name)
        {
            return new GameObject(IntPtr.Zero);
        }

        public static GameObject BaseButton()
        {
            if (baseButton == null)
                baseButton = GameObject.Find("Button");
            return baseButton;
        }

        public static GameObject BaseToggler()
        {
            if (baseToggler == null)
                baseToggler = GameObject.Find("Toggler");
            return baseToggler;
        }

        private static GameObject baseButton;

        private static GameObject baseToggler;
    }
}
