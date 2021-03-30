using System;
using System.Collections.Generic;
using System.Linq;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using UnityEngine;
using IL2ExitGames.Client.Photon;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using Steamworks;
using VRC;
using VRC.Core;
using SharpDisasm;
using SharpDisasm.Udis86;
using System.Globalization;
using Addons.Mods.UI;
using Addons.Mods;

namespace Addons.Patch
{
    public delegate void _USpeakPhotonSender3D_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _NetworkManager_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _VRCFlowNetworkManager_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _VRC_EventLog_EventReplicator_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _NetworkManager_OnOwnershipTransfered(IntPtr instance, IntPtr pPhotonView, IntPtr obfusStream);
    public delegate void _NetworkMetadata_OnOwnershipTransfered(IntPtr instance, IntPtr pGameObject, IntPtr pPlayer, IntPtr pPlayer2);
    public delegate int _System_BitConverter_ToInt32(IntPtr pValue, int startIndex);
    public delegate void _LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _USpeakPhotonSender3D_OnEventBytes(IntPtr instance, IntPtr pBytes, int Int32_1, IntPtr pInt32_2);
    public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
    public delegate bool _methodFastJoin();
    public delegate void _methodUdonSyncRunProgramAsRPC(IntPtr str, IntPtr pPlayer);
    public delegate void _methodTimerBloop(IntPtr pPlayer);
    public delegate void _SendMessage(IntPtr instance, IntPtr methodName, SendMessageOptions options);
    public delegate int _NetworkPing();

    public static class patch_Network
    {
        public static void Toggle_FastJoin()
        {
            BlazeManager.SetForPlayer("Fast Join", !BlazeManager.GetForPlayer<bool>("Fast Join"));
            RefreshStatus_FastJoin();
        }

        public static void Toggle_SteamSpoof()
        {
            BlazeManager.SetForPlayer("Steam Spoof", !BlazeManager.GetForPlayer<bool>("Steam Spoof"));
            RefreshStatus_SteamSpoof();
            VRCPlayer.Refresh_Properties();
        }

        public static void Toggle_Enable_NoMove()
        {
            BlazeManager.SetForPlayer("NoMove", !BlazeManager.GetForPlayer<bool>("NoMove"));
            RefreshStatus_NoMove();
        }

        public static void Toggle_Enable_DeathMap()
        {
            BlazeManager.SetForPlayer("DeathMap", !BlazeManager.GetForPlayer<bool>("DeathMap"));
            RefreshStatus_DeathMap();
        }

        public static void Toggle_FakePing()
        {
            BlazeManager.SetForPlayer("Fake Ping", !BlazeManager.GetForPlayer<bool>("Fake Ping"));
            RefreshStatus_FakePing();
        }

        public static void RefreshStatus_FakePing()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Fake Ping");
            BlazeManagerMenu.Main.togglerList["Fake Ping"].SetToggleToOn(toggle, false);
        }
        public static void Toggle_Enable_Serilize()
        {
            BlazeManager.SetForPlayer("Photon Serilize", !BlazeManager.GetForPlayer<bool>("Photon Serilize"));
            RefreshStatus_Serilize();
        }

        public static void RefreshStatus_Serilize()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Photon Serilize");
            BlazeManagerMenu.Main.togglerList["Photon Serilize"].SetToggleToOn(toggle, false);
        }
        public static void RefreshStatus_NoMove()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("NoMove");
            BlazeManagerMenu.Main.togglerList["NoMove"].SetToggleToOn(toggle, false);
            }

        public static void RefreshStatus_FastJoin()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Fast Join");
            BlazeManagerMenu.Main.togglerList["Fast Join"].SetToggleToOn(toggle, false);
        }
        public static void RefreshStatus_SteamSpoof()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Steam Spoof");
            BlazeManagerMenu.Main.togglerList["Steam Spoof"].SetToggleToOn(toggle, false);
        }

        public static void RefreshStatus_DeathMap()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("DeathMap");
            BlazeManagerMenu.Main.togglerList["DeathMap"].SetToggleToOn(toggle, false);
        }


        public static void Start()
        {
            try
            {
                IL2Method method = LoadBalancingClient.Instance_Class.GetMethod("OnEvent");
                if (method == null)
                    throw new Exception("0x0M1");

                var patch = IL2Ch.Patch(method, (_LoadBalancingClient_OnEvent)LoadBalancingClient_OnEvent);
                if (patch == null)
                    throw new Exception("0x0M2");
                _delegateLoadBalancingClient_OnEvent = patch.CreateDelegate<_LoadBalancingClient_OnEvent>();
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("OnEvent");
            }

            try
            {
                IL2Method method = null;
                (method = LoadBalancingClient.Instance_Class?.GetMethod(x => x.IsPublic && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName)).Name = "OpRaiseEvent";
                if (method == null)
                    throw new Exception("0x0M6");

                IL2Patch patch = IL2Ch.Patch(method, (_OpRaiseEvent)OpRaiseEvent);
                if (patch == null)
                    throw new Exception("0x0M6");
                _delegateOpRaiseEvent = patch.CreateDelegate<_OpRaiseEvent>();
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("OpRaiseEvent");
            }

            try
            {
                IL2Method method = VRC.UI.DebugDisplayText.Instance_Class.GetMethod("Update");
                var methods = PhotonNetwork.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(int).FullName && x.GetParameters().Length == 0);

                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method, 0x512);
                    var instructions = disassembler.Disassemble().Where(x => ILCode.IsCall(x));
                    foreach (var instruction in instructions)
                    {
                        IntPtr addr = ILCode.GetPointer(instruction);
                        if ((method = methods.FirstOrDefault(x => *(IntPtr*)x.ptr == addr)) != null)
                            break;
                    }
                }
                IL2Patch patch = IL2Ch.Patch(method, (_NetworkPing)methodNetworkPing);
                if (patch == null)
                    throw new Exception("0x0M6");
                _delegateNetworkPing = patch.CreateDelegate<_NetworkPing>();
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("FakePing");
            }
            //method = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventLog").GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName && x.IsStatic).GetGetMethod();
            //patch = IL2Ch.Patch(method, (_methodFastJoin)methodFastJoin);
            //_delegateFastJoin = patch.CreateDelegate<_methodFastJoin>();

            //method = VRC.Networking.UdonSync.Instance_Class.GetMethod("UdonSyncRunProgramAsRPC");
            //IL2Ch.Patch(method, (_methodUdonSyncRunProgramAsRPC)methodUdonSyncRunProgramAsRPC);
            /*
            method = VRC.UserCamera.UserCameraIndicator.Instance_Class.GetMethod("PhotoCapture");
            IL2Ch.Patch(method, (_methodTimerBloop)methodTimerBloop);

            method = VRC.UserCamera.UserCameraIndicator.Instance_Class.GetMethod("TimerBloop");
            IL2Ch.Patch(method, (_methodTimerBloop)methodTimerBloop);
            */

            //method = Component.Instance_Class.GetMethod("SendMessage", x=> x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "options");
            //patch = IL2Ch.Patch(method, (_SendMessage)SendMessage);
            //_delegateSendMessage = patch.CreateDelegate<_SendMessage>();

            //IL2Method method = USpeakPhotonSender3D.Instance_Class.GetMethods().First(m => m.GetParameters().Length == 1 && m.GetParameters()[0].typeName == "ExitGames.Client.Photon.EventData");
            //pPatch[0] = IL2Ch.Patch(method, (_USpeakPhotonSender3D_OnEvent)USpeakPhotonSender3D_OnEvent);

            //method = NetworkManager.Instance_Class.GetMethods().First(m => m.GetParameters().Length == 1 && m.GetParameters()[0].typeName == "ExitGames.Client.Photon.EventData");
            //pPatch[1] = IL2Ch.Patch(method, (_NetworkManager_OnEvent)NetworkManager_OnEvent);

            //method = Assemblies.a["Assembly-CSharp"].GetClass("VRCFlowNetworkManager").GetMethods().First(m => m.GetParameters().Length == 1 && m.GetParameters()[0].typeName == "ExitGames.Client.Photon.EventData");
            //pPatch[2] = IL2Ch.Patch(method, (_VRCFlowNetworkManager_OnEvent)VRCFlowNetworkManager_OnEvent);

            //method = VRC_EventLog.EventReplicator.Instance_Class.GetMethods().First(m => m.GetParameters().Length == 1 && m.GetParameters()[0].typeName == "ExitGames.Client.Photon.EventData" && m.Name == method.Name);
            //pPatch[3] = IL2Ch.Patch(method, (_VRC_EventLog_EventReplicator_OnEvent)VRC_EventLog_EventReplicator_OnEvent);

            //method = NetworkManager.Instance_Class.GetMethods().First(m => m.GetParameters().Length == 2 && m.GetParameters()[0].typeName == "Photon.Pun.PhotonView" && m.Name != "OnOwnershipRequest");
            //pPatch[4] = IL2Ch.Patch(method, (_NetworkManager_OnOwnershipTransfered)NetworkManager_OnOwnershipTransfered);
            //method = Assemblies.a["Assembly-CSharp"].GetClass("NetworkMetadata").GetMethods().First(m => m.GetParameters().Length == 3 && m.GetParameters()[0].typeName == "UnityEngine.GameObject");
            //pPatch[4] = IL2Ch.Patch(method, (_NetworkMetadata_OnOwnershipTransfered)NetworkMetadata_OnOwnershipTransfered);

            //method = Assemblies.a["mscorlib"].GetClass("BitConverter", "System").GetMethod("ToInt32");
            //pPatch[5] = IL2Ch.Patch(method, (_System_BitConverter_ToInt32)System_BitConverter_ToInt32);

            //IL2Method method = PortalInternal.Instance_Class.GetMethod("ConfigurePortal");
            // pPatch[4] = IL2Ch.Patch(method, (_PortalInternal_ConfigurePortal)PortalInternal_ConfigurePortal);
        }

        /*
        public static bool isPhotonBlock(int playerId)
        {
            bool result = playerInfo.ContainsKey(playerId);
            if (result)
            {
                int iCount = playerInfo[playerId];
                if (iCount > 250)
                {
                    playerInfo[playerId] = 1;
                    VRC.Player player = PlayerManager.GetPlayer(playerId);
                    VRCPlayer vrcPlayer = player?.Components;
                    if (vrcPlayer != null)
                        patch_AntiBlock.VRCPlayer_RefreshState(vrcPlayer.ptr);
                }
                else
                    playerInfo[playerId] = iCount + 1;
            }
            return result;
        }
        */

        public static void LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (instance == IntPtr.Zero) return;
            EventData eventData = new EventData(pEventData);
            if (eventData == null) return;
            bool isSelf = false;
            if (VRC.Player.Instance?.PhotonPlayer?.ActorNumber == eventData.Sender)
                isSelf = true;

            switch (eventData.Code)
            {
                /*
                case 1:
                    {
                        if (player.IsMuted)
                            return;

                        break;
                    }
                */
                case 6:
                    {
                        if (!isSelf && BlazeManager.GetForPlayer<bool>("RPC Block"))
                            return;

                        break;
                    }
                case 7:
                    {
                        if (isSelf)
                            return;
                        if ((BlazeManager.GetForPlayer<bool>("NoMove")))
                            return;

                        break;
                    }
                case PunEvent.OwnershipRequest:
                    {
                        if (!isSelf && (BlazeManager.GetForPlayer<bool>("Hide Pickup")))
                            return;

                        break;
                    }
                case PunEvent.OwnershipTransfer:
                    {
                        if (!isSelf && (BlazeManager.GetForPlayer<bool>("Hide Pickup")))
                            return;

                        break;
                    }
                case EventCode.SetProperties:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case EventCode.Leave:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case EventCode.Join:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        if (BlazeManager.GetForPlayer<bool>("DeathMap"))
                            return;

                        break;
                    }
            }
            try
            {
                _delegateLoadBalancingClient_OnEvent.Invoke(instance, pEventData);
            }
            catch { }
            /*
            if (iSender != 0 && !isSelf)
            {
                Console.WriteLine(iSender);
                Console.WriteLine(a);
            }
            */
        }
        public static _LoadBalancingClient_OnEvent _delegateLoadBalancingClient_OnEvent;

        public static int? iSelfActor = null;
        /*
        public static void NetworkManager_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (isValidEventData(pEventData))
                pPatch[1].InvokeOriginal(instance, pEventData);

        }

        private static void VRCFlowNetworkManager_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (isValidEventData(pEventData))
                pPatch[2].InvokeOriginal(instance, pEventData);
        }

        private static void VRC_EventLog_EventReplicator_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (isValidEventData(pEventData))
                pPatch[3].InvokeOriginal(instance, pEventData);
        }*/


        private static void NetworkManager_OnOwnershipTransfered(IntPtr instance, IntPtr pPhotonView, IntPtr pPhotonPlayer)
        {
            /*
            if (pPhotonPlayer == IntPtr.Zero) return;
            PhotonPlayer photonPlayer = new PhotonPlayer(pPhotonPlayer);
            if (photonPlayer == null) return;
            int id = photonPlayer.ID;
            if (playerInfo.ContainsKey(id))
            {
                if (++playerInfo[id] > 200)
                    return;
            }
            else
            {
                playerInfo.Add(id, 1);
            }
            */
            // pPatch[4].InvokeOriginal(instance, new IntPtr[] { pPhotonView, pPhotonPlayer });
        }

        private static void NetworkMetadata_OnOwnershipTransfered(IntPtr instance, IntPtr pGameObject, IntPtr pPlayer, IntPtr pPlayer2)
        {
            /*
            if (instance == IntPtr.Zero || pGameObject == IntPtr.Zero
                || pPlayer == IntPtr.Zero || pPlayer2 == IntPtr.Zero) return;
            
            GameObject gameObject = new GameObject(pGameObject);
            Player player = new Player(pPlayer);
            Player player2 = new Player(pPlayer2);
            if (playersGameObject.Contains(player) || playersGameObject.Contains(player2)) return;
            if (gameObject?.GetComponent(typeof(VRCSDK2.VRC_Pickup)) == null && gameObject?.GetComponent(typeof(VRC.SDK3.Components.VRCPickup)) == null)
            {
                if (!playersGameObject.Contains(player))
                    playersGameObject.Add(player);
                if (!playersGameObject.Contains(player2))
                    playersGameObject.Add(player2);
                return;
            }
            pPatch[4].InvokeOriginal(instance, new IntPtr[] { pGameObject, pPlayer, pPlayer2 });
            */
        }

        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
        {
            if (BlazeManager.GetForPlayer<bool>("Photon Serilize"))
            {
                if (operationCode != 1)
                {
                    return true;
                }
            }
            /*
            if (operationCode == 8)
            {
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("operationParameters[]: ");
                unsafe
                {
                    long length = *((long*)operationParameters + 3);
                    IntPtr[] result = new IntPtr[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = *(IntPtr*)((IntPtr)((long*)operationParameters + 4) + i * sizeof(byte));
                    }

                    List<byte> vs = new List<byte>();
                    foreach (var dd in result)
                        vs.Add(dd.pUnbox<byte>());
                    using (var cx = System.IO.File.AppendText("test.by.txt"))
                    {
                        cx.WriteLine("".PadRight(30, '-'));
                        foreach (var tt in vs)
                        {
                            cx.WriteLine(tt.ToString());
                        }
                    }
                    unsafe
                    {
                        Console.WriteLine(new IL2Type(IL2Import.il2cpp_class_from_system_type(IL2Import.il2cpp_type_get_object(*(IntPtr*)operationParameters + 0x20))).FullName);
                    }
                }
                //Hashtable test = new Hashtable(operationParameters);
                // Console.WriteLine(test.ToString());
                //Console.WriteLine(new IL2ReturnType(IL2Import.il2cpp_field_get_type(operationParameters)).Name);
                /*
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("operationParameters[4 Start]: ");
                var res = test[IL2Import.CreateNewObject(4, IL2SystemClass.Byte)];
                unsafe
                {
                    long length = *((long*)res + 3);
                    IntPtr[] result = new IntPtr[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = *(IntPtr*)((IntPtr)((long*)res + 4) + i * sizeof(int));
                    }

                    List<int> vs = new List<int>();
                    foreach (var dd in result)
                        vs.Add(dd.pUnbox<int>());
                    foreach (var tt in vs)
                    {
                        Console.WriteLine(tt);
                    }
                }
                */
        /*
                Console.WriteLine("".PadRight(30, '-'));
                RaiseEventOptions raise = new RaiseEventOptions(raiseEventOptions);
                Console.WriteLine("RaiseEventOptions[CachingOption]: " + raise.CachingOption.ToString());
                Console.WriteLine("RaiseEventOptions[InterestGroup]: " + raise.InterestGroup.ToString());
                Console.WriteLine("RaiseEventOptions[Receivers]: " + raise.Receivers.ToString());
                // Console.WriteLine("RaiseEventOptions[TargetActors]: " + raise.TargetActors_Patched.ToString());

                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("sendOptions[Channel]: " + sendOptions.Channel.ToString());
                Console.WriteLine("sendOptions[DeliveryMode]: " + sendOptions.DeliveryMode.ToString());
                Console.WriteLine("sendOptions[Encrypt]: " + sendOptions.Encrypt.ToString());
                Console.WriteLine("".PadRight(30, '-'));
            }
            /*
            if (operationCode == 202)
            {
                Console.WriteLine("operationCode: " + operationCode);
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("operationParameters[]: ");
                Hashtable test = new Hashtable(operationParameters);
                Console.WriteLine(test.ToString());
                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("operationParameters[4 Start]: ");
                var res = test[IL2Import.CreateNewObject(4, IL2SystemClass.Byte)];
                unsafe
                {
                    long length = *((long*)res + 3);
                    IntPtr[] result = new IntPtr[length];
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = *(IntPtr*)((IntPtr)((long*)res + 4) + i * sizeof(int));
                    }

                    List<int> vs = new List<int>();
                    foreach(var dd in result)
                        vs .Add(dd.pUnbox<int>());
                    foreach(var tt in vs)
                    {
                        Console.WriteLine(tt);
                    }
                }
                Console.WriteLine("".PadRight(30, '-'));
                RaiseEventOptions raise = new RaiseEventOptions(raiseEventOptions);
                Console.WriteLine("RaiseEventOptions[CachingOption]: " + raise.CachingOption.ToString());
                Console.WriteLine("RaiseEventOptions[InterestGroup]: " + raise.InterestGroup.ToString());
                Console.WriteLine("RaiseEventOptions[Receivers]: " + raise.Receivers.ToString());
                // Console.WriteLine("RaiseEventOptions[TargetActors]: " + raise.TargetActors_Patched.ToString());

                Console.WriteLine("".PadRight(30, '-'));
                Console.WriteLine("sendOptions[Channel]: " + sendOptions.Channel.ToString());
                Console.WriteLine("sendOptions[DeliveryMode]: " + sendOptions.DeliveryMode.ToString());
                Console.WriteLine("sendOptions[Encrypt]: " + sendOptions.Encrypt.ToString());
                Console.WriteLine("".PadRight(30, '-'));
            }
            */
            try
            {
                return _delegateOpRaiseEvent(instance, operationCode, operationParameters, raiseEventOptions, sendOptions);
            }
            catch { return false; }
            /*
            if (operationCode == 3 || operationCode == 202 || operationCode == 8 || operationCode == 6 || operationCode == 1)
            {
                return pOpRaiseEvent.InvokeOriginal(instance, new IntPtr[] { operationCode.Cast(), operationParameters, raiseEventOptions, sendOptions.Cast() }) != null;
            }
            else
            {
                if (operationCode == 7)
                {
                    Console.WriteLine("OP: " + operationCode);
                    Console.WriteLine("OP param: " + new IL2ReturnType(IL2Import.il2cpp_field_get_type(operationParameters)).Name);
                    if (raiseEventOptions == IntPtr.Zero)
                        return true;

                    RaiseEventOptions raiseEvent = new RaiseEventOptions(raiseEventOptions);
                    Console.WriteLine("Raise Cache: " + raiseEvent.CachingOption.ToString());
                    foreach (var target in raiseEvent.TargetActors)
                    {
                        Console.WriteLine("Raise Target: " + target.ToString());
                    }
                    Console.WriteLine("Raise Receivers: " + raiseEvent.Receivers.ToString());
                    Console.WriteLine("Raise InterestGroup: " + raiseEvent.InterestGroup);
                    Console.WriteLine("sendOptions: " + sendOptions.Channel.ToString());
                    Console.WriteLine("sendOptions: " + sendOptions.Encrypt.ToString());
                }
            }
            return true;
            */
        }
        public static _OpRaiseEvent _delegateOpRaiseEvent;

        unsafe private static bool methodFastJoin()
        {
            if (BlazeManager.GetForPlayer<bool>("Fast Join"))
                return true;

            return _delegateFastJoin.Invoke();
        }
        public static _methodFastJoin _delegateFastJoin;

        private static void methodUdonSyncRunProgramAsRPC(IntPtr str, IntPtr pPlayer)
        {
        }
        
        private static void methodTimerBloop(IntPtr pPlayer)
        {
        }
        
        
        private static int methodNetworkPing()
        {
            int result = 777;
            if (!BlazeManager.GetForPlayer<bool>("Fake Ping") || VRC.Player.Instance == null)
                result = _delegateNetworkPing.Invoke();
            return result;
        }

        public static _NetworkPing _delegateNetworkPing;

        private static void SendMessage(IntPtr instance, IntPtr methodName, SendMessageOptions options)
        {
            if (new IL2String(methodName).ToString().Replace("ǅ", string.Empty).Replace("Ǆ", string.Empty).Length != 0)
                _delegateSendMessage.Invoke(instance, methodName, options);
        }

        public static _SendMessage _delegateSendMessage;

        public static Dictionary<int, int> playerInfo = new Dictionary<int, int>();
        public static IL2Patch[] pPatch = new IL2Patch[4];
    }
}
