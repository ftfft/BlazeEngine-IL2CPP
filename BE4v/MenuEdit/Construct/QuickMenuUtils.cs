using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;

namespace BE4v.MenuEdit.Construct
{
    public static class QuickMenuUtils
    {
        private static Transform _buttonHorizontal = null;
        public static Transform buttonHorizontal
        {
            get
            {
                if (_buttonHorizontal == null)
                {
                    _buttonHorizontal = QuickMenu.Instance.transform.Find(szHorizontalGroup + "/Page_Dashboard");
                }
                return _buttonHorizontal;
            }
        }

        private static Transform _buttonTemplate = null;
        public static Transform buttonTemplate
        {
            get
            {
                if (_buttonTemplate == null)
                {
                    _buttonTemplate = QuickMenu.Instance.transform.Find(szButtonGroup + "/Button_Respawn");
                }
                return _buttonTemplate;
            }
        }
        
        private static Transform _buttonGroupHeaderTemplate = null;
        public static Transform buttonGroupHeaderTemplate
        {
            get
            {
                if (_buttonGroupHeaderTemplate == null)
                {
                    _buttonGroupHeaderTemplate = QuickMenu.Instance.transform.Find(szButtonGroupsGroup + "/Header_QuickActions");
                }
                return _buttonGroupHeaderTemplate;
            }
        }
        
        private static Transform _buttonGroupBaseTemplate = null;
        public static Transform buttonGroupBaseTemplate
        {
            get
            {
                if (_buttonGroupBaseTemplate == null)
                {
                    _buttonGroupBaseTemplate = QuickMenu.Instance.transform.Find(szButtonGroupsGroup + "/Buttons_QuickActions");
                }
                return _buttonGroupBaseTemplate;
            }
        }

        private static Transform _menuTemplate = null;
        public static Transform menuTemplate
        {
            get
            {
                if (_menuTemplate == null)
                {
                    _menuTemplate = QuickMenu.Instance.transform.Find(szMenuGroup + "/Menu_Dashboard");
                }
                return _menuTemplate;
            }
        }

        public static string szHorizontalGroup = "Container/Window/Page_Buttons_QM/HorizontalLayoutGroup";

        public static string szButtonGroup = "Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions";

        public static string szButtonGroupsGroup = "Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup";

        public static string szMenuGroup = "Container/Window/QMParent";
    }
}
