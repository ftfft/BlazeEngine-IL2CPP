using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using BE4v.SDK.CPP2IL;
using TMPro;

namespace BE4v.MenuEdit.Construct.Menu
{
    public class ElementMenu : QuickObject
    {
        public string menuName { get; private set; }
        public ElementMenu(string name, bool root = true)
        {
            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.menuTemplate.gameObject, QuickMenuUtils.menuTemplate.parent);

            menuName = "Menu_" + name;
            gameObject.name = menuName;
            gameObject.SetActive(false);
            Transform transform = gameObject.transform;
            transform.SetSiblingIndex(5);

            gameObject.GetComponent<LaunchPadQMMenu>()?.Destroy();

            UIPage uiPage = gameObject.GetOrAddComponent<UIPage>();
            uiPage.Name = menuName;
            uiPage._menuStateController = QuickMenu.Instance.MenuStateController;
            
            QuickMenu.Instance.MenuStateController._uiPages.Add(new IL2String(menuName).ptr, uiPage.ptr);

            transform = transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            foreach (Transform obj in transform)
            {
                obj.gameObject?.Destroy();
            }

            if (root)
            {
                List<UIPage> uIPages = QuickMenu.Instance.MenuStateController.menuRootPages.ToList();
                uIPages.Add(uiPage);
                QuickMenu.Instance.MenuStateController.menuRootPages = uIPages.ToArray();
            }

            TextMeshProUGUI title = gameObject.transform.Find("Header_H1/LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
            title.text = name;
        }


        public void Open()
        {
            QuickMenu.Instance.MenuStateController.PushPage(menuName);
		}
    }
}
