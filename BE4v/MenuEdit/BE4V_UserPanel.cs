using Addons.Mods;
using BE4v.MenuEdit.Construct;
using BE4v.SDK;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;

namespace BE4v.MenuEdit
{
    public static class BE4V_UserPanel
    {
        public static GameObject UserDropPortal { get; private set; }
        public static void Start()
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
                button.onClick.AddListener(ClickClass_DropPortalToUser.PortalDrop);
                "[UI] Portals to friend's".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception)
            {
                "[UI] Portals to friend's".RedPrefix(TMessage.BadPatch);
            }
        }

    }

    public static class ClickClass_DropPortalToUser
    {
        public static void PortalDrop()
        {
            APIUser user = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<PageUserInfo>()?.user;
            if (user?.id == APIUser.CurrentUser.id)
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "You cannot drop a portal to yourself!");
                return;
            }
            string loc = user.location;
            if (string.IsNullOrWhiteSpace(loc))
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " has no valid location!");
                return;
            }
            if (loc == "private")
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " location is private!");
                return;
            }
            if (loc == "offline")
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " is offline!");
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
