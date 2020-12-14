using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using CustomQuickMenu;
using BlazeTools;
using VRC;
using VRC.Core;
using Addons;
using VRC.UI;
using Addons.Utils;
using WebSocketClient;

namespace BlazeManagerMenu
{
    internal static class Edit_WorldPanel
    {
        public static GameObject button_checkPlayersWorld { get; private set; }
        internal static void Start()
        {
            try
            {
                GameObject gameObject = GameObject.Find("MenuContent/Screens/WorldInfo/WorldImage/");
                GameObject original = GameObject.Find("MenuContent/Screens/WorldInfo/WorldButtons/NewButton");
                GameObject gameObject2 = GameObject.Find("MenuContent/Screens/WorldInfo/WorldButtons/");
                // FileDebug.debugGameObject("pageInfo.txt", gameObject_Path);
                button_checkPlayersWorld = UnityEngine.Object.Instantiate(original, gameObject2.transform);
                button_checkPlayersWorld.transform.SetParent(gameObject.transform);
                button_checkPlayersWorld.GetComponent<RectTransform>().anchoredPosition += new Vector2(-150, 75f * 10);
                button_checkPlayersWorld.GetComponentInChildren<Text>().text = "Players\nCheck";
                button_checkPlayersWorld.GetComponent<RectTransform>().sizeDelta = new Vector2(225, 100);
                Button button = button_checkPlayersWorld.GetComponentInChildren<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick = new Button.ButtonClickedEvent();
                button.onClick.AddListener(delegate () { checkPlayersWorld(); });
                /*

                GameObject gameObject = GameObject.Find("MenuContent/Screens/UserInfo/User Panel/");
                GameObject original = GameObject.Find("MenuContent/Screens/UserInfo/User Panel/Playlists/PlaylistsButton");
                GameObject gameObject2 = GameObject.Find("MenuContent/Screens/UserInfo/User Panel/Playlists");
                UserDropPortal = UnityEngine.Object.Instantiate(original, gameObject2.transform);
                UserDropPortal.transform.SetParent(gameObject.transform);
                UserDropPortal.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 75f);
                UserDropPortal.GetComponentInChildren<Text>().text = "Drop Portal to Instance";
                Button button = UserDropPortal.GetComponentInChildren<Button>();
                button.onClick.RemoveAllListeners();
                button.onClick = new Button.ButtonClickedEvent();
                button.onClick.AddListener(delegate () { DropPortalToUserClicked(); });
                */
            }
            catch (Exception)
            {
                ConSole.Error("UI: Portal to friend's");
            }
        }
        private static void checkPlayersWorld()
        {
            PageWorldInfo @object = GameObject.Find("UserInterface/MenuContent/Screens/WorldInfo")?.GetComponent<PageWorldInfo>();
            if (@object == null)
                return;
            string worldId = @object.world.id + ":" + @object.worldInstance.idWithTags;
            PhotonBot.SendConnect(worldId, (int)PhotonClient.API.PhotonNetwork.Cmd.check);
        }

    }
}
