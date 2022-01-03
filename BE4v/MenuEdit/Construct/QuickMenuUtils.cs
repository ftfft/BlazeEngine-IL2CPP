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

        public static string szHorizontalGroup = "Container/Window/Page_Buttons_QM/HorizontalLayoutGroup";
    }
}
