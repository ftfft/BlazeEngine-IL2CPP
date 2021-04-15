using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BE4v.MenuEdit.Construct
{
    public class QuickToggler : QuickBaseObject
    {
        public GameObject btnOn;
        public GameObject btnOff;

        public QuickToggler(GameObject gameObject)
        {
            @type = "QuickToggler";
            base.gameObject = gameObject;
            isCustom = false;
        }
        
        public QuickToggler(string btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, UnityAction buttonAction, string btnTextOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            @type = "QuickToggler";
            Transform btnTemplate = QuickMenu.Instance.transform.Find("UserInteractMenu/BlockButton");

            gameObject = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnMenu), true);

            btnOn = gameObject.transform.Find("Toggle_States_Visible/ON").gameObject;
            btnOff = gameObject.transform.Find("Toggle_States_Visible/OFF").gameObject;

            MoveLocation(-2, -1);
            MoveLocation(btnXLocation, btnYLocation);

            setOnText(btnTextOn);
            setOffText(btnTextOff);
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].name = "Text_ON";
            btnTextsOn[1].name = "Text_OFF";
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].name = "Text_ON";
            btnTextsOff[1].name = "Text_OFF";

            setToolTip(btnToolTip);

            setAction(buttonAction, true);
            SetToggleToOn(false, false);

            if (btnBackgroundColor != null)
                setBackgroundColor(btnBackgroundColor.Value);
            if (btnTextColor != null)
                setTextColor(btnTextColor.Value);

            gameObject.SetActive(true);
        }


        public void setBackgroundColor(Color buttonBackgroundColor)
        {
            Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<Image>()).Concat(btnOff.GetComponentsInChildren<Image>()).ToArray()).Concat(gameObject.GetComponentsInChildren<Image>()).ToArray();
            foreach (Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
        }

        public void setTextColor(Color buttonTextColor)
        {
            Text[] btnTxtColorList = (btnOn.GetComponentsInChildren<Text>()).Concat(btnOff.GetComponentsInChildren<Text>()).ToArray();
            foreach (Text btnText in btnTxtColorList) btnText.color = buttonTextColor;
        }
        public void setOnText(string buttonOnText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
        }

        public void setOffText(string buttonOffText)
        {
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
        }

        public void SetToggleToOn(bool statusButton, bool disabledButton = false)
        {
            if (null != btnOn)
            {
                btnOn.SetActive(statusButton);
            }
            if (null != btnOff)
            {
                btnOff.SetActive(!statusButton);
            }
        }
    }
}
