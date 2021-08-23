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

        public static void ShowQuickmenuPage(string pagename, bool infoBar = false)
        {
            QuickMenu menu = QuickMenu.Instance;
            Transform transform = menu.transform.Find(pagename);
            if (transform == null)
            {
                "Not found menu!".RedPrefix("QuickMenuStuff");
                return;
            }

            menu._currentMenu?.SetActive(false);
            menu._currentMenu = transform.gameObject;
            /*
            foreach (Transform element in menu.transform)
            {
                if (element.name.Contains("QuickMenu_NewElements"))
                    continue;

                if (element.name.Contains("NotificationInteractMenu"))
                    continue;

                if (element.gameObject.active)
                    element.gameObject.SetActive(false);
            }
            */
            transform.gameObject.SetActive(true);
            GameObject _infoBar = menu._infoBar;
            if (_infoBar != null)
                _infoBar.SetActive(infoBar);
        }

        public static Transform CreateQuickMenu(string name)
        {
            Transform menu = UnityEngine.Object.Instantiate(QuickMenu.Instance.transform.Find("CameraMenu"), QuickMenu.Instance.transform);
            menu.name = name;

            foreach (Transform transform in menu.transform)
                UnityEngine.Object.Destroy(transform.gameObject);

            return menu;
        }

        public static Transform BaseButton() => baseButton ?? (baseButton = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton"));
        public static Transform BaseToggler() => baseToggler ?? (baseToggler = QuickMenu.Instance.transform.Find("UserInteractMenu/BlockButton"));

        private static Transform baseButton;

        private static Transform baseToggler;
    }
}
