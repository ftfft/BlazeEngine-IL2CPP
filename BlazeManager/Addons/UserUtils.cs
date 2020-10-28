using System;
using System.Collections.Generic;
using UnityEngine;
using VRCSDK2;
using BlazeIL;
using VRC.Core;
using VRC.UI;

namespace Addons
{
    public static class UserUtils
    {
        #region TeleportTo
        public static void TeleportTo(VRC.Player player) => TeleportTo(player.transform);
        public static void TeleportTo(GameObject gameObject) => TeleportTo(gameObject.transform);
        public static void TeleportTo(Transform transform) => TeleportTo(transform.position);
        public static void TeleportTo(Vector3 position) => VRC.Player.Instance.transform.position = position;
        #endregion

        #region SpawnPortal
        public static GameObject SpawnPortal(Transform transform, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde", string instanceId = "Banned Instance\nTupper\0")
        {
            GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", transform.position + (transform.forward * 2), new Quaternion(0,0,0,0));
            if (gameObject == null)
                return null;

            VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
            {
                IL2Import.il2cpp_string_new_len(worldId, worldId.Length),
                IL2Import.il2cpp_string_new_len(instanceId, instanceId.Length),
                IL2Import.CreateNewObject(0, BlazeTools.IL2SystemClass.Int32)
            });
            gameObject.GetComponent<PortalInternal>().enabled = false;

            return gameObject;
        }
        #endregion CreatePortal

        public static GameObject SpawnDynLight(Transform transform)
        {
            string[] arrayString = ObjectInstantiator.spawnBlockedList;
            ObjectInstantiator.spawnBlockedList = new string[0];
            GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Local, "DevProp_DynLight", transform.position + (transform.forward * 2), new Quaternion(0, 0, 0, 0));
            ObjectInstantiator.spawnBlockedList = arrayString;
            return gameObject;
        }

        public static void RemoveInstiatorObjects()
        {
            foreach(var obj in UnityEngine.Object.FindObjectsOfType<ObjectInstantiatorHandle>())
                obj.gameObject.Destroy();
            RoomManager.portalInternalList.Clear();
        }


        internal static APIUser current_User_UserInfo
        {
            get
            {
                // return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<VRCUiPage>()?.user;
                return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<PageUserInfo>()?.user;
            }
        }

        public static string[] kos_list
        {
            get
            {
                if (array_kos_list == null)
                {
                    BlazeWebAPI.WebRequest kos = new BlazeWebAPI.WebRequest("bz_kos");
                    kos.customWeb = new WebTools.CustomWeb();
                    string response = kos.customWeb._Get(BlazeWebAPI.API.standart_url + "bz_kos");
                    foreach(var str in response.Split('\n'))
                    {
                        if (str.Length < 40)
                            continue;

                        array_kos_list = str.Split('|');
                    }
                }
                return array_kos_list;
            }
        }

        public static List<string> Menu_AvatarsList = new List<string>();

        public static string prefix = (char)9999 + "_";

        private static string[] array_kos_list = null;
    }
}
