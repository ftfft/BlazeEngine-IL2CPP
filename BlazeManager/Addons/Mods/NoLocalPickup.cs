using System.Collections.Generic;
using UnityEngine;

namespace Addons.Mods
{
    public static class NoLocalPickup
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Hide Pickup", !BlazeManager.GetForPlayer<bool>("Hide Pickup"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Hide Pickup");
            BlazeManagerMenu.Main.togglerList["Hide Pickup"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Hide Pickup"].btnOff.SetActive(!toggle);
            Update();
        }

        public static void Update()
        {
            ScanObjects();
            if (BlazeManager.GetForPlayer<bool>("Hide Pickup"))
            {
                HideAllObjects();
            }
            else
            {
                ShowAllObjects();
            }
        }

        private static void ScanObjects()
        {

            foreach (var obj in Object.FindObjectsOfType<VRCSDK2.VRC_Pickup>())
            {
                GameObject gameObject = obj.gameObject;
                if (isValidObject(gameObject))
                    gameObjects.Add(gameObject);
            }
            foreach (var obj in Object.FindObjectsOfType<VRC.SDK3.Components.VRCPickup>())
            {
                GameObject gameObject = obj.gameObject;
                if (isValidObject(gameObject))
                    gameObjects.Add(gameObject);
            }
        }

        private static bool isValidObject(GameObject gameObject) => !gameObjects.Contains(gameObject) && gameObject.GetComponent(typeof(ObjectInstantiatorHandle)) == null;

        public static void ClearObjects() => gameObjects.Clear();

        public static void HideAllObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }
        }

        public static void ShowAllObjects()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(true);
            }
        }

        public static List<GameObject> gameObjects = new List<GameObject>();
    }
}
