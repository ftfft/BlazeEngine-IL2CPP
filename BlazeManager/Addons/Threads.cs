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
using Photon.Pun.UtilityScripts;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;

namespace Addons
{
    public delegate void _Control_Thread_Update(IntPtr instance);
    public delegate void _Control_Thread_GUI(IntPtr instance);
    public delegate void _Nulled(IntPtr instance);
    public delegate void _udonSync(IntPtr instance, IntPtr ptrString, IntPtr ptrPlayer);
    public delegate IntPtr _Nulled2(IntPtr instance);
    public static class Threads
    {
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
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("InteractivePlayer").GetMethod("Update");
                if (method == null)
                    throw new Exception();

                update = IL2Ch.Patch(method, (_Control_Thread_Update)Control_Thread_Update);
                if (update == null)
                    throw new Exception();
            }
            catch
            {
                ConSole.Debug("Patch: Engine threading");
            }
        }

        public static void Nulled(IntPtr instance) { }
        public static IntPtr Nulled2(IntPtr instance) { return IntPtr.Zero; }


        private static IL2Patch pUdonSync = null;
        public static void udonSync(IntPtr instance, IntPtr ptrString, IntPtr ptrPlayer)
        {
            Console.WriteLine(IL2Import.IntPtrToString(ptrString));
            pUdonSync.InvokeOriginal(instance, new IntPtr[] { ptrString, ptrPlayer });
        }

        public static void Control_Thread_GUI(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            if (Input.GetKey(KeyCode.Tab))
            {
                if (VRC.Player.Instance != null)
                    Mods.UI.TabMenu.ShowMenu();
                return;
            }
        }


        private static GameObject gameObjectOOO = null;

        private static IL2Patch update = null;
        public static void Control_Thread_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            if (Input.GetKey(KeyCode.Home))
            {
                BlazeAttack.PhotonUtils.raise209_status = true;
                BlazeAttack.PhotonUtils.Raise200();
                return;
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

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    GameObject SelectColesion = hit.transform.gameObject;
                    if (SelectColesion != null)
                    {
                        if (SelectColesion.GetComponent<VRC_Pickup>() != null || SelectColesion.GetComponent<VRC.SDK3.Components.VRCPickup>() != null)
                        {
                            PhotonNetwork.TransferOwnership(SelectColesion.GetComponent<Photon.Pun.PhotonView>().viewIdField, VRC.Player.Instance.photonPlayer.ID);
                            PhotonNetwork.RequestOwnership(SelectColesion.GetComponent<Photon.Pun.PhotonView>().viewIdField, VRC.Player.Instance.photonPlayer.ID);
                            SelectColesion.transform.position = new Vector3(float.NaN, float.NaN, float.NaN);
                        }
                    }
                }
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

            BlazeAttack.PhotonUtils.raise209_status = false;

            if (Cam3th._isEnable)
                Cam3th.Update();

            update.InvokeOriginal(instance);

            if (Cam3th._isEnable)
                Cam3th.LateUpdate();

            if (!bFirstThreadControl)
            {
                bFirstThreadControl = true;
                Application.targetFrameRate = 101;
                BlazeManagerMenu.Main.CreateMenu();
                BlazeManagerMenu.Edit_UserPanel.Start();
                return;
            }
            
            if (!bFirstThreadInRoom)
            {
                bFirstThreadInRoom = true;
                NoLocalPickup.ClearObjects();
                NoLocalPickup.Update();
                patch_Network.playerInfo.Clear();
                patch_ForceMute.forceMuteList.Clear();
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (gameObject != null)
                {
                    gameObject.GetComponent<MeshFilter>()?.Destroy();
                    gameObject.GetComponent<BoxCollider>()?.Destroy();
                    gameObject.GetComponent<MeshRenderer>()?.Destroy();
                    gameObject.GetOrAddComponent<PhotonLagSimulationGui>();
                }
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
            /*
            if (Input.GetKey(KeyCode.Y))
            {
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
                return;
            }
            */
            if (Input.GetKeyDown(KeyCode.End))
            {
                foreach (var x in UnityEngine.Object.FindObjectsOfType<VRC.Udon.UdonBehaviour>())
                {
                    //Console.WriteLine("------- [ " + x.gameObject.ToString());
                    //foreach(var z in x.GetPrograms())
                    //    Console.WriteLine(z);

                    x.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "_interact");
                }
                // Notification.SendMessage(VRC.Player.Instance, "Test world");
            }
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
                            ConSole.Debug(comp.ToString());
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
