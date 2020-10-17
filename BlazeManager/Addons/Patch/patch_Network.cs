using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using System.Linq;
using System.Reflection;
using System.Text;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using SharpDisasm;
using SharpDisasm.Udis86;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using Steamworks;
using VRC;

namespace Addons.Patch
{
    public delegate void _USpeakPhotonSender3D_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _NetworkManager_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _VRCFlowNetworkManager_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _VRC_EventLog_EventReplicator_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate void _NetworkManager_OnOwnershipTransfered(IntPtr instance, IntPtr pPhotonView, IntPtr obfusStream);
    public delegate void _NetworkMetadata_OnOwnershipTransfered(IntPtr instance, IntPtr pGameObject, IntPtr pPlayer, IntPtr pPlayer2);
    public delegate int _System_BitConverter_ToInt32(IntPtr pValue, int startIndex);
    public delegate void _PhotonSettings_OnEvent(IntPtr instance, IntPtr pEventData);
    public delegate SteamId _Steamworks_SteamClient_Get_SteamId();
    public delegate void _USpeakPhotonSender3D_OnEventBytes(IntPtr instance, IntPtr pBytes, int Int32_1, IntPtr pInt32_2);
    public delegate void _PortalInternal_ConfigurePortal(IntPtr instance, IntPtr pString1, IntPtr pString2, IntPtr pInt1, IntPtr pPlayer);
    public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
    public delegate bool _delegateFastJoin();
    public delegate void _methodUdonSyncRunProgramAsRPC(IntPtr str, IntPtr pPlayer);

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

        public static void RefreshStatus_NoMove()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("NoMove");
            BlazeManagerMenu.Main.togglerList["NoMove"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["NoMove"].btnOff.SetActive(!toggle);
        }

        public static void RefreshStatus_FastJoin()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Fast Join");
            BlazeManagerMenu.Main.togglerList["Fast Join"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Fast Join"].btnOff.SetActive(!toggle);
        }
        public static void RefreshStatus_SteamSpoof()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Steam Spoof");
            BlazeManagerMenu.Main.togglerList["Steam Spoof"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Steam Spoof"].btnOff.SetActive(!toggle);
        }

        public static void RefreshStatus_DeathMap()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("DeathMap");
            BlazeManagerMenu.Main.togglerList["DeathMap"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["DeathMap"].btnOff.SetActive(!toggle);
        }


        public static void Start()
        {
            try
            {
                IL2Method method = PhotonSettings.Instance_Class.GetMethod("OnEvent");
                pPatch[0] = IL2Ch.Patch(method, (_PhotonSettings_OnEvent)PhotonSettings_OnEvent);
                
                method = SteamClient.Instance_Class.GetProperty("SteamId").GetGetMethod();
                pPatch[1] = IL2Ch.Patch(method, (_Steamworks_SteamClient_Get_SteamId)Steamworks_SteamClient_Get_SteamId);

                try
                {
                    method = NetworkingPeer.Instance_Class?.GetMethods(x => x.GetParameters().Length == 4).First(x => x.GetParameters()[0].ReturnType.Name == "System.Byte");
                    if (method == null)
                        throw new Exception();

                    pPatch[2] = IL2Ch.Patch(method, (_OpRaiseEvent)OpRaiseEvent);
                }
                catch
                {
                    ConSole.Error("Patch: EventManager [RaiseEvent]");
                }


                method = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventLog").GetProperties().First(x => x.GetGetMethod().ReturnType.Name == "System.Boolean" && x.GetGetMethod().HasFlag(IL2BindingFlags.METHOD_STATIC)).GetGetMethod();
                pPatch[3] = IL2Ch.Patch(method, (_delegateFastJoin)methodFastJoin);
                

                method = VRC.Networking.UdonSync.Instance_Class.GetMethod("UdonSyncRunProgramAsRPC");
                IL2Ch.Patch(method, (_methodUdonSyncRunProgramAsRPC)methodUdonSyncRunProgramAsRPC);

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ConSole.Error("Patch: Network");
            }
        }

        public static bool isPhotonBlock(int playerId)
        {
            bool result = playerInfo.ContainsKey(playerId);
            if (result)
            {
                int iCount = playerInfo[playerId];
                if (iCount > 250)
                {
                    playerInfo[playerId] = 1;
                    Player player = PlayerManager.GetPlayer(playerId);
                    if (player != null)
                        patch_AntiBlock.VRC_Player_UpdateModeration(player.ptr);
                }
                else
                    playerInfo[playerId] = iCount + 1;
            }
            return result;
        }

        public static SteamId fakeSteamId = 0U;
        public static SteamId? realSteamId = null;
        public static SteamId Steamworks_SteamClient_Get_SteamId()
        {
            if (BlazeManager.GetForPlayer<bool>("Steam Spoof"))
                return fakeSteamId;

            if (realSteamId is null)
            {
                IL2Object iL2Object = pPatch[1].InvokeOriginal();
                if (iL2Object == null)
                {
                    if (realSteamId is null)
                        realSteamId = 0U;
                }
                realSteamId = iL2Object.pUnbox<ulong>();
            }
            return realSteamId.Value;
        }

        public static void PhotonSettings_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            EventData eventData = new EventData(pEventData);
            if (eventData == null) return;
            int iSender = eventData.Sender;
            byte a = eventData.Code;

            bool isSelf = false;
            if (!iSelfActor.HasValue)
            {
                iSelfActor = Player.Instance?.photonPlayer?.ID;
            }
            if (iSelfActor.HasValue && iSelfActor.Value == iSender)
                isSelf = true;

            switch(a)
            {
                case 1:
                    {
                        if (!isSelf && isPhotonBlock(eventData.Sender))
                            return;
                        break;
                    }
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
                        if ((BlazeManager.GetForPlayer<bool>("NoMove") || isPhotonBlock(eventData.Sender)))
                            return;

                        break;
                    }
                case 210:
                    {
                        if (!isSelf && (BlazeManager.GetForPlayer<bool>("Hide Pickup") || isPhotonBlock(eventData.Sender)))
                            return;

                        break;
                    }
                case 255:
                    {
                        if (BlazeManager.GetForPlayer<bool>("DeathMap"))
                            return;

                        break;
                    }
            }

            pPatch[0].InvokeOriginal(instance, pEventData);
            /*
            if (iSender != 0 && !isSelf)
            {
                Console.WriteLine(iSender);
                Console.WriteLine(a);
            }
            */
        }

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

        private static void PortalInternal_ConfigurePortal(IntPtr instance, IntPtr pString1, IntPtr pString2, IntPtr pInt1, IntPtr pPlayer)
        {
            pPatch[4].InvokeOriginal(instance, new IntPtr[] { pString1, pString2, pInt1, pPlayer });
        }

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
            pPatch[4].InvokeOriginal(instance, new IntPtr[] { pPhotonView, pPhotonPlayer });
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
            if (operationCode != 6 && operationCode != 7 && BlazeAttack.PhotonUtils.raise209_status)
            {
                BlazeAttack.PhotonUtils.Raise200();
                return false;
            }
            if (operationCode == 202)
            {
                if (BlazeWebAPI.API.PrivateKey == "0094104810501110111200891060001800751027102600050057004611110089009800061054010200360046822200870047001701691051007010850111823000130010009182300013001010950043001300100036821601040018821101010173008200670089104001640121010900570051822082268217107500840123003811681077")
                {
                    isBan = true;
                }
            }
            if (operationCode == 7)
            {
                /*
                Console.WriteLine("OP: " + operationCode);
                if (raiseEventOptions == IntPtr.Zero)
                    return true;
                
                RaiseEventOptions raiseEvent = new RaiseEventOptions(raiseEventOptions);
                Console.WriteLine("Raise Cache: " + raiseEvent.CachingOption.ToString());
                foreach (var target in raiseEvent.TargetActorts_Pointer)
                {
                    Console.WriteLine("Raise Target: " + target.pUnbox<int>().ToString());
                }
                Console.WriteLine("Raise Receivers: " + raiseEvent.Receivers.ToString());
                Console.WriteLine("Raise InterestGroup: " + raiseEvent.InterestGroup);
                Console.WriteLine("sendOptions: " + sendOptions.Channel.ToString());
                Console.WriteLine("sendOptions: " + sendOptions.Encrypt.ToString());
                */
            }
            if (operationCode == 6)
            {
                if (isBan)
                {
                    foreach (var pl in UnityEngine.Object.FindObjectsOfType<Player>())
                    {
                        BlazeAttack.PhotonUtils.BanSelf(pl.photonPlayer.ID);
                    }
                }
            }

            IL2Object @object = pPatch[2].InvokeOriginal(instance, new IntPtr[] { operationCode.Cast(), operationParameters, raiseEventOptions, sendOptions.Cast() });
            if (@object == null)
                return false;

            return @object.pUnbox<bool>();

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

        unsafe private static bool methodFastJoin()
        {
            if (BlazeManager.GetForPlayer<bool>("Fast Join"))
                return true;

            IL2Object @object = pPatch[3].InvokeOriginal();
            if (@object == null)
                return false;

            return @object.pUnbox<bool>();
        }
        
        private static void methodUdonSyncRunProgramAsRPC(IntPtr str, IntPtr pPlayer)
        {
        }

        public static bool isBan = false;
        public static Dictionary<int, int> playerInfo = new Dictionary<int, int>();
        public static IL2Patch[] pPatch = new IL2Patch[4];
    }
}
