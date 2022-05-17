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
    public class OnPlayerUpdateSync // : IPatch
    {
        public delegate void _VRC_Player_Update(IntPtr instance);
        public void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod("Update");
            if (method != null)
            {
                VRC_PlayerUpdate = PatchUtils.FastPatch<_VRC_Player_Update>(method, VRC_Player_Update);
            }
            else
                throw new NullReferenceException();
        }

        public static void VRC_Player_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            VRC_PlayerUpdate(instance);
            VRC.Player localPlayer = VRC.Player.Instance;
            if (localPlayer == null || localPlayer.ptr == instance) return;
            VRC.Player player = new VRC.Player(instance);

            bool blockUpdate = false;
            #region blocked
            bool isBlocked = player.IsBlocked;
            if (blocked.ContainsKey(instance))
            {
                if (blocked[instance] != isBlocked)
                {
                    blocked[instance] = isBlocked;
                    blockUpdate = true;
                }
            }
            else
            {
                blocked.Add(instance, isBlocked);
                blockUpdate = true;
            }
            #endregion


            #region blockedBy
            bool isBlockedBy = player.IsBlockedBy;
            if (blockedBy.ContainsKey(instance))
            {
                if (blockedBy[instance] != isBlockedBy)
                {
                    blockedBy[instance] = isBlockedBy;
                    blockUpdate = true;
                }
            }
            else
            {
                blockedBy.Add(instance, isBlockedBy);
                blockUpdate = true;
            }
            #endregion

            if (blockUpdate)
                ESPUpdate(player);
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
                if (blocked[player.ptr] || blockedBy[player.ptr])
                {
                    HighlightUtils.GetLight(Color.cyan).EnableOutline(renderer, Status.isGlowESP);
                }
                else if (APIUser.IsFriendsWith(user.id))
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

        public static _VRC_Player_Update VRC_PlayerUpdate;
    }
}
