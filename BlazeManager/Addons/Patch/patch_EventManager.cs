using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRC.Core;
using VRC.SDKBase;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using Addons.Mods;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using IL2ExitGames.Client.Photon;
using VRC;

namespace Addons.Patch
{
    public delegate void _RoomManagerBase_OnConnectedToMaster(IntPtr instance);
    public delegate void _NetworkInitalize(VRC_EventHandler.VrcBroadcastType broadcast, IntPtr prefabPathOrDynamicPrefabName, IntPtr position, IntPtr rotation);
    public delegate void _RPCSend(VRC_EventHandler.VrcTargetType targetClients, IntPtr targetObject, IntPtr methodName, IntPtr parameters);
    public delegate IntPtr _VRCPlayer_GetUserRank_String(IntPtr user);
    public delegate void _HudVoiceIndicator_Update(IntPtr instance);
    public delegate void _VRC_UI_PageUserInfo_SetUserRelationshipState(IntPtr instance, IntPtr friendType);
    public delegate float _UnityEngine_Time_fixedDeltaTime();
    public static class patch_EventManager
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("RPC Block", !BlazeManager.GetForPlayer<bool>("RPC Block"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("RPC Block");
            BlazeManagerMenu.Main.togglerList["RPC Block"].SetToggleToOn(toggle, false);
        }


        unsafe public static void Start()
        {
            try
            {
                IL2Method method = RoomManager.Instance_Class.GetMethod("OnConnectedToMaster");

                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_RoomManagerBase_OnConnectedToMaster)RoomManagerBase_OnConnectedToMaster);
                _delegateRoomManagerBase_OnConnectedToMaster = patch.CreateDelegate<_RoomManagerBase_OnConnectedToMaster>();
                Dll_Loader.success_Patch.Add("EventManager [OnConnectedToMaster]");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("EventManager [OnConnectedToMaster]");
            }
            /*
            try
            {
                IL2Method method = Time.Instance_Class.GetProperty("fixedDeltaTime").GetGetMethod();

                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_UnityEngine_Time_fixedDeltaTime)UnityEngine_Time_fixedDeltaTime);
                ConSole.Success("Patch: EventManager [Optimize]");

            }
            catch
            {
                ConSole.Error("Patch: EventManager [Optimize]");
            }
            */
            try
            {
                IL2Method method = null;
                foreach (var m in VRCPlayer.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(string).FullName && x.GetParameters().Length == 1).Where(x => x.GetParameters()[0].ReturnType.Name == APIUser.Instance_Class.FullName))
                {
                    if (method != null) break;
                    var disasm = new Disassembler(*(IntPtr*)m.ptr, 0x1000, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)m.ptr).ToInt64()), true, Vendor.Intel);
                    // disasm.Disassemble().ToList().ForEach(x => { Console.WriteLine(x.ToString()); });
                    var instructions = disasm.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > 150)
                        method = m;


                    /*foreach (var instruction1 in instructions)
                    {
                        if (!instruction1.ToString().StartsWith("call "))
                            continue;

                        try
                        {
                            var addr = new IntPtr((long)instruction1.Offset + instruction1.Length + instruction1.Operands[0].LvalSDWord);
                            method = ModerationManager.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr);

                            ModerationManager.methodIsBlockedEitherWay = method;
                            break;
                        }
                        catch { continue; }
                    }*/
                }
                if (method == null)
                    throw new Exception();

                unsafe
                {
                    IL2Method newMethod = null;
                    var disassembler = disasm.GetDisassembler(method, 0x1000);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsCall(x));
                    foreach (var instruction in instructions)
                    {
                        var addr = ILCode.GetPointer(instruction);
                        if ((newMethod = PlayerManager.Instance_Class.GetMethod(x => *(IntPtr*)x.ptr == addr && x.GetParameters().Length == 1)) != null)
                            break;
                    }
                    string oldName = newMethod.Name;
                    foreach (var method2 in PlayerManager.Instance_Class.GetMethods(x => x.Name == oldName))
                    {
                        method2.Name = "GetPlayer";
                    }
                }
                IL2Ch.Patch(method, (_VRCPlayer_GetUserRank_String)VRCPlayer_GetUserRank_String);
                Dll_Loader.success_Patch.Add("EventManager [User Ranked]");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("EventManager [User Ranked]");
            }
            try
            {
                IL2Method method = VRC.UI.PageUserInfo.Instance_Class?.GetMethods(x => x.GetParameters().Length == 1).First(x => x.GetParameters()[0].ReturnType.Name.StartsWith("VRC.UI.PageUserInfo."));
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_VRC_UI_PageUserInfo_SetUserRelationshipState)VRC_UI_PageUserInfo_SetUserRelationshipState);
                _delegateVRC_UI_PageUserInfo_SetUserRelationshipState = patch.CreateDelegate<_VRC_UI_PageUserInfo_SetUserRelationshipState>();
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("EventManager [PUI State]");
            }
            /*
            try
            {
                IL2Method method = VRC.Network.Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.GetReturnType().Name == "System.Void").First(
                    x =>
                        x.GetParameters()[0].typeName.EndsWith(".RPC.Destination") &&
                        x.GetParameters()[1].typeName == "UnityEngine.GameObject" &&
                        x.GetParameters()[2].typeName == "System.String" &&
                        x.GetParameters()[3].typeName == "System.Object[]"
                );
                if (method == null)
                    throw new Exception();

                pRPCSend = IL2Ch.Patch(method, (_RPCSend)RPCSend);
                ConSole.Success("Patch: EventManager [RPC Check | Initalize]");

                method = VRC.Network.Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.GetReturnType().Name == "UnityEngine.GameObject").First();
                if (method == null)
                    throw new Exception();

                pInitalize = IL2Ch.Patch(method, (_NetworkInitalize)NetworkInitalize);
            }
            catch
            {
                ConSole.Error("Patch: EventManager [RPC Check | Initalize]");
            }
            */
        }

        public static void VRC_UI_PageUserInfo_SetUserRelationshipState(IntPtr instance, IntPtr friendType)
        {
            _delegateVRC_UI_PageUserInfo_SetUserRelationshipState.Invoke(instance, friendType);
            BlazeManagerMenu.Edit_UserPanel.OnEnter_ShowProfile();
        }

        public static float UnityEngine_Time_fixedDeltaTime()
        {
            return 0.001f;
        }
        public static void RoomManagerBase_OnConnectedToMaster(IntPtr instance)
        {
            _delegateRoomManagerBase_OnConnectedToMaster.Invoke(instance);
            Threads.bFirstThreadInRoom = false;
            patch_Network.iSelfActor = null;
            patch_GlobalDynamicBones.currentPlayer = null;
            patch_GlobalDynamicBones.timeToUpdate = 10f;
            BlazeManager.SetForPlayer("DeathMap", false);
            BlazeManager.SetForPlayer("Photon Serilize", false);
            PortableMirror.OnDestroy();
            Cam3th.OnDestroy();
            // BlazeAttack.PhotonUtils.raise209_status = false;
        }

        static patch_EventManager()
        {
            dictUserRank.Add("Error", new IL2String("Error"));
            dictUserRank["Error"].Static = true;
            dictUserRank.Add("Moderator", new IL2String("Moderator"));
            dictUserRank["Moderator"].Static = true;
            dictUserRank.Add("Nuisance", new IL2String("Nuisance"));
            dictUserRank["Nuisance"].Static = true;
            dictUserRank.Add("Legend", new IL2String("Legend"));
            dictUserRank["Legend"].Static = true;
            dictUserRank.Add("Veteran", new IL2String("Veteran"));
            dictUserRank["Veteran"].Static = true;
            dictUserRank.Add("Trusted user", new IL2String("Trusted user"));
            dictUserRank["Trusted user"].Static = true;
            dictUserRank.Add("Known user", new IL2String("Known user"));
            dictUserRank["Known user"].Static = true;
            dictUserRank.Add("User", new IL2String("User"));
            dictUserRank["User"].Static = true;
            dictUserRank.Add("New user", new IL2String("New user"));
            dictUserRank["New user"].Static = true;
            dictUserRank.Add("Visitor", new IL2String("Visitor"));
            dictUserRank["Visitor"].Static = true;
        }

        private static Dictionary<string, IL2String> dictUserRank = new Dictionary<string, IL2String>();
        public static IntPtr VRCPlayer_GetUserRank_String(IntPtr user)
        {
            if (user != IntPtr.Zero)
            {
                APIUser u = new APIUser(user);
                SocialRank rank = VRCPlayer.GetSocialRank(u);
                if (rank == SocialRank.VRChatTeam)
                {
                    return dictUserRank["Moderator"].ptr;
                }
                else if (rank == SocialRank.Nuisance)
                    return dictUserRank["Nuisance"].ptr;
                else if (rank == SocialRank.Legend)
                {
                    return dictUserRank["Legend"].ptr;
                }
                else if (rank == SocialRank.VeteranUser)
                {
                    return dictUserRank["Veteran"].ptr;
                }
                else if (rank == SocialRank.TrustedUser)
                {
                    return dictUserRank["Trusted user"].ptr;
                }
                else if (rank == SocialRank.KnownUser)
                {
                    return dictUserRank["Known user"].ptr;
                }
                else if (rank == SocialRank.User)
                {
                    return dictUserRank["User"].ptr;
                }
                else if (rank == SocialRank.NewUser)
                {
                    return dictUserRank["New user"].ptr;
                }
                else if (rank == SocialRank.Visitor)
                    return dictUserRank["Visitor"].ptr;
            }
            return dictUserRank["Error"].ptr;
        }
        /*
        // (VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3 position, Quaternion rotation)
        public static void NetworkInitalize(VRC_EventHandler.VrcBroadcastType broadcast, IntPtr prefabPathOrDynamicPrefabName, IntPtr position, IntPtr rotation)
        {
            if (prefabPathOrDynamicPrefabName == null || position == null || rotation == null) return;
            if (prefabPathOrDynamicPrefabName == IntPtr.Zero || position == IntPtr.Zero || rotation == IntPtr.Zero) return;
            Console.WriteLine("------");
            Console.WriteLine("[Init] broadcast: " + broadcast.ToString());
            Console.WriteLine("[Init] prefabPathOrDynamicPrefabName: " + new IL2Object(prefabPathOrDynamicPrefabName, null).Unbox<string>());
            Console.WriteLine("[Init] position: " + new IL2Object(position, null).Unbox<Vector3>().ToString());
            Console.WriteLine("[Init] methodName: " + new IL2Object(rotation, null).Unbox<Quaternion>().ToString());
            pInitalize.InvokeOriginal(new IntPtr[] { new IntPtr((int)broadcast), prefabPathOrDynamicPrefabName, position, rotation });
        }

        // (VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
        public static void RPCSend(VRC_EventHandler.VrcTargetType targetClients, IntPtr targetObject, IntPtr methodName, IntPtr parameters)
        {
            if (targetObject == null || targetObject == IntPtr.Zero) return;
            if (methodName == null || parameters == null) return;
            if (methodName == IntPtr.Zero || parameters == IntPtr.Zero) return;
            Console.WriteLine("------");
            Console.WriteLine("[RPC] targetClients: " + targetClients.ToString());
            Console.WriteLine("[RPC] methodName: " + new IL2Object(methodName, null).Unbox<string>());
            IntPtr[] arr = new IL2Object(parameters, null).UnboxArray();
            Console.WriteLine("[RPC] parameters: " + arr.Length);
            if (arr.Length == 3)
            {
                Console.WriteLine(arr[0].MonoCast<string>());
                Console.WriteLine(arr[1].MonoCast<string>());
                Console.WriteLine(arr[2].MonoCast<int>());
            }
            pRPCSend.InvokeOriginal(new IntPtr[] { new IntPtr((int)targetClients), targetObject, methodName, parameters });
        }
        */


        public static _RoomManagerBase_OnConnectedToMaster _delegateRoomManagerBase_OnConnectedToMaster;
        public static _VRC_UI_PageUserInfo_SetUserRelationshipState _delegateVRC_UI_PageUserInfo_SetUserRelationshipState;
        public static IL2Patch pInitalize;
        public static IL2Patch pRPCSend;
    }
}
