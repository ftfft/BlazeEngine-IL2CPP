using System;
using UnityEngine;
using BE4v.Utils;
using BE4v.Mods;
using BE4v.Mods.Core;
using BE4v.Mods.Min;

namespace BE4v.MenuEdit.IMGUI
{
    public class TabMenu : IUpdate, IOnGUI
    {
        public static bool isPressed = false;
        
        public void Update()
        {
            isPressed = Input.GetKey(KeyCode.Tab);

            VRCPlayer sitOnPlayer = SitOnHead.SelectUser;
            if (sitOnPlayer == null || sitOnPlayer == VRCPlayer.Instance)
                sitOnPlayer = null;

            try
            {
                if (sitOnPlayer != null)
                {
                    VRC.Player[] playerArray = NetworkSanity.NetworkSanity.players;
                    foreach (var player in playerArray)
                    {
                        VRCPlayer components = player?.Components;
                        if (sitOnPlayer == components)
                        {
                            SitOnHead.SelectUser = components;
                        }
                    }
                }
                if (sitOnPlayer != SitOnHead.SelectUser)
                    SitOnHead.SelectUser = null;
            }
            catch
            {
            }

        }

        public void OnGUI()
        {
            NotifySystem.Notify.OnGUI();
            try
            {
                if (!isPressed) return;
                GUI.backgroundColor = new Color(0, 255, 0);
                int SizeX1 = Screen.width - (iLeftMargin * 2);
                // GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 100), strTabMenuBold.ptr);
                GUI.Label(new Rect(120, iTopMargin, 40, 20), "<b>#</b>");
                GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), "<b>displayName</b>");

                int iPlayer = 0;
                VRC.Player[] playerArray = NetworkSanity.NetworkSanity.players;
                foreach (var player in playerArray)
                {
                    int? playerId = player?.PhotonPlayer?.ActorNumber;
                    if (playerId == null) continue;
                    if (iSelectUser == playerId)
                    {
                        if (uSelectSteam != 0L)
                        {
                            if (GUI.Button(new Rect(180, 112, 150, 17), string.Empty))
                            {
                                Avatars.OpenUrlBrowser("https://steamcommunity.com/profiles/" + uSelectSteam);
                            }
                        }
                        GUI.Label(new Rect(130, 80, 300, iTopMargin - 80), tempText);
                        if (GUI.Button(new Rect(400, 100, 120, 20), "Teleport"))
                        {
                            VRC.Player.Instance.transform.position = player.transform.position;
                        }
                        string sitText;
                        if (SitOnHead.SelectUser != player?.Components)
                            sitText = "Sit on";
                        else
                            sitText = "Get up";
                        if (GUI.Button(new Rect(400, 120, 120, 20), sitText))
                        {
                            if (SitOnHead.SelectUser != player?.Components)
                                SitOnHead.SelectUser = player.Components;
                            else
                                SitOnHead.SelectUser = null;
                        }
                        string blockButton = (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value) ? "Data unBlock" : "Data Block");
                        if (GUI.Button(new Rect(550, 100, 120, 20), blockButton))
                        {
                            if (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value))
                            {
                                NetworkSanity.NetworkSanity.userList.Remove(playerId.Value);
                            }
                            else
                            {
                                NetworkSanity.NetworkSanity.userList.Add(playerId.Value);
                            }
                        }
                    }
                    iPlayer++;
                    string userName = player.user.username;
                    if (string.IsNullOrWhiteSpace(userName))
                        player.user.Fetch();

                    string userIdMessage = string.Empty;
                    if (iSelectUser == playerId)
                        userIdMessage += "<b><color=red>" + playerId + "</color></b>";
                    else if (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value))
                        userIdMessage += "<b><color=yellow>" + playerId + "</color></b>";
                    else
                        userIdMessage += "<b><color=white>" + playerId + "</color></b>";
                    if (GUI.Button(new Rect(120, iPlayer * 20 + iTopMargin, 40, 20), userIdMessage)
                    || GUI.Button(new Rect(iLeftMargin, iPlayer * 20 + iTopMargin, SizeX1, 20), new IL2String_utf16(player.user.displayName)))
                    {
                        playerPhoton = player;
                        iSelectUser = playerId;

                        // uSelectSteam = player.Components;
                        string text = "<b>Selected player:</b>";
                        text += "\n<b>ID:</b>\t" + playerId;
                        uSelectSteam = 0L;
                        if (userName.StartsWith("steam_"))
                        {
                            uSelectSteam = long.Parse(userName.Remove(0, "steam_".Length));
                            if (uSelectSteam != 0L)
                            {
                                text += "\n<b>Steam:</b>\t" + uSelectSteam;
                            }
                        }
                        tempText = text;
                    }
                }
            }
            catch
            {
                
            }
        }

        private static string tempText = string.Empty;

        private static long uSelectSteam = 0L;

        private static int? iSelectUser = null;

        public static VRC.Player playerPhoton = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
