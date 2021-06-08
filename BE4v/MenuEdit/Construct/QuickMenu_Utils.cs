using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public static class QuickMenu_Utils
    {
        public static class UserInteractMenu
        { 
            public static Transform buttonCloneAvatar
            {
                get
                {
                    foreach (Transform transform in QuickMenu.Instance.transform)
                    {
                        foreach (Transform transform1 in transform)
                        {
                            if (transform1.gameObject.name == "CloneAvatarButton")
                            {
                                return transform1;
                            }
                        }
                    }
                    return null;
                }
            }
        }
        public static GameObject CreateQuickMenu(string name)
        {
            return new GameObject(IntPtr.Zero);
        }

        public static Transform BaseButton() => baseButton ?? (baseButton = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton"));
        public static Transform BaseToggler() => baseToggler ?? (baseToggler = QuickMenu.Instance.transform.Find("UserInteractMenu/BlockButton"));

        private static Transform baseButton;

        private static Transform baseToggler;
    }
}
