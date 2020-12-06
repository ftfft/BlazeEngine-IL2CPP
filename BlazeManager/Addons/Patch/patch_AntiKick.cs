using System;
using System.Reflection;
using System.Linq;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine.Analytics;
using BlazeTools;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using VRC.Management;

namespace Addons.Patch
{
    public delegate AnalyticsResult _patch_method_3();
    public delegate void _patch_method_4(IntPtr arg1, IntPtr arg2, IntPtr arg3);
    public delegate void _patch_method_5(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options);
    public delegate bool _patch_method_6();
    public delegate bool _patch_method_7(IntPtr instance);
    public delegate bool _ModerationManager_IsBannedFromPublicOnly(IntPtr instance);
    public delegate bool _ModerationManager_IsKickedFromWorld(IntPtr instance, IntPtr worldId, IntPtr instanceId);
    public static class patch_AntiKick
    {
        public static void Start()
        {
            IL2Method method;
            int iError = 0;

            // ~ Analytics [Count: 3]
            try
            {
                method = Assemblies.a["UnityEngine.UnityAnalyticsModule"].GetClass("Analytics", "UnityEngine.Analytics").GetMethods()
                    .Where(x => x.Name == "CustomEvent" && x.GetParameters().Length == 2)
                    .First(x => x.GetParameters()[1].Name == "eventData");
                IL2Ch.Patch(method, (_patch_method_3)patch_method_3);
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [2]");
                iError++;
            }
            try
            {
                method = Assemblies.a["Assembly-CSharp"].GetClass("Analytics").GetMethods()
                .Where(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3)
                .First(x => x.HasFlag(IL2BindingFlags.METHOD_STATIC));
                IL2Ch.Patch(method, (_patch_method_4)patch_method_4);
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [3]");
                iError++;
            }
            try
            {
                method = Assemblies.a["VRCCore-Standalone"].GetClass("AmplitudeWrapper", "AmplitudeSDKWrapper").GetMethod("CheckedLogEvent");
                IL2Ch.Patch(method, (_patch_method_5)patch_method_5);
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [4]");
                iError++;
            }

            try
            {
                // PortalInternal::CreatePortal([5])
                method = VRCFlowManager.Instance_Class.GetMethod(x => x.GetParameters().Length == 5);
                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsCall(x));
                    foreach(var instruction in instructions)
                    {
                        var addr = ILCode.GetPointer(instruction);
                        if ((method = ModerationManager.Instance_Class.GetMethod(x => *(IntPtr*)x.ptr == addr && x.GetParameters().Length == 2)) != null)
                            break;
                    }
                    if (method == null)
                        throw new Exception();

                }

                // IsKickedFromWorld
                IL2Ch.Patch(method, (_ModerationManager_IsKickedFromWorld)ModerationManager_IsKickedFromWorld);
            }
            catch
            {
                ConSole.Error("Patch:  AntiKick [IsKickedFromWorld]");
            }
            /*
            method = VRC.Player.Instance_Class.GetMethod("OnNetworkReady");
            unsafe
            {
                var disassembler = disasm.GetDisassembler(method, 0x1000);
                var instruction = disassembler.Disassemble().Last(x => ILCode.IsJump(x));
                Console.WriteLine(instruction.ToString());
                IntPtr addr = ILCode.GetPointer(instruction);
                // ModerationManager::SelfCheckAndEnforceModerations(__this)
                method = ModerationManager.Instance_Class.GetMethod(x => *(IntPtr*)x.ptr == addr);
                try
                {
                    if (method == null)
                        throw new Exception();
                    Console.WriteLine(method.Name);
                    disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsCall(x));
                    foreach(var instruction2 in instructions)
                    {
                        Console.WriteLine(instruction2);
                        addr = ILCode.GetPointer(instruction2);
                        method = ModerationManager.Instance_Class.GetProperties().FirstOrDefault(x => *(IntPtr*)x.GetGetMethod().ptr == addr).GetGetMethod();
                    }
                    if (method == null)
                        throw new Exception();

                    IL2Ch.Patch(method, (_ModerationManager_IsBannedFromPublicOnly)ModerationManager_IsBannedFromPublicOnly);
                    ConSole.Success("Patch: AntiKick [PublicBan]");
                }
                catch
                {
                    ConSole.Error("Patch:  AntiKick [PublicBan]");
                }
            }
            /*
            try
            {
                foreach (var m in ModerationManager.Instance_Class.GetMethods()
                    .Where(x => x.ReturnType.Name == "System.Boolean" && x.GetParameters().Length == 0))
                    //.Where(x => x.HasFlag(IL2BindingFlags.METHOD_STATIC)))
                    IL2Ch.Patch(m, (_patch_method_6)patch_method_6);
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [5]");
                iError++;
            }
            try
            {
                string typeName = typeof(string).FullName;
                foreach (var m in ModerationManager.Instance_Class.GetMethods()
                    .Where(x => x.GetParameters().Length == 3)
                    .Where(x => x.GetParameters()[0].ReturnType.Name == typeName)
                    .Where(x => x.GetParameters()[1].ReturnType.Name == typeName)
                    .Where(x => x.GetParameters()[2].ReturnType.Name == typeName))
                    IL2Ch.Patch(m, (_patch_method_7)patch_method_7);
            }
            catch
            {
                ConSole.Error("Patch: AntiKick [6]");
                iError++;
            }
            */
            // Debug
            if (iError == 0)
                ConSole.Success("Patch: AntiKick");
            else
                ConSole.Error("Patch: AntiKick");
        }

        private static AnalyticsResult patch_method_3()
        {
            return AnalyticsResult.Ok;
        }
        private static void patch_method_4(IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {

        }
        private static void patch_method_5(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options)
        {

        }
        private static bool ModerationManager_IsBannedFromPublicOnly(IntPtr instance)
        {
            return false;
        }

        private static bool patch_method_6() => patch_method_7(IntPtr.Zero);
        private static bool patch_method_7(IntPtr ptrInstance)
        {
            return false;
        }
        private static bool ModerationManager_IsKickedFromWorld(IntPtr instance, IntPtr worldId, IntPtr instanceId)
        {
            return false;
        }

        public static IL2Patch[] pRPCKick = new IL2Patch[2];
    }
}
