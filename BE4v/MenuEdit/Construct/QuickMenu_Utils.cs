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
                    return QuickMenu.Instance?.transform.Find("Button_CloneAvatar");
                }
            }
        }

        public static void ShowQuickmenuPage(string pagename, bool infoBar = false)
        {
            QuickMenu menu = QuickMenu.Instance;
            GameObject gameObject = menu.transform.Find(pagename)?.gameObject;
            if (gameObject == null)
            {
                "Not found menu!".RedPrefix("QuickMenuStuff");
                return;
            }

            menu._currentMenu?.SetActive(false);
            menu._currentMenu = gameObject;
            gameObject.SetActive(true);
            GameObject _infoBar = menu._infoBar;
            if (_infoBar != null)
                _infoBar.SetActive(infoBar);
        }

        public static Transform CreateQuickMenu(string name)
        {
            Transform menu = UnityEngine.Object.Instantiate(QuickMenu.Instance.transform.Find("Menu_Camera"), QuickMenu.Instance.transform);
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
