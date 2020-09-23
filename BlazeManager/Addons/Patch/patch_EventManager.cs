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
using ExitGames.Client.Photon;

namespace Addons.Patch
{
    public delegate void _RoomManagerBase_OnConnectedToMaster(IntPtr instance);
    public delegate void _NetworkInitalize(VRC_EventHandler.VrcBroadcastType broadcast, IntPtr prefabPathOrDynamicPrefabName, IntPtr position, IntPtr rotation);
    public delegate void _RPCSend(VRC_EventHandler.VrcTargetType targetClients, IntPtr targetObject, IntPtr methodName, IntPtr parameters);
    public delegate IntPtr _VRCPlayer_GetUserRank_String(IntPtr instance);
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
            BlazeManagerMenu.Main.togglerList["RPC Block"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["RPC Block"].btnOff.SetActive(!toggle);
        }


        unsafe public static void Start()
        {
            try
            {
                IL2Method method = RoomManagerBase.Instance_Class.GetMethod("OnConnectedToMaster");

                if (method == null)
                    throw new Exception();

                pOnConnectToMaster = IL2Ch.Patch(method, (_RoomManagerBase_OnConnectedToMaster)RoomManagerBase_OnConnectedToMaster);
                ConSole.Success("Patch: EventManager [JoinRoom]");

            }
            catch
            {
                ConSole.Error("Patch: EventManager [JoinRoom]");
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
                foreach (var m in VRCPlayer.Instance_Class.GetMethods(x => x.ReturnType.Name == "System.String" && x.GetParameters().Length == 1).Where(x => x.GetParameters()[0].ReturnType.Name == APIUser.Instance_Class.FullName))
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

                IL2Ch.Patch(method, (_VRCPlayer_GetUserRank_String)VRCPlayer_GetUserRank_String);
            }
            catch
            {
                ConSole.Error("Patch: EventManager [User Ranked]");
            }
            try
            {
                IL2Method method = VRC.UI.PageUserInfo.Instance_Class?.GetMethods(x => x.GetParameters().Length == 1).First(x => x.GetParameters()[0].ReturnType.Name.StartsWith("VRC.UI.PageUserInfo."));
                if (method == null)
                    throw new Exception();

                pVRC_UI_PageUserInfo_SetUserRelationshipState = IL2Ch.Patch(method, (_VRC_UI_PageUserInfo_SetUserRelationshipState)VRC_UI_PageUserInfo_SetUserRelationshipState);
            }
            catch
            {
                ConSole.Error("Patch: EventManager [PUI State]");
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
            pVRC_UI_PageUserInfo_SetUserRelationshipState.InvokeOriginal(instance, new IntPtr[] { friendType });
            BlazeManagerMenu.Edit_UserPanel.OnEnter_ShowProfile();
        }

        public static float UnityEngine_Time_fixedDeltaTime()
        {
            return 0.001f;
        }
        public static void RoomManagerBase_OnConnectedToMaster(IntPtr instance)
        {
            pOnConnectToMaster.InvokeOriginal(instance);
            Threads.bFirstThreadInRoom = false;
            patch_Network.iSelfActor = null;
            patch_GlobalDynamicBones.currentPlayer = null;
            patch_GlobalDynamicBones.timeToUpdate = 10f;
            BlazeManager.SetForPlayer("DeathMap", false);
            PortableMirror.OnDestroy();
            Cam3th.OnDestroy();
            // BlazeAttack.PhotonUtils.raise209_status = false;
        }

        public static IntPtr VRCPlayer_GetUserRank_String(IntPtr instance)
        {
            string textRank = ":: N/A ::";
            if (instance != IntPtr.Zero)
            {
                SocialRank rank = VRCPlayer.GetSocialRank(new APIUser(instance));
                if (rank == SocialRank.VRChatTeam)
                    textRank = "Moderator";
                else if (rank == SocialRank.Nuisance)
                    textRank = "Nuisance";
                else if (rank == SocialRank.Legend)
                    textRank = "Legend";
                else if (rank == SocialRank.VeteranUser)
                    textRank = "Veteran";
                else if (rank == SocialRank.TrustedUser)
                    textRank = "Trusted user";
                else if (rank == SocialRank.KnownUser)
                    textRank = "Known User";
                else if (rank == SocialRank.User)
                    textRank = "User";
                else if (rank == SocialRank.NewUser)
                    textRank = "New User";
                else if (rank == SocialRank.Visitor)
                    textRank = "Visitor";
            }
            return IL2Import.il2cpp_string_new_len(textRank, textRank.Length);
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


        public static IL2Patch pOnConnectToMaster;
        public static IL2Patch pInitalize;
        public static IL2Patch pRPCSend;
        public static IL2Patch pOpRaiseEvent;
        public static IL2Patch pVRC_UI_PageUserInfo_SetUserRelationshipState;
    }
}
