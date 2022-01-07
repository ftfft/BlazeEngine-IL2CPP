using System;
using BE4v.SDK;
using SharpDisasm.Udis86;
using IL2Photon.Realtime;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.SDK.CPP2IL;
using VRC.Management;

namespace BE4v.Patch
{
    public delegate void _VRC_Player_OnNetworkReady(IntPtr instance);
    public static class Patch_Event_VRC_Player_OnNetworkReady
    {
        public static void Start()
        {
            try
            {
                IL2Method method = VRC.Player.Instance_Class.GetMethod("OnNetworkReady");
                if (method == null)
                    throw new Exception();

                var patch = new IL2Patch(method, (_VRC_Player_OnNetworkReady)VRC_Player_OnNetworkReady);
                _delegateVRC_Player_OnNetworkReady = patch.CreateDelegate<_VRC_Player_OnNetworkReady>();
                "[Event] OnNetworkReady (Patch)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "[Event] OnNetworkReady (Patch)".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void VRC_Player_OnNetworkReady(IntPtr instance)
        {
            if (instance == IntPtr.Zero || VRC.Player.Instance == null) return;
            VRC.Player player = new VRC.Player(instance);
            if (VRC.Player.Instance != player)
            {
                if (Status.isAntiBlock)
                {
                    player.IsBlocked = false;
                    player.IsBlockedBy = false;
                }
                /*
                else
                {
                    ModerationManager moderationManager = ModerationManager.Instance;
                    bool isBlock = moderationManager?.IsBlocked(vrcPlayer?.player?.user) == true;
                    vrcPlayer.player.IsBlocked = isBlock;
                    vrcPlayer.player.IsBlockedBy = isBlock;
                }
                */
            }
            _delegateVRC_Player_OnNetworkReady.Invoke(instance);

            if (VRC.Player.Instance.ptr == instance) return;

            Renderer renderer = player.Components?.playerSelector?.GetComponent<Renderer>();
            if (renderer != null)
            {

                APIUser user = player.user;
                if (user == null)
                    return;

                /*
                var graphic = player.Components.nameplate?.uiNameBackground;
                VRCPlayer.SocialRank rank = VRCPlayer.GetSocialRank(user);
                if (graphic != null)
                {
                    if (rank == VRCPlayer.SocialRank.VRChatTeam)
                        graphic.color = Color.red;
                    else if (rank == VRCPlayer.SocialRank.Legend || rank == VRCPlayer.SocialRank.VeteranUser || rank == VRCPlayer.SocialRank.TrustedUser)
                        graphic.color = new Color(120, 0, 80);
                    else if (rank == VRCPlayer.SocialRank.KnownUser)
                        graphic.color = new Color(255, 160, 66);
                    else if (rank == VRCPlayer.SocialRank.User)
                        graphic.color = Color.green;
                    else if (rank == VRCPlayer.SocialRank.NewUser)
                        graphic.color = Color.blue;
                }
                */
                if (highlightsYellow?.gameObject == null)
                {
                    highlightsYellow = HighlightsFX.Instance.gameObject.AddComponent<HighlightsFXStandalone>();
                    highlightsYellow.highlightColor = Color.yellow;
                }
                highlightsYellow.EnableOutline(renderer, false);
                HighlightsFX.Instance.EnableOutline(renderer, false);

                if (APIUser.IsFriendsWith(user.id))
                {
                    highlightsYellow.EnableOutline(renderer, Status.isGlowESP);
                }
                else
                {
                    HighlightsFX.Instance.EnableOutline(renderer, Status.isGlowESP);
                }
            }
        }

        public static IL2Patch patch;

        public static HighlightsFXStandalone highlightsYellow;

        public static _VRC_Player_OnNetworkReady _delegateVRC_Player_OnNetworkReady;
    }
}
