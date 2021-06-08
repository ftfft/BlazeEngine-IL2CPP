using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.MenuEdit.Construct
{
    public class UIButton : QuickBaseObject
    {
        public UIButton(GameObject gameObject)
        {
            @type = "UIButton";
            base.gameObject = gameObject;
            isCustom = false;
            buttonSize = new float[]{ 1f, 1f };
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
