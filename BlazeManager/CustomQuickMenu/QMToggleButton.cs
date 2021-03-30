using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomQuickMenu
{
    public class QMToggleButton : QuickMenuBase
    {
        public GameObject btnOn;
        public GameObject btnOff;

        public QMToggleButton(string btnMenu, int btnXLocation, int btnYLocation, string btnTextOn, UnityAction buttonAction, string btnTextOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            btnQMLoc = btnMenu;
            btnType = "ToggleButton";
            initButton(btnXLocation, btnYLocation, btnTextOn, buttonAction, btnTextOff, btnToolTip, btnBackgroundColor, btnTextColor);
        }

        private void initButton(int btnXLocation, int btnYLocation, string btnTextOn, UnityAction buttonAction, string btnTextOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            Transform btnTemplate = QuickMenu.Instance.transform.Find("UserInteractMenu/BlockButton");

            button = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find(btnQMLoc), true);

            btnOn = button.transform.Find("Toggle_States_Visible/ON").gameObject;
            btnOff = button.transform.Find("Toggle_States_Visible/OFF").gameObject;
            
            initShift[0] = -3;
            initShift[1] = -1;
            setLocation(btnXLocation, btnYLocation);

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

            setActive(true);

        }

        public void setBackgroundColor(Color buttonBackgroundColor)
        {
            UnityEngine.UI.Image[] btnBgColorList = ((btnOn.GetComponentsInChildren<UnityEngine.UI.Image>()).Concat(btnOff.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray()).Concat(button.GetComponentsInChildren<UnityEngine.UI.Image>()).ToArray();
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
