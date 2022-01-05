using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.MenuEdit.Construct
{
    public class UIButton : QuickObject
    {
        public UIButton(GameObject gameObject)
        {
            base.gameObject = gameObject;
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
