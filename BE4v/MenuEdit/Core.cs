﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;
using BE4v.MenuEdit.Construct;

namespace BE4v.MenuEdit
{
    public static class Core
    {
        
        public static void Install()
        {
            Delete();
            BE4V_MainMenu.BlazeEngine4VersionMenu();
            BE4V_ModeMenu.BlazeEngine4VersionMenu();

            // QuickMenu.Instance.MenuStateController.PushPage("Page_BlazeEngine4Version");
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
