using System;
using UnityEngine;
using UnityEngine.UI;
using BlazeIL.il2cpp;

namespace CustomQuickMenu
{
    public class QuickMenuStuff
    {
        public static string CreateCustomMenu(string menuName)
        {

            Transform menu = UnityEngine.Object.Instantiate<Transform>(QuickMenu.Instance.transform.Find("CameraMenu"), QuickMenu.Instance.transform);
            menu.name = menuName;

            foreach (Transform transform in menu.transform)
            {
                UnityEngine.Object.Destroy(transform.gameObject);
            }

            return menu.name;
        }

        private static IL2Field currentPageGetter = null;
        public static void ShowQuickmenuPage(string pagename)
        {
            QuickMenu.Instance.SetMenuIndex(0);
            GameObject gameObject = null;
            Transform transform = null;
            if (currentPageGetter == null)
            {
                if (currentPageGetter == null)
                {
                    int num = 0;
                    gameObject = QuickMenu.Instance.transform.Find("ShortcutMenu").gameObject;
                    foreach (IL2Field field in QuickMenu.Instance_Class.GetFields())
                    {
                        if (field.HasFlag(IL2BindingFlags.FIELD_STATIC))
                            continue;

                        if (field.HasFlag(IL2BindingFlags.FIELD_PRIVATE))
                        {
                            IL2Object fieldResult = field.GetValue(QuickMenu.Instance.ptr);
                            if (fieldResult == null)
                                continue;

                            if (fieldResult.ptr == gameObject.ptr)
                            {
                                if(num++ == 1)
                                {
                                    // Console.WriteLine("[QuickMenuUtils] currentPage field [1]: " + field.Name);
                                    currentPageGetter = field;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (currentPageGetter == null)
                {
                    int num = 0;
                    gameObject = QuickMenu.Instance.transform.Find("UserInteractMenu").gameObject;
                    foreach (IL2Field field in QuickMenu.Instance_Class.GetFields())
                    {
                        if (field.HasFlag(IL2BindingFlags.FIELD_STATIC))
                            continue;

                        if (field.HasFlag(IL2BindingFlags.FIELD_PRIVATE))
                        {
                            IL2Object fieldResult = field.GetValue(QuickMenu.Instance.ptr);
                            if (fieldResult == null)
                                continue;

                            if (fieldResult.ptr == gameObject.ptr)
                            {
                                if (num++ == 1)
                                {
                                    // Console.WriteLine("[QuickMenuUtils] currentPage field [2]: " + field.Name);
                                    currentPageGetter = field;
                                    break;
                                }

                            }
                        }
                    }
                }

                if (currentPageGetter == null)
                {
                    Console.WriteLine("[QuickMenuUtils] Unable to find field currentPage in QuickMenu");
                    return;
                }
            }

            gameObject = currentPageGetter.GetValue(QuickMenu.Instance.ptr).ptr.MonoCast<GameObject>();
            gameObject.SetActive(false);
            QuickMenu.Instance.transform.Find("QuickMenu_NewElements/_InfoBar").gameObject.SetActive(false);
            transform = QuickMenu.Instance.transform.Find(pagename);
            currentPageGetter.SetValue(QuickMenu.Instance.ptr, transform.gameObject.ptr);
            transform.gameObject.SetActive(true);
        }

        public static void ChangeColorButtons(Color? backgroundColor = null, Color? textColor = null)
        {
            if (backgroundColor == null && textColor == null)
            {
                BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ChangeColorButtons").Invoke(null, new object[] { StatusBuff.buttonBackgroundColor, StatusBuff.buttonTextColor });
                return;
            }

            foreach (Transform child in QuickMenu.Instance.transform)
            {
                foreach (Button button in child.gameObject.GetComponentsInChildren<Button>())
                {
                    if (backgroundColor != null)
                    {
                        foreach (Image background in button.gameObject.GetComponentsInChildren<Image>(true))
                        {
                            background.color = (Color)backgroundColor;
                            StatusBuff.buttonBackgroundColor = (Color)backgroundColor;
                        }
                    }
                    if (textColor != null)
                    {
                        foreach (Text text in button.gameObject.GetComponentsInChildren<Text>(true))
                        {
                            text.color = (Color)textColor;
                            StatusBuff.buttonTextColor = (Color)textColor;
                        }
                    }
                }
            }
        }
        public static void ChangeColorMenu(Color? backgroundColor = null, Color? textColor = null)
        {
            if (backgroundColor == null && textColor == null)
            {
                BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ChangeColorMenu").Invoke(null, new object[] { StatusBuff.menuBackgroundColor, StatusBuff.menuTextColor });
                return;
            }

            foreach (Transform child in QuickMenu.Instance.transform)
            {
                if (backgroundColor != null)
                {
                    foreach (Image background in child.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        background.color = (Color)backgroundColor;
                        StatusBuff.menuBackgroundColor = (Color)backgroundColor;
                    }
                }
                if (textColor != null)
                {
                    foreach (Text text in child.gameObject.GetComponentsInChildren<Text>(true))
                    {
                        text.color = (Color)textColor;
                        StatusBuff.menuTextColor = (Color)textColor;
                    }
                }
            }
        }
    }
}
