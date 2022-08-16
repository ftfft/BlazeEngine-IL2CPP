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
    public class ElementGroup : QuickObject
    {
        public ElementGroup(GameObject elementGroup)
        {
            gameObject = elementGroup;
        }
        public ElementGroup(string groupName, ElementMenu menu)
        {
            gameObject = CreateObject(groupName, menu.verticalLayoutGroup.gameObject);
        }
        public ElementGroup(string groupName, ElementGroup menu)
        {
            gameObject = CreateObject(groupName, menu.gameObject);
        }

        private GameObject CreateObject(string groupName, GameObject menu)
        {

            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonGroupHeaderTemplate.gameObject, menu.transform);
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
            return gameObject;
        }
    }
}
