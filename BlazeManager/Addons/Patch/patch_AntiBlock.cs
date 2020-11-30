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
    public delegate bool _ModerationManager_IsUserBlocked(IntPtr instance, IntPtr apiUser);
    public delegate void _VRC_Player_UpdateModeration(IntPtr instance);
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
            foreach (var player in UnityEngine.Object.FindObjectsOfType<Player>())
                VRC_Player_UpdateModeration(player.ptr);
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
            foreach (var player in UnityEngine.Object.FindObjectsOfType<Player>())
                VRC_Player_UpdateModeration(player.ptr);
        }

        public static void Start()
        {
            IL2Method resultMethod = null;
            var methods = ModerationManager.Instance_Class.GetMethods(x => !x.IsStatic && x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == APIUser.Instance_Class.FullName);
            var methods2 = VRCPlayer.Instance_Class.GetMethods().Where(x => !x.IsStatic && x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 0);
            foreach (var method in methods2)
            {
                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsJump(x));
                    foreach(var instruction in instructions)
                    {
                        try
                        {
                            IntPtr addr = ILCode.GetPointer(instruction);
                            var temp = methods.Where(x => *(IntPtr*)x.ptr == addr);
                            if (temp.Count() > 0)
                                resultMethod = temp.First();

                        }
                        catch { }
                        if (resultMethod != null)
                            break;

                    }
                }
                if (resultMethod != null)
                    break;
            }
            var patch = IL2Ch.Patch(resultMethod, (_ModerationManager_IsUserBlocked)ModerationManager_IsUserBlocked);
            _delegateModerationManager_IsUserBlocked = patch.CreateDelegate<_ModerationManager_IsUserBlocked>();
            /*
            try
            {
                

                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instruction = disassembler.Disassemble().First(x => ILCode.IsJump(x));
                    IntPtr addr = ILCode.GetPointer(instruction);

                    Player.methods.Add(nameof(Player.UpdateModeration), Player.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr));
                    if (Player.methods[nameof(Player.UpdateModeration)] == null)
                        throw new Exception();

                    // UpdateModeration()
                    pUpdateModeration = IL2Ch.Patch(method, (_VRC_Player_UpdateModeration)VRC_Player_UpdateModeration);

                    disassembler = disasm.GetDisassembler(Player.methods[nameof(Player.UpdateModeration)]);
                    var instructions = disassembler.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    foreach (var instruction1 in instructions)
                    {
                        if (!ILCode.IsCall(instruction1))
                            continue;

                        try
                        {
                            addr = ILCode.GetPointer(instruction1);
                            method = ModerationManager.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr);

                            if (method.GetParameters().Length != 1 || method.ReturnType.Name != typeof(bool).FullName)
                                continue;

                            if (method.GetParameters()[0].ReturnType.Name != APIUser.Instance_Class.FullName)
                                continue;

                            pAntiBlock = IL2Ch.Patch(method, (_ModerationManager_IsUserBlocked)ModerationManager_IsUserBlocked);
                            break;
                        }
                        catch { continue; }
                    }
                }

                if (pAntiBlock == null)
                    throw new Exception();

                ConSole.Success("Patch: Anti-Block");
            }
            catch
            {
                ConSole.Error("Patch: Anti-Block");
            }
            */
        }

        public static void VRC_Player_UpdateModeration(IntPtr instance)
        {
            // pUpdateModeration.InvokeOriginal(instance);
            if (Player.Instance.ptr == instance) return;
            Player player = new Player(instance);
            string useridPl = player.apiuser.id;
            Transform selectRegion = player.transform.Find("SelectRegion");
            if (selectRegion == null)
                return;

            int photonId = player.photonPlayer.ID;
            bool result = UserUtils.kos_list.Contains(useridPl);

            if (result && !patch_Network.playerInfo.ContainsKey(photonId))
            {
                patch_Network.playerInfo.Add(photonId, 1);
            }
            else if (!result && patch_Network.playerInfo.ContainsKey(photonId))
            {
                patch_Network.playerInfo.Remove(photonId);
            }
            selectRegion.gameObject.SetActive(!result);
            Renderer renderer = selectRegion.GetComponent<Renderer>();
            if (renderer != null)
            {
                // ConSole.Message("---------------");
                // foreach (var comp in selectRegion.GetComponents(typeof(Component)))
                //    ConSole.Debug(comp.ToString());
                // RGBA(0, 000, 0, 573, 1, 000, 1, 000)
                //Console.WriteLine(new HighlightsFXStandalone(HighlightsFX.Instance.ptr).highlightColor);
                // HighlightsFX.Instance.m_Material.color = new Color()
                if (highlightsYellow?.gameObject == null)
                {
                    highlightsYellow = HighlightsFX.Instance.gameObject.AddComponent<HighlightsFXStandalone>();
                    highlightsYellow.highlightColor = Color.yellow;
                }
                if (APIUser.IsFriendsWith(useridPl))
                {
                    highlightsYellow.EnableOutline(renderer, !result && BlazeManager.GetForPlayer<bool>("ESP Capsule"));
                }
                else
                {
                    HighlightsFX.Instance.EnableOutline(renderer, !result && BlazeManager.GetForPlayer<bool>("ESP Capsule"));
                }

                //ConSole.Error("---------------");

                //foreach (var comp in selectRegion.GetComponents(typeof(Component)))
                //    ConSole.Debug(comp.ToString());
            }
        }

        public static HighlightsFXStandalone highlightsYellow;

        public static bool ModerationManager_IsUserBlocked(IntPtr instance, IntPtr apiUser)
        {
            if (instance == IntPtr.Zero || apiUser == IntPtr.Zero)
                return false;

            if (BlazeManager.GetForPlayer<bool>("AntiBlock"))
            {
                return false;
            }

            return _delegateModerationManager_IsUserBlocked.Invoke(instance, apiUser);
        }

        public static _ModerationManager_IsUserBlocked _delegateModerationManager_IsUserBlocked;
        public static IL2Patch pUpdateModeration;
    }
}
