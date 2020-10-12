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
        public static void ShowMenu()
        {

            int SizeX1 = Screen.width - (iLeftMargin * 2);
            GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 100), "<b><color=white>Tab-menu</color></b>");
            GUI.Label(new Rect(120, iTopMargin, 40, 20), "<b>#</b>");
            GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), "<b>displayName</b>");

            int iPlayer = 0;
            foreach (var player in VRC.PlayerManager.Instance.AllPlayers)
            {
                int? playerId = player?.photonPlayer?.ID;
                if (playerId == null) continue;
                if (iSelectUser == playerId)
                {
                    string text = "<b>Selected player:</b>";
                    text += "\n<b>ID:</b>\t" + playerId;
                    if (uSelectSteam != 0U)
                    {
                        text += "\n<b>Steam:</b>\t" + uSelectSteam;
                        if (GUI.Button(new Rect(180, 112, 150, 17), string.Empty))
                        {
                            Avatars.AvatarStatus.OpenUrlBrowser("https://steamcommunity.com/profiles/" + uSelectSteam);
                        }
                    }
                    GUI.Label(new Rect(130, 80, 300, iTopMargin - 80), text);
                    if (GUI.Button(new Rect(400, 100, 120, 20), "Teleport"))
                    {
                        UserUtils.TeleportTo(player);
                    }
                }
                iPlayer++;
                if (GUI.Button(new Rect(120, iPlayer * 20 + iTopMargin, 40, 20), "<b><color=" + (iSelectUser == playerId ? "red>" : "white>") + playerId + "</color></b>")
                || GUI.Button(new Rect(iLeftMargin, iPlayer * 20 + iTopMargin, SizeX1, 20), player.ToString_Pointer()))
                {
                    iSelectUser = playerId;
                    uSelectSteam = player.steamId;
                }
            }
        }

        private static ulong uSelectSteam = 0U;

        private static int? iSelectUser = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
