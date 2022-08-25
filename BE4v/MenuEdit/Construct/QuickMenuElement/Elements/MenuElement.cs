using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using BE4v.MenuEdit.Construct;

namespace QuickMenuElement.Elements
{
    public class MenuElement : QuickObject
    {
        public string menuName
        {
            get
            {
                if (gameObject == null)
                    return null;
                string[] strings = gameObject.name.Split(new char[] { '_' }, 2);
                try
                {
                    if (strings.Length < 2 || strings[0] != "Menu")
                        return null;
                }
                catch { return null; }

                return strings[1];
            }
        }

        public VerticalLayoutGroup verticalLayoutGroup
        {
            get
            {
                return gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup")?.GetComponent<VerticalLayoutGroup>();
            }
        }

        public void SetText(string text)
        {
            TextMeshProUGUI title = gameObject.transform.Find("Header_H1/LeftItemContainer/Text_Title")?.GetComponent<TextMeshProUGUI>();
            if (title != null)
                title.text = text;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            QuickMenu.Instance.MenuStateController.PushPage(menuName);
        }

        public HeaderElement AddHeader(string name)
        {
            return HeaderElement.Create(this, name);
        }

        public ButtonsElement AddButtonsGroup(string name)
        {
            return ButtonsElement.Create(this, name);
        }

        public static MenuElement Create(string name, bool root = true)
        {
            MenuElement element = new MenuElement();
            element.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.menuTemplate.gameObject, QuickMenuUtils.menuTemplate.parent);
            element.gameObject.name = "Menu_" + name;

            Transform transform = element.gameObject.transform;
            transform.SetSiblingIndex(5);

            transform.gameObject.GetComponent<LaunchPadQMMenu>()?.Destroy();
            transform.gameObject.GetOrAddComponent<UIPage>()?.Destroy();

            UIPage uiPage = element.gameObject.AddComponent<UIPage>();
            uiPage.Name = name;
            uiPage._menuStateController = QuickMenu.Instance.MenuStateController;

            QuickMenu.Instance.MenuStateController._uiPages.Add(new IL2String_utf16(name), uiPage);

            VerticalLayoutGroup verticalLayoutGroup = element.verticalLayoutGroup;
            if (verticalLayoutGroup != null)
            {
                transform = verticalLayoutGroup.transform;
                foreach (Transform obj in transform)
                {
                    obj.gameObject?.Destroy();
                }

                verticalLayoutGroup.childControlHeight = false;
            }

            if (root)
            {
                List<UIPage> uIPages = QuickMenu.Instance.MenuStateController.menuRootPages.ToList();
                uIPages.Add(uiPage);
                QuickMenu.Instance.MenuStateController.menuRootPages = uIPages.ToArray();
            }

            element.SetText(name);

            RectMask2D mask = verticalLayoutGroup?.transform.parent.GetComponent<RectMask2D>();
            if (mask != null)
                mask.enabled = false;

            element.gameObject.SetActive(false);

            return element;
        }
    }
}
