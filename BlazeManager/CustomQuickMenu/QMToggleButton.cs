using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomQuickMenu
{
    public class QMToggleButton : QuickMenuBase
    {
        public GameObject btnToggle;

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

            btnToggle = button.transform.Find("Toggle_States_Visible").gameObject;
            btnToggle.GetComponent<UiToggleButton>().Awake();

            initShift[0] = -4;
            initShift[1] = 0;
            setLocation(btnXLocation, btnYLocation);

            setOnText(btnTextOn);
            setOffText(btnTextOff);
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
            UiToggleButton uiToggleButton = btnToggle.GetComponent<UiToggleButton>();
            Image[] btnBgColorList = ((uiToggleButton.toggledOnButton.GetComponentsInChildren<Image>()).Concat(uiToggleButton.toggledOffButton.GetComponentsInChildren<Image>()).ToArray()).Concat(button.GetComponentsInChildren<Image>()).ToArray();
            foreach (Image btnBackground in btnBgColorList) btnBackground.color = buttonBackgroundColor;
        }

        public void setTextColor(Color buttonTextColor)
        {
            UiToggleButton uiToggleButton = btnToggle.GetComponent<UiToggleButton>();
            Text[] btnTxtColorList = (uiToggleButton.toggledOnButton.GetComponentsInChildren<Text>()).Concat(uiToggleButton.toggledOffButton.GetComponentsInChildren<Text>()).ToArray();
            foreach (Text btnText in btnTxtColorList) btnText.color = buttonTextColor;
        }

        public void setOnText(string buttonOnText)
        {
            UiToggleButton uiToggleButton = btnToggle.GetComponent<UiToggleButton>();
            Text[] btnTextsOn = uiToggleButton.toggledOnButton.GetComponentsInChildren<Text>();
            btnTextsOn[0].text = buttonOnText;
            Text[] btnTextsOff = uiToggleButton.toggledOffButton.GetComponentsInChildren<Text>();
            btnTextsOff[0].text = buttonOnText;
        }

        public void setOffText(string buttonOffText)
        {
            UiToggleButton uiToggleButton = btnToggle.GetComponent<UiToggleButton>();
            Text[] btnTextsOn = uiToggleButton.toggledOnButton.GetComponentsInChildren<Text>();
            btnTextsOn[1].text = buttonOffText;
            Text[] btnTextsOff = uiToggleButton.toggledOffButton.GetComponentsInChildren<Text>();
            btnTextsOff[1].text = buttonOffText;
        }

        public void SetToggleToOn(bool statusButton, bool disabledButton = false)
        {
            btnToggle.GetComponent<UiToggleButton>().SetToggleToOn(statusButton, disabledButton);
        }
    }
}
