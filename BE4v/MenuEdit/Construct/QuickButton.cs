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
            @type = "QuickButton";
            base.gameObject = gameObject;
            isCustom = false;
        }


        public QuickButton(string btnMenu, int btnXLocation, int btnYLocation, string btnText, UnityAction btnAction, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            @type = "QuickButton";
            location = btnMenu;
            Transform btnTemplate = QuickMenu.Instance.transform.Find("ShortcutMenu/WorldsButton");

            gameObject = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnMenu), true);

            MoveLocation(btnXLocation, btnYLocation);
            setButtonText(btnText);
            setToolTip(btnToolTip);
            setAction(btnAction, true);

            if (btnBackgroundColor != null)
                setBackgroundColor(btnBackgroundColor.Value);
            if (btnTextColor != null)
                setTextColor(btnTextColor.Value);

            gameObject.SetActive(true);
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

    }
}
