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
    public class ElementButtonGroup : QuickObject
    {
        public ElementButtonGroup(string groupName, ElementMenu menu)
        {

            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonGroupHeaderTemplate.gameObject, menu.gameObject.transform);
            gameObject.name = "Header_" + groupName;

            TextMeshProUGUI buttonText = gameObject.transform.Find("LeftItemContainer/Text_Title").GetComponent<TextMeshProUGUI>();
            buttonText.text = groupName;

            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonGroupBaseTemplate.gameObject, menu.gameObject.transform);
            gameObject.name = "Base_" + groupName;

            Transform transform = gameObject.transform;
            foreach (Transform obj in transform)
            {
                obj.gameObject?.Destroy();
            }
        }
    }
}
