using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using VRC.UI.Elements;

namespace BE4v.MenuEdit.Construct
{
    public class QuickButton_PB : QuickBaseObject
    {
        public QuickButton_PB(GameObject gameObject)
        {
            @type = "QuickButton_PB";
            base.gameObject = gameObject;
            isCustom = false;
        }
        
        public QuickButton_PB(int btnXLocation, int btnYLocation, string btnTextOn, UnityAction buttonAction, string btnTextOff, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null)
        {
            @type = "QuickButton_PB";
            Transform btnTemplate = QuickMenu_Utils.QuickButton_PB();

            gameObject = UnityEngine.Object.Instantiate<GameObject>(btnTemplate.gameObject, QuickMenu.Instance.transform.Find("Container/Window/Page_Buttons_QM/HorizontalLayoutGroup"), true);

            //MoveLocation(-2, -1);
            //MoveLocation(btnXLocation, btnYLocation);
            /*
            Text[] btnTextsOn = btnOn.GetComponentsInChildren<Text>();
            Text[] btnTextsOff = btnOff.GetComponentsInChildren<Text>();
            btnTextsOn[0].name = btnTextsOff[0].name = "Text_ON";
            btnTextsOn[1].name = btnTextsOff[1].name = "Text_OFF";
            */
            // setToolTip(btnToolTip);

            setAction(buttonAction, true);
            gameObject.SetActive(true);
        }

    }
}
