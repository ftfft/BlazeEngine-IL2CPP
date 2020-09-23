using System;
using UnityEngine;
using UnityEngine.UI;
using CustomQuickMenu;
using BlazeTools;
using VRC;
using VRC.Core;
using Addons;

namespace BlazeManagerMenu
{
    internal static class Edit_UserPanel
    {
        public static void OnEnter_ShowProfile()
        {
            APIUser user = UserUtils.current_User_UserInfo;
            if (user.id == APIUser.CurrentUser.id
            || string.IsNullOrEmpty(user.location)
            || user.location == "private"
            || user.location == "offline")
            {
                UserDropPortal.SetActive(false);
                return;
            }
            UserDropPortal.SetActive(true);
        }

        public static GameObject UserDropPortal { get; private set; }
        internal static void Start()
        {
            try
            {
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
            }
            catch (Exception)
            {
                ConSole.Error("UI: Portal to friend's");
            }
        }
        private static void DropPortalToUserClicked()
        {
            APIUser user = UserUtils.current_User_UserInfo;
            if (user?.id == APIUser.CurrentUser.id)
            {
                Console.WriteLine("Error: You cannot drop a portal to yourself!");
                // MiscUtils.VRCUiPopupManager.ShowAlert("Error", "You cannot drop a portal to yourself!", 10f);
                return;
            }
            string loc = user.location;
            if (string.IsNullOrWhiteSpace(loc))
            {
                Console.WriteLine("Error: No valid location");
                //MiscUtils.VRCUiPopupManager.ShowAlert("Error", "Player " + user.displayName + " has no valid location!", 10f);
                return;
            }
            if (loc == "private")
            {
                Console.WriteLine("Error: Player " + user.displayName + " location is private!");
                // MiscUtils.VRCUiPopupManager.ShowAlert("Error", "Player " + user.displayName + " location is private!", 10f);
                return;
            }
            if (loc == "offline")
            {
                Console.WriteLine("Error: Player " + user.displayName + " is offline!");
                // MiscUtils.VRCUiPopupManager.ShowAlert("Error", "Player " + user.displayName + " is offline!", 10f);
                return;
            }
            string[] location = loc.Split(new char[]
            {
                ':'
            });
            UserUtils.SpawnPortal(VRCPlayer.Instance.transform, location[0], location[1]);
        }
    }
}
