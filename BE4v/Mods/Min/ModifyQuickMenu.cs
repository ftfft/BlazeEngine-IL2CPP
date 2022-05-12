using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BE4v.Mods.Core;
using BE4v.MenuEdit;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Menu;

namespace BE4v.Mods.Min
{
    public class ModifyQuickMenu : IUpdate
    {
        public static bool isLoadedMenu = false;
        public static bool isFinishLoad = false;
        public void Update()
        {
            if (isLoadedMenu && !isFinishLoad)
            {
                if (Delete())
                {
                    if (BE4V_MainMenu.BlazeEngine4VersionMenu())
                    {
                        BE4V_ModeMenu.BlazeEngine4VersionMenu();
                        isFinishLoad = true;
                    }
                }
            }
        }

        public static bool isDestroy_SafeMode = false;
        public static bool isDestroy_VRCBanner = false;
        public static bool isDestroy_BannerCarousel = false;
        public static bool Delete()
        {
            Transform transform = null;
            if (isDestroy_SafeMode == false)
            {
                transform = VRC.UI.Elements.QuickMenu.Instance.transform.Find("Container/Window/Toggle_SafeMode");
                if (transform != null)
                    transform.gameObject.Destroy();
                isDestroy_SafeMode = true;
                return false;
            }

            if (isDestroy_VRCBanner == false)
            {
                transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/VRC+_Banners");
                if (transform != null)
                    transform.gameObject.Destroy();
                isDestroy_VRCBanner = true;
                return false;
            }

            if (isDestroy_BannerCarousel == false)
            {
                transform = QuickMenuUtils.menuTemplate.Find("ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners");
                if (transform != null)
                    transform.gameObject.Destroy();
                isDestroy_BannerCarousel = true;
                return false;
            }

            return transform == null;
        }
    }
}
