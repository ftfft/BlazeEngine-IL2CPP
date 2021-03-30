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
        // @location - Position in menu  Example: "QuickMenu/UIMenu"
        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            RectTransform rTransform = gameObject.transform.MonoCast<RectTransform>();
            x = buttonXLoc;
            y = buttonYLoc;
            Vector2 basePosition = QuickMenu_Utils.BaseButton().transform.MonoCast<RectTransform>().anchoredPosition;
            rTransform.anchoredPosition = basePosition + (Vector2.right * (420 * x)) + (Vector2.down * (420 * y));

            @tag = "(" + x + "," + y + ")";
            gameObject.name = @location + "/" + type + @tag;
            gameObject.GetComponent<Button>().gameObject.name = type + @tag;
        }

        public static readonly string type = "QuickButton";
    }
}
