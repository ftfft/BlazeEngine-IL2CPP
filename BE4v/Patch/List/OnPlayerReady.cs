using System;
using System.Collections.Generic;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using BE4v.Utils;

namespace BE4v.Patch.List
{
    public class OnPlayerReady : IPatch
    {
        public delegate void _VRC_Player_OnNetworkReady(IntPtr instance);
        public void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod("OnNetworkReady");
            if (method != null)
            {
                _OnNetworkReady = PatchUtils.FastPatch<_VRC_Player_OnNetworkReady>(method, VRC_Player_OnNetworkReady);
            }
            else
                throw new NullReferenceException();
        }

        public static void VRC_Player_OnNetworkReady(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            players = VRC.PlayerManager.PlayersCopy;
            VRC.Player localPlayer = VRC.Player.Instance;
            if (localPlayer != null && instance != localPlayer.ptr)
            {
                VRC.Player player = new VRC.Player(instance);
                if (Status.isAntiBlock)
                {
                    player.IsBlocked = false;
                    player.IsBlockedBy = false;
                }
                ESPUpdate(player);
            }
            _OnNetworkReady(instance);
        }


        public static void ESPUpdate(VRC.Player player)
        {
            Renderer renderer = player.Components?.playerSelector?.GetComponent<Renderer>();

            if (renderer != null)
            {
                APIUser user = player.user;
                if (user == null)
                    return;

                HighlightUtils.GetLight(Color.yellow).EnableOutline(renderer, false);
                HighlightUtils.GetLight(Color.red).EnableOutline(renderer, false);
                HighlightUtils.GetLight(Color.cyan).EnableOutline(renderer, false);
                // if (blocked[player.ptr] || blockedBy[player.ptr])
               // {
                //    HighlightUtils.GetLight(Color.cyan).EnableOutline(renderer, Status.isGlowESP);
                //}
                if (APIUser.IsFriendsWith(user.id))
                {
                    HighlightUtils.GetLight(Color.yellow).EnableOutline(renderer, Status.isGlowESP);
                }
                else
                {
                    HighlightUtils.GetLight(Color.red).EnableOutline(renderer, Status.isGlowESP);
                }
            }
        }

        public static Dictionary<IntPtr, bool> blocked = new Dictionary<IntPtr, bool>();
        public static Dictionary<IntPtr, bool> blockedBy = new Dictionary<IntPtr, bool>();

        public static VRC.Player[] players = new VRC.Player[0];

        public static _VRC_Player_OnNetworkReady _OnNetworkReady;
    }
}
