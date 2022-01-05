using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRC.UI.Elements.Controls;

namespace BE4v.MenuEdit.Construct.Horizontal
{
    public class ElementHorizontalButton : QuickObject
    {
        public ElementHorizontalButton(string buttonName, UnityAction action)
        {

            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonHorizontal.gameObject, QuickMenuUtils.buttonHorizontal.parent);
            gameObject.name = "Page_" + buttonName;

            Button button = gameObject.GetComponent<Button>();
            if (button.onClick == null)
                button.onClick = new Button.ButtonClickedEvent();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);

            MenuTab menuTab = gameObject.GetComponent<MenuTab>();
            menuTab.pageName = "QuickMenu" + buttonName;

            gameObject.SetActive(true);

        }
    }
}
