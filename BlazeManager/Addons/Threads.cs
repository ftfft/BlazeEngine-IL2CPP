using System;
using System.Linq;
using System.Threading;
using UnityEngine;
using Addons.Mods;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using Addons.Patch;
using Addons.Utils;
using VRCSDK2;
using IL2Photon.Pun.UtilityScripts;
using IL2Photon.Pun;
using VRC.UserCamera;
using Addons.Mods.UI;
using System.Collections.Generic;
using VRC.Core;

namespace Addons
{
    public delegate void _Control_Thread_Update(IntPtr instance);
    public delegate void _Control_Thread_GUI(IntPtr instance);
    public delegate void _Nulled(IntPtr instance);
    public delegate void _udonSync(IntPtr instance, IntPtr ptrString, IntPtr ptrPlayer);
    public delegate IntPtr _Nulled2(IntPtr instance);
    public static class Threads
    {
        public static void FAction(IntPtr result)
        {
            Console.WriteLine("Faction success " + result);
        }

        public static string AvatarId { get; set; }

        internal static void Start()
        {
            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Start");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_Nulled2)Nulled2);
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading [NuLLed]");
            }
            
            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Awake");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_Nulled)Nulled);
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading [NuLLed 2]");
            }
            
            
            try
            {

                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("Reset");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_Nulled)Nulled);
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading [NuLLed 3]");
            }

            try
            {
                IL2Method method = PhotonLagSimulationGui.Instance_Class.GetMethod("OnGUI");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_Control_Thread_GUI)Control_Thread_GUI);
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading [ONGUI]");
            }

            try
            {
                IL2Method method = InteractivePlayer.Instance_Class.GetMethod("Update");
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_Control_Thread_Update)Control_Thread_Update);
                _delegateControl_Thread_Update = patch.CreateDelegate<_Control_Thread_Update>();
                if (_delegateControl_Thread_Update == null)
                    throw new Exception();
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading");
            }
        }

        public static void Nulled(IntPtr instance) { }
        public static IntPtr Nulled2(IntPtr instance) { return IntPtr.Zero; }

        /*
        private static IL2Patch pUdonSync = null;
        public static void udonSync(IntPtr instance, IntPtr ptrString, IntPtr ptrPlayer)
        {
            Console.WriteLine(IL2Import.IntPtrToString(ptrString));
            pUdonSync.InvokeOriginal(instance, new IntPtr[] { ptrString, ptrPlayer });
        }
        */
        public static void Control_Thread_GUI(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            if (Input.GetKey(KeyCode.Tab))
            {
                if (VRC.Player.Instance != null)
                    TabMenu.ShowMenu();
                return;
            }
        }



        private static _Control_Thread_Update _delegateControl_Thread_Update;
        public static void Control_Thread_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            if (!string.IsNullOrEmpty(AvatarId))
            {
                Avatar.SelectAvatar(AvatarId);
                AvatarId = null;
            }
            
            if (Input.GetKeyDown(KeyCode.PageUp))
            {
                GameObject PortalGameObject = UserUtils.GlobalDisableColliders(VRC.Player.Instance.transform);

                PortalInternal portalInternal = PortalGameObject?.GetComponent<PortalInternal>();
                if (portalInternal != null)
                {
                    portalInternal.SetTimerRPC(float.NegativeInfinity, VRC.Player.Instance);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.PageDown))
            {

                /*
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    GameObject SelectColesion = hit.transform.gameObject;
                    if (SelectColesion != null)
                    {
                        if (SelectColesion.GetComponent<VRC_Pickup>() != null || SelectColesion.GetComponent<VRC.SDK3.Components.VRCPickup>() != null)
                        {
                            PhotonNetwork.TransferOwnership(SelectColesion.GetComponent<IL2Photon.Pun.PhotonView>().viewIdField, VRC.Player.Instance.PhotonPlayer.ActorNumber);
                            PhotonNetwork.RequestOwnership(SelectColesion.GetComponent<IL2Photon.Pun.PhotonView>().viewIdField, VRC.Player.Instance.PhotonPlayer.ActorNumber);
                            SelectColesion.transform.position = new Vector3(float.NaN, float.NaN, float.NaN);
                        }
                    }
                }
                */
                var test = VRC.UI.PageAvatar.Instance_Class.GetMethod(x => x.GetParameters().Length == 3 && x.GetParameters()[2].ReturnType.Name.EndsWith("AvatarFavoriteGroups"));
                Console.WriteLine(test.GetParameters()[2].DefaultValue.unbox_Unmanaged<int>());
                return;
            }
            /*
            if (Input.GetKey(KeyCode.Space))
            {
                var jump = VRCPlayer.Instance?.GetComponent<GamelikeInputController>()?.inJump;
                if (jump != null)
                {
                    if (!jump.bValue || jump.bValuePrev)
                    {
                        jump.bValue = true;
                        jump.bValuePrev = false;
                    }
                    else if (!VRC.Player.Instance.GetComponent<CharacterController>().isGrounded)
                    {
                        jump.bValue = false;
                        jump.bValuePrev = true;
                    }

                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                new ApiAvatar
                {
                    id = "avtr_5b5b1269-1b46-4920-ad44-9f37fa499e53"
                }.Fetch(FAction);
                // PhotonClient.API.PhotonNetwork.Disconnect();
                // Console.WriteLine("T1: " + PhotonClient.API.PhotonNetwork.NetworkClientState.ToString());
            }
            */
            /*
            if (Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                PhotonClient.API.Helpers.InstantiateSelf();
                // Console.WriteLine("T1: " + PhotonClient.API.PhotonNetwork.NetworkClientState.ToString());
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                new Thread(() => {

                    if (!PhotonClient.API.PhotonNetwork.ConnectToNameServer())
                        return;

                    while (PhotonClient.API.PhotonNetwork.IsConnected && !PhotonClient.API.PhotonNetwork.IsConnectedAndReady)
                        Thread.Sleep(50);

                    if (!PhotonClient.API.PhotonNetwork.IsConnectedAndReady)
                    {
                        Console.WriteLine("[INFO] Failed connecting to photon!");
                    }
                    else
                    {
                        Console.WriteLine("[INFO] Now connected to masterserver!");
                        while (PhotonClient.API.PhotonNetwork.isWaitState)
                        {
                            Thread.Sleep(50);
                        }
                        if (!PhotonClient.API.PhotonNetwork.IsConnectedAndReady)
                            return;

                        if (PhotonClient.API.PhotonNetwork.JoinOrCreateRoom(RoomManager.currentRoom.id + ":" + RoomManager.currentRoom.currentInstanceIdWithTags))
                        {
                        }
                    }
                }).Start();
                return;
            }
            */
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                foreach(var player in TabMenu.players)
                {
                    foreach (var obj in NoLocalPickup.gameObjects)
                    {
                        VRC.Network.SetOwner(player, obj, VRC.Network.OwnershipModificationType.Pickup, false);
                        VRC.Network.SetOwner(player, obj, VRC.Network.OwnershipModificationType.Collision, false);
                        VRC.Network.SetOwner(player, obj, VRC.Network.OwnershipModificationType.Destroy, false);
                        VRC.Network.SetOwner(player, obj, VRC.Network.OwnershipModificationType.Request, false);
                        VRC.Network.SetOwner(player, obj, VRC.Network.OwnershipModificationType.Serialization, false);
                    }
                }
                // FileDebug.debugGameObject("actionDriver.json", ActionMenuDriver.Instance.gameObject);
                // Notification.SendMessage(TabMenu.playerPhoton, "Test");
                // Console.WriteLine(VRC.User.CreateSessionIdForUser(TabMenu.playerPhoton.userId));
                // Console.WriteLine(VRC.Player.Instance.photonPlayer.RoomReference.CustomProperties.ToString());
                return;
            }
            /*
            if (Input.GetKey(KeyCode.PageDown))
            {
                int randId = rand.Next(5, 100);
                BlazeAttack.PhotonUtils.FakeFlood_210(randId, 0);
                BlazeAttack.PhotonUtils.FakeFlood_209(randId, 0);
                BlazeAttack.PhotonUtils.Raise200();
                return;
            }
            */

            if (Cam3th._isEnable)
                Cam3th.Update();

            _delegateControl_Thread_Update.Invoke(instance);

            if (Cam3th._isEnable)
                Cam3th.LateUpdate();

            if (!bFirstThreadControl)
            {
                bFirstThreadControl = true;
                Application.targetFrameRate = 101;
                BlazeManagerMenu.Main.CreateMenu();
                BlazeManagerMenu.Edit_UserPanel.Start();
                BlazeManagerMenu.Edit_WorldPanel.Start();
                return;
            }
            
            if (!bFirstThreadInRoom)
            {
                bFirstThreadInRoom = true;
                //NoLocalPickup.ClearObjects();
                //NoLocalPickup.Update();
                patch_Network.playerInfo.Clear();
                patch_ForceMute.forceMuteList.Clear();
                /*
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (gameObject != null)
                {
                    gameObject.GetComponent<MeshFilter>()?.Destroy();
                    gameObject.GetComponent<BoxCollider>()?.Destroy();
                    gameObject.GetComponent<MeshRenderer>()?.Destroy();
                    gameObject.GetOrAddComponent<PhotonLagSimulationGui>();
                }
                */
                patch_Network.RefreshStatus_DeathMap();
                patch_Network.RefreshStatus_Serilize();
                return;
            }
            Avatars.UIAvatar.resfresh = 3;
            FlyMode.Update();
            MultiHack.Update();
            if (InfinityJump.isEnabled)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    InfinityJump.EventJump();
                }
            }
            /*
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                UserCameraController.Instance.mode = UserCameraMode.Off;
            }
            */
            if (!Input.GetKey(KeyCode.LeftControl)) return;


            if (!Cam3th._isEnable)
            {
                float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
                if (mouseWheel > 0.1)
                {
                    Camera.main.transform.localPosition = Camera.main.transform.localPosition + (Vector3.up * 0.1f);
                }
                else if (mouseWheel < -0.1)
                {
                    Camera.main.transform.localPosition = Camera.main.transform.localPosition - (Vector3.up * 0.1f);
                }
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                /*
                var mm = QuickMenu.Instance_Class.GetMethods().First(x=> !x.IsStatic && x.HasFlag(IL2BindingFlags.METHOD_PRIVATE)
                && x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2
                && x.GetParameters()[0].ReturnType.Name == typeof(bool).FullName
                && x.GetParameters()[1].ReturnType.Name == typeof(bool).FullName);
                Console.WriteLine(mm.GetParameters()[0].MonoCast<bool>().ToString());
                Console.WriteLine(mm.GetParameters()[1].MonoCast<bool>().ToString());
                /*
                Name = "DisableGravity",
					EventType = VRC_EventHandler.VrcEventType.SendRPC,
					ParameterInt = 0,
					ParameterString = "DisableGravity",
					ParameterObjects = new GameObject[]
                    {
                        base.gameObject
                    }
                /*
                VRC.Player[] players = UnityEngine.Object.FindObjectsOfType<VRC.Player>();
                if (++BlazeAttack.PhotonUtils.raise209_num >= players.Length)
                    BlazeAttack.PhotonUtils.raise209_num = 0;

                if (players.Length < 2) return;
                int plId = players.Skip(BlazeAttack.PhotonUtils.raise209_num).First().photonPlayer.ID;
                foreach (var obj in NoLocalPickup.gameObjects)
                {
                    var photonView = obj.GetComponent<PhotonView>();
                    if (photonView == null) continue;
                    BlazeAttack.PhotonUtils.FakeFlood(photonView.viewIdField, plId);
                }
                */
                return;
            }
            /*
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                GameObject gameObject = UserCameraController.Instance.userCameraIndicator.gameObject;
                gameObject.transform.position = new Vector3(float.NaN, float.NaN, float.NaN);
                gameObject.transform.localPosition = new Vector3(float.NaN, float.NaN, float.NaN);
                UserCameraController.Instance.mode = UserCameraMode.Photo;
                VRC.Network.RPC(VRC.SDKBase.VRC_EventHandler.VrcTargetType.All, gameObject, "PhotoCapture", new IntPtr[0]);
                for (int i = 0; i < 7; i++)
                    VRC.Network.RPC(VRC.SDKBase.VRC_EventHandler.VrcTargetType.All, gameObject, "TimerBloop", new IntPtr[0]);
                VRC.Network.RPC(VRC.SDKBase.VRC_EventHandler.VrcTargetType.All, gameObject, "PhotoCapture", new IntPtr[0]);
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                foreach (var x in UnityEngine.Object.FindObjectsOfType<VRC.Udon.UdonBehaviour>())
                {
                    //if (null != x.GetPrograms().FirstOrDefault(y => y == "_start"))
                    //    x.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "_start");
                    if (null != x.GetPrograms().FirstOrDefault(y => y == "_interact"))
                        VRC.Network.RPC(VRC.SDKBase.VRC_EventHandler.VrcTargetType.All, x.gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { new IL2String("_interact").ptr });
                    //if (null != x.GetPrograms().FirstOrDefault(y => y == "Play"))
                    //    x.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "Play");
                }
                // Notification.SendMessage(VRC.Player.Instance, "Test world");
            }

            */
            if (Input.GetKeyDown(KeyCode.P))
            {
                Cam3th.Toggle_Enable();
                return;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                MultiHack.Toggle_Enable_SpeedHack();
                return;
                // Vector3 vector = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
                // UserUtils.TeleportTo(vector);
            }
            if (Input.GetKeyDown(KeyCode.F))
                FlyMode.Toggle_Enable();

            if (Input.GetKeyDown(KeyCode.Mouse2))
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    UserUtils.TeleportTo(hit.point);
                
            if (Input.GetKeyDown(KeyCode.Mouse3))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    GameObject SelectColesion = hit.transform.gameObject;
                    if (SelectColesion != null)
                    {
                        ConSole.Message(SelectColesion.ToString() + " | " + SelectColesion.transform.position);
                        foreach(var comp in SelectColesion.GetComponents(typeof(Component)))
                            ConSole.Debug(comp.ToString().ToString());
                    }
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                UserUtils.RemoveInstiatorObjects();
                return;
            }

            if (Input.GetKey(KeyCode.T))
            {
                GameObject PortalGameObject = UserUtils.SpawnPortal(VRC.Player.Instance.transform);

                PortalInternal portalInternal = PortalGameObject?.GetComponent<PortalInternal>();
                if (portalInternal != null)
                {
                    portalInternal.SetTimerRPC(float.NegativeInfinity, VRC.Player.Instance);
                }
                return;
            }

        }
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static void GameObjects_scan()
        {
            gameObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        }

        public static GameObject[] gameObjects = new GameObject[0];

        private static bool bFirstThreadControl = false;
        
        public static bool bFirstThreadInRoom = false;

        public static string currentTime = "0";
        
        public static Random rand = new Random();
    }
}
