using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BE4v.MenuEdit.Construct
{
    public class QuickButton : QuickBaseObject
    {
        public QuickButton(GameObject gameObject)
        {
            base.gameObject = gameObject;
        }


        public QuickButton(string btnMenu, int btnXLocation, int btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            location = btnMenu;
            Transform btnTemplate = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton");

            gameObject = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnMenu), true);

            setLocation(btnXLocation, btnYLocation);
            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction, true);

            if (btnBackgroundColor != null)
                setBackgroundColor(btnBackgroundColor.Value);
            if (btnTextColor != null)
                setTextColor(btnTextColor.Value);

            gameObject.SetActive(true);
        }

        // @location - Position in menu  Example: "QuickMenu/UIMenu"
        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            RectTransform rTransform = gameObject.transform.MonoCast<RectTransform>();
            x = buttonXLoc;
            y = buttonYLoc;
            rTransform.anchoredPosition += (Vector2.right * (420 * x)) + (Vector2.down * (420 * y));

            if (isCustom)
            {
                @tag = "(" + x + "," + y + ")";
                gameObject.name = @location + "/" + type + @tag;
                gameObject.GetComponent<Button>().gameObject.name = type + @tag;
            }
        }

        public void setButtonText(string buttonText)
        {
            gameObject.GetComponentInChildren<Text>().text = buttonText;
        }

        public void setBackgroundColor(Color buttonBackgroundColor)
        {
            gameObject.GetComponentInChildren<Image>().color = buttonBackgroundColor;
        }

        public void setTextColor(Color buttonTextColor)
        {
            gameObject.GetComponentInChildren<Text>().color = buttonTextColor;
        }

        public static readonly string type = "QuickButton";
    }
}
