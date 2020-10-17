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
        // private static IL2String strTabMenuBold = new IL2String("<b><color=white>Tab-menu</color></b>");
        private static IL2String strHashBold = new IL2String("<b>#</b>");
        private static IL2String strDisplayNameBold = new IL2String("<b>displayName</b>");
        private static IL2String strTeleport = new IL2String("Teleport");
        private static IntPtr ptrSteamIdButton_Rect = new Rect(180, 112, 150, 17).MonoCast();
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
                        if (GUI.Button(ptrSteamIdButton_Rect, IntPtr.Zero))
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
                || GUI.Button(new Rect(iLeftMargin, iPlayer * 20 + iTopMargin, SizeX1, 20), player.ToString_Pointer()))
                {
                    iSelectUser = playerId;
                    uSelectSteam = player.steamId;
                    string text = "<b>Selected player:</b>";
                    text += "\n<b>ID:</b>\t" + playerId;
                    if (uSelectSteam != 0U)
                    {
                        text += "\n<b>Steam:</b>\t" + uSelectSteam;
                    }
                    strTempText = new IL2String(text);
                }
            }
        }

        private static ulong uSelectSteam = 0U;

        private static int? iSelectUser = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
