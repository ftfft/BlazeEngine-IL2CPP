using BE4v.SDK.CPP2IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BE4v.Mods.Avatars;
using BE4v.SDK;
using IL2Photon.Pun.UtilityScripts;
using System.CodeDom;

namespace BE4v.MenuEdit.IMGUI
{
    public delegate void _Nulled(IntPtr instance);
    public delegate IntPtr _Nulled_Arg1(IntPtr instance);
    public delegate void _PhotonLagSimulationGui_OnGUI(IntPtr instance);
    public static class TabMenu
    {
        static TabMenu()
        {
            strHashBold = new IL2String("<b>#</b>");
            strHashBold.Static = true;
            strDisplayNameBold = new IL2String("<b>displayName</b>");
            strDisplayNameBold.Static = true;
            strTeleport = new IL2String("Teleport");
            strTeleport.Static = true;
            strTest = new IL2String("Test");
            strTest.Static = true;
            strEmpty = new IL2String(string.Empty);
            strEmpty.Static = true;
        }

        // private static IL2String strTabMenuBold = new IL2String("<b><color=white>Tab-menu</color></b>");
        private static IL2String strHashBold;
        private static IL2String strDisplayNameBold;
        private static IL2String strTeleport;
        private static IL2String strTest;
        private static IL2String strEmpty;
        private static IL2String strTempText = null;
        public static bool isPressed = false;
        public static _PhotonLagSimulationGui_OnGUI _delegatePhotonLagSimulationGui_OnGUI;
        public static void Update()
        {
            isPressed = Input.GetKey(KeyCode.Tab);
        }

        public static void Nulled(IntPtr instance) { }
        public static IntPtr Nulled_Arg1(IntPtr instance) { return IntPtr.Zero; }

        public static void Start()
        {

            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Start");
                if (method == null)
                    throw new Exception("BE4V: Not found a thread Photon.(Start)");

                new IL2Patch(method, (_Nulled_Arg1)Nulled_Arg1);
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }

            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Awake");
                if (method == null)
                    throw new Exception("BE4V: Not found a thread Photon.(Awake)");

                new IL2Patch(method, (_Nulled)Nulled);
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }


            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Reset");
                if (method == null)
                    throw new Exception("BE4V: Not found a thread Photon.(Reset)");


                new IL2Patch(method, (_Nulled)Nulled);
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }

            try
            {
                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("OnGUI");
                if (method == null)
                    throw new Exception("BE4V: Not found a thread Photon.(OnGUI)");

                var patch = new IL2Patch(method, (_PhotonLagSimulationGui_OnGUI)OnGUI);
                _delegatePhotonLagSimulationGui_OnGUI = patch.CreateDelegate<_PhotonLagSimulationGui_OnGUI>();
                if (_delegatePhotonLagSimulationGui_OnGUI == null)
                    throw new Exception("BE4V: Not found a delegate (OnGUI)");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
        }

        public static void OnGUI(IntPtr instance)
        {
            if (instance == null || instance == IntPtr.Zero) return;
            try
            {
                if (!isPressed) throw new Exception();
                int SizeX1 = Screen.width - (iLeftMargin * 2);
                // GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 100), strTabMenuBold.ptr);
                GUI.Label(new Rect(120, iTopMargin, 40, 20), strHashBold.ptr);
                GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), strDisplayNameBold.ptr);

                int iPlayer = 0;
                VRC.Player[] playerArray = players;
                foreach (var player in playerArray)
                {
                    int? playerId = player?.PhotonPlayer?.ActorNumber;
                    if (playerId == null) continue;
                    if (iSelectUser == playerId)
                    {
                        if (uSelectSteam != 0L)
                        {
                            if (GUI.Button(new Rect(180, 112, 150, 17), strEmpty.ptr))
                            {
                                Utils.OpenUrlBrowser("https://steamcommunity.com/profiles/" + uSelectSteam);
                            }
                        }
                        GUI.Label(new Rect(130, 80, 300, iTopMargin - 80), strTempText.ptr);
                        if (GUI.Button(new Rect(400, 100, 120, 20), strTeleport.ptr))
                        {
                            VRC.Player.Instance.transform.position = player.transform.position;
                        }
                    }
                    iPlayer++;
                    if (GUI.Button(new Rect(120, iPlayer * 20 + iTopMargin, 40, 20), "<b><color=" + (iSelectUser == playerId ? "red>" : "white>") + playerId + "</color></b>")
                    || GUI.Button(new Rect(iLeftMargin, iPlayer * 20 + iTopMargin, SizeX1, 20), player.user.displayName))
                    {
                        playerPhoton = player;
                        iSelectUser = playerId;

                        string userName = player.user.username;
                        if (string.IsNullOrWhiteSpace(userName))
                        {
                            player.user.Fetch();
                            players = VRC.PlayerManager.Instance.PlayersCopy;
                        }
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
                        if (strTempText != null)
                            strTempText.Static = false;
                        strTempText = new IL2String(text);
                        strTempText.Static = true;
                    }
                }
            }
            catch { }
            finally
            {
                _delegatePhotonLagSimulationGui_OnGUI(instance);
            }
        }

        private static long uSelectSteam = 0L;

        private static int? iSelectUser = null;

        public static VRC.Player playerPhoton = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;

        public static VRC.Player[] players = new VRC.Player[0];
    }
}
