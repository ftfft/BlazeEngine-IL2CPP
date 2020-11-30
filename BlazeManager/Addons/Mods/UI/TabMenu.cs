using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace Addons.Mods.UI
{
    public static class TabMenu
    {
        static TabMenu()
        {
            strHashBold = "<b>#</b>".IL2String();
            strHashBold.Static = true;
            strDisplayNameBold = "<b>displayName</b>".IL2String();
            strDisplayNameBold.Static = true;
            strTeleport = "Teleport".IL2String();
            strTeleport.Static = true;
            strTest = "Test".IL2String();
            strTest.Static = true;
            strEmpty = string.Empty.IL2String();
            strEmpty.Static = true;
        }

        // private static IL2String strTabMenuBold = new IL2String("<b><color=white>Tab-menu</color></b>");
        private static IL2String strHashBold;
        private static IL2String strDisplayNameBold;
        private static IL2String strTeleport;
        private static IL2String strTest;
        private static IL2String strEmpty;
        private static IL2String strTempText = null;
        public static void ShowMenu()
        {

            int SizeX1 = Screen.width - (iLeftMargin * 2);
            // GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 100), strTabMenuBold.ptr);
            GUI.Label(new Rect(120, iTopMargin, 40, 20), strHashBold.ptr);
            GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), strDisplayNameBold.ptr);

            int iPlayer = 0;
            foreach (var player in VRC.PlayerManager.Instance.AllPlayers)
            {
                int? playerId = player?.photonPlayer?.ID;
                if (playerId == null) continue;
                if (iSelectUser == playerId)
                {
                    if (uSelectSteam != 0U)
                    {
                        if (GUI.Button(new Rect(180, 112, 150, 17).MonoCast(), strEmpty.ptr))
                        {
                            Avatars.AvatarStatus.OpenUrlBrowser("https://steamcommunity.com/profiles/" + uSelectSteam);
                        }
                    }
                    GUI.Label(new Rect(130, 80, 300, iTopMargin - 80), strTempText.ptr);
                    if (GUI.Button(new Rect(400, 100, 120, 20), strTeleport.ptr))
                    {
                        UserUtils.TeleportTo(player);
                    }
                }
                iPlayer++;
                if (GUI.Button(new Rect(120, iPlayer * 20 + iTopMargin, 40, 20), "<b><color=" + (iSelectUser == playerId ? "red>" : "white>") + playerId + "</color></b>")
                || GUI.Button(new Rect(iLeftMargin, iPlayer * 20 + iTopMargin, SizeX1, 20), player.ToIL2String().ptr))
                {
                    playerPhoton = player;
                    iSelectUser = playerId;
                    uSelectSteam = player.steamId;
                    string text = "<b>Selected player:</b>";
                    text += "\n<b>ID:</b>\t" + playerId;
                    if (uSelectSteam != 0U)
                    {
                        text += "\n<b>Steam:</b>\t" + uSelectSteam;
                    }
                    if (strTempText != null)
                        strTempText.Static = false;
                    strTempText = text.IL2String();
                    strTempText.Static = true;
                }
            }
        }

        private static ulong uSelectSteam = 0U;

        private static int? iSelectUser = null;

        public static VRC.Player playerPhoton = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
