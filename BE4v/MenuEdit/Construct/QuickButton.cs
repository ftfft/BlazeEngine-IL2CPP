using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.MenuEdit.Construct
{
    public class QuickButton : QuickBaseObject
    {
        public QuickButton(GameObject gameObject)
        {
            base.gameObject = gameObject;
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
