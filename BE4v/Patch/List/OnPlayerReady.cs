using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.Patch.Core;
using BE4v.Utils;

namespace BE4v.Patch.List
{
    public class OnPlayerReady : IPatch
    {
        public delegate void _OnNetworkReady(IntPtr instance);
        public delegate void _OnDestroy(IntPtr instance);
        public void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod(nameof(OnNetworkReady));
            if (method == null)
                throw new NullReferenceException();

            __OnNetworkReady = PatchUtils.FastPatch<_OnNetworkReady>(method, OnNetworkReady);
            // ----
            method = VRC.Player.Instance_Class.GetMethod(nameof(OnDestroy));
            if (method == null)
                throw new NullReferenceException();

            __OnDestroy = PatchUtils.FastPatch<_OnDestroy>(method, OnDestroy);
        }

        public static void OnNetworkReady(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;

            __OnNetworkReady(instance);
            Threads.UpdatePlayers();

            VRC.Player localPlayer = VRC.Player.Instance;
            if (localPlayer != null && instance != localPlayer.Pointer)
            {
                VRC.Player player = new VRC.Player(instance);
                if (Status.isAntiBlock)
                {
                    player.IsBlocked = false;
                    player.IsBlockedBy = false;
                }
                ESPUpdate(player);
            }
        }

        public static void OnDestroy(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;

            __OnDestroy(instance);
            Threads.UpdatePlayers();
        }


        public static void ESPUpdate(VRC.Player player)
        {
            if (player == VRC.Player.Instance) return;
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

        public static _OnNetworkReady __OnNetworkReady;
        public static _OnDestroy __OnDestroy;
    }
}
