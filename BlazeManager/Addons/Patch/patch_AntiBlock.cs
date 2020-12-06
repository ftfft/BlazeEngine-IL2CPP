using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using VRC;
using VRC.Core;
using VRC.Management;
using UnityEngine;

namespace Addons.Patch
{
    public delegate IntPtr _VRC_Player_IsBlocked(IntPtr instance);
    public delegate IntPtr _VRC_Player_IsBlockedBy(IntPtr instance);
    public delegate void _VRCPlayer_RefreshState(IntPtr instance);
    public static class patch_AntiBlock
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("AntiBlock", !BlazeManager.GetForPlayer<bool>("AntiBlock"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("AntiBlock");
            BlazeManagerMenu.Main.togglerList["AntiBlock"].SetToggleToOn(toggle, false);
            foreach (var player in UnityEngine.Object.FindObjectsOfType<VRCPlayer>())
                if (player != null)
                    VRCPlayer_RefreshState(player.ptr);
        }
        
        public static void Toggle_Enable_ESP_Capsule()
        {
            BlazeManager.SetForPlayer("ESP Capsule", !BlazeManager.GetForPlayer<bool>("ESP Capsule"));
            RefreshStatus_ESP_Capsule();
        }

        public static void RefreshStatus_ESP_Capsule()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("ESP Capsule");
            BlazeManagerMenu.Main.togglerList["ESP Capsule"].SetToggleToOn(toggle, false);
            foreach (var player in UnityEngine.Object.FindObjectsOfType<VRCPlayer>())
                if (player != null)
                    VRCPlayer_RefreshState(player.ptr);
        }

        public static void Start()
        {
            /*
            try
            {
                var property = Player.Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName && x.GetSetMethod() != null).First();
                var patch = IL2Ch.Patch(property.GetGetMethod(), (_VRC_Player_IsBlocked)VRC_Player_IsBlocked);
                _delegateVRC_Player_IsBlocked = patch.CreateDelegate<_VRC_Player_IsBlocked>();
                ConSole.Success("Patch: Anti-Block [First]");
            }
            catch
            {
                ConSole.Error("Patch: Anti-Block [First]");
            }
            try
            {
                var property = Player.Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName && x.GetSetMethod() != null).Skip(1).First();
                var patch = IL2Ch.Patch(property.GetGetMethod(), (_VRC_Player_IsBlockedBy)VRC_Player_IsBlockedBy);
                _delegateVRC_Player_IsBlockedBy = patch.CreateDelegate<_VRC_Player_IsBlockedBy>();
                ConSole.Success("Patch: Anti-Block [Second]");
            }
            catch
            {
                ConSole.Error("Patch: Anti-Block [Second]");
            }
            */
            try
            {
                var method = Player.Instance_Class.GetMethod("OnNetworkReady");
                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsJump(x));
                    foreach (var instruction in instructions)
                    {
                        IntPtr addr = ILCode.GetPointer(instruction);

                        method = VRCPlayer.Instance_Class.GetMethods().FirstOrDefault(x => *(IntPtr*)x.ptr == addr);
                        if (method != null)
                            break;
                    }
                    var patch = IL2Ch.Patch(method, (_VRCPlayer_RefreshState)VRCPlayer_RefreshState);
                    _delegateVRCPlayer_RefreshState = patch.CreateDelegate<_VRCPlayer_RefreshState>();
                }
                ConSole.Success("Patch: Player Refresh");
            }
            catch
            {
                ConSole.Error("Patch: Player Refresh");
            }
        }

        public static void VRCPlayer_RefreshState(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            _delegateVRCPlayer_RefreshState.Invoke(instance);

            if (VRCPlayer.Instance.ptr == instance) return;
            VRCPlayer vrcPlayer = new VRCPlayer(instance);

            Renderer renderer = vrcPlayer?.playerSelector?.GetComponent<Renderer>();
            if (renderer != null)
            {
                string userid = vrcPlayer?.player?.user?.id;

                if (highlightsYellow?.gameObject == null)
                {
                    highlightsYellow = HighlightsFX.Instance.gameObject.AddComponent<HighlightsFXStandalone>();
                    highlightsYellow.highlightColor = Color.yellow;
                }
                highlightsYellow.EnableOutline(renderer, false);
                HighlightsFX.Instance.EnableOutline(renderer, false);
                if (APIUser.IsFriendsWith(userid))
                {
                    highlightsYellow.EnableOutline(renderer, BlazeManager.GetForPlayer<bool>("ESP Capsule"));
                }
                else
                {
                    HighlightsFX.Instance.EnableOutline(renderer, BlazeManager.GetForPlayer<bool>("ESP Capsule"));
                }
            }
        }

        public static _VRCPlayer_RefreshState _delegateVRCPlayer_RefreshState;

        public static HighlightsFXStandalone highlightsYellow;

        public static IntPtr VRC_Player_IsBlocked(IntPtr instance)
        {
            /*
            if (instance == IntPtr.Zero)
                return default;

            if (BlazeManager.GetForPlayer<bool>("AntiBlock"))
            {
                return false;
            }
            */

            return _delegateVRC_Player_IsBlocked.Invoke(instance);
        }
        public static _VRC_Player_IsBlocked _delegateVRC_Player_IsBlocked;

        public static IntPtr VRC_Player_IsBlockedBy(IntPtr instance)
        {
            /*
            if (instance == IntPtr.Zero)
                return default;

            if (BlazeManager.GetForPlayer<bool>("AntiBlock"))
            {
                return false;
            }
            */
            return _delegateVRC_Player_IsBlockedBy.Invoke(instance);
        }
        public static _VRC_Player_IsBlockedBy _delegateVRC_Player_IsBlockedBy;
    }
}
