using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BE4v.MenuEdit.Construct.Menu
{
    public class ElementButton : QuickObject
    {
        public ElementButton(string buttonName, ElementMenu menu, UnityEngine.Events.UnityAction action)
        {

            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonTemplate.gameObject, menu.gameObject.transform);
            
            TextMeshProUGUI buttonText = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            buttonText.text = buttonName;

            Button button = gameObject.GetComponentInChildren<Button>(true);
            if (button.onClick == null)
                button.onClick = new Button.ButtonClickedEvent();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);


            gameObject.SetActive(true);
        }
    }
}
