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
    public delegate void _VRCPlayer_RefreshState(IntPtr instance);
    public static class Patch_Event_VRCPlayer_RefreshState
    {
        public static void Start()
        {
            try
            {
                unsafe
                {
                    var disassembler = VRC.Player.Instance_Class.GetMethod("OnNetworkReady").GetDisassembler(0x1000);
                    var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == ud_mnemonic_code.UD_Ijmp);
                    IL2Method method = null;
                    foreach (var instruction in instructions)
                    {
                        IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);

                        method = VRCPlayer.Instance_Class.GetMethods().FirstOrDefault(x => *(IntPtr*)x.ptr == addr);
                        if (method != null)
                        {
                            method.Name = "RefreshState";
                            break;
                        }
                    }
                    var patch = new IL2Patch(method, (_VRCPlayer_RefreshState)VRCPlayer_RefreshState);
                    _delegateVRCPlayer_RefreshState = patch.CreateDelegate<_VRCPlayer_RefreshState>();
                }
                "[Event] RefreshState (Patch)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "[Event] RefreshState (Patch)".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void VRCPlayer_RefreshState(IntPtr instance)
        {
            if (instance == IntPtr.Zero || VRCPlayer.Instance == null) return;
            VRCPlayer vrcPlayer = new VRCPlayer(instance);
            if (VRCPlayer.Instance != vrcPlayer)
            {
                if (Status.isAntiBlock)
                {
                    vrcPlayer.player.IsBlocked = false;
                    vrcPlayer.player.IsBlockedBy = false;
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
            _delegateVRCPlayer_RefreshState.Invoke(instance);

            if (VRCPlayer.Instance.ptr == instance) return;

            Renderer renderer = vrcPlayer?.playerSelector?.GetComponent<Renderer>();
            if (renderer != null)
            {

                APIUser user = vrcPlayer.player?.user;
                if (user == null)
                    return;

                var graphic = vrcPlayer.nameplate?.uiNameBackground;
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

        public static _VRCPlayer_RefreshState _delegateVRCPlayer_RefreshState;
    }
}
