using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;
using BE4v.MenuEdit.Construct;
using CustomQuickMenu.Menus;

namespace BE4v.MenuEdit
{
    public static class Core
    {
        
        public static void Install()
        {
            try
            {
                Delete();
            }
            catch { }
            try
            {
                MainMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                SelectedMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                BE4VMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                xGameMenu.BlazeEngine4VersionMenu();
            }
            catch { }
        }

        public static void Delete()
        {
            Transform transform = null;
            transform = QuickMenu.Instance.transform.Find("Container/Window/Toggle_SafeMode");
            if (transform != null)
                UnityEngine.Object.Destroy(transform.gameObject);

            transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/VRC+_Banners");
            if (transform != null)
                UnityEngine.Object.Destroy(transform.gameObject);

            transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners");
            if (transform != null)
                UnityEngine.Object.Destroy(transform.gameObject);
        }
    }
}
