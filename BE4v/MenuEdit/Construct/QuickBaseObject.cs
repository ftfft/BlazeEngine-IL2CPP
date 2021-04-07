using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace BE4v.MenuEdit.Construct
{
    public class QuickBaseObject
    {
        public void setAction(UnityAction buttonAction, bool newEvent = false)
        {
            Button button = gameObject.GetComponent<Button>();
            if (newEvent)
                button.onClick = new Button.ButtonClickedEvent();

            Button.ButtonClickedEvent clickEvent = button.onClick;
            if (!newEvent)
                clickEvent.RemoveAllListeners();

            clickEvent.AddListener(buttonAction);
        }

        public void setAction<T, X>(UnityAction<T> buttonAction, X _this, bool newEvent = false)
        {
            Button button = gameObject.GetComponent<Button>();
            if (newEvent)
                button.onClick = new Button.ButtonClickedEvent();

            Button.ButtonClickedEvent clickEvent = button.onClick;
            if (!newEvent)
                clickEvent.RemoveAllListeners();

            clickEvent.AddListener(buttonAction, _this);
        }

        public void setToolTip(string buttonToolTip)
        {
            UiTooltip uiTooltip = gameObject.GetComponent<UiTooltip>();
            uiTooltip.text = buttonToolTip;
            uiTooltip.alternateText = buttonToolTip;
        }

        public GameObject gameObject;

        public string @tag;

        public string @location;

        public float x;

        public float y;

        public bool isCustom = true;

        // public static readonly Vector2 offsetButton = QuickMenu_Utils.BaseButton().transform.MonoCast<RectTransform>().anchoredPosition;
    }
}
