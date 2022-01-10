using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using BE4v.MenuEdit;
using BE4v.MenuEdit.IMGUI;
using BE4v.MenuOverlay;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Utils;
using UnityEngine;
using VRC;
using VRC.Animation;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using VRC.UI.Elements;

namespace BE4v.Mods
{
    public delegate void _Threads_Update(IntPtr instance);
    public static class Threads
    {
        public static void Start()
        {

            try
            {
                IL2Method method = InteractivePlayer.Instance_Class.GetMethod("Update");
                if (method == null)
                    throw new Exception("BE4V: Not found a thread (Update)");

                var patch = new IL2Patch(method, (_Threads_Update)Update);
                _delegateThreads_Update = patch.CreateDelegate<_Threads_Update>();
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
            TabMenu.Start();
        }

        public static void Update(IntPtr instance)
        {
            TabMenu.Update();

            _delegateThreads_Update.Invoke(instance);
            VRCPlayer player = VRCPlayer.Instance;
            if (player == null) return;
            Mod_InfinityJump.Update(player);
            if (Status.isFly)
                Mod_Fly.Update();
            if (Status.isSpeedHack)
                Mod_SpeedHack.Update();

            Mod_Invisible.Update();

            if (!isLoadedCharacter)
            {
                isLoadedCharacter = true;
                Application.targetFrameRate = 101;
            }
            if (!Input.GetKey(KeyCode.LeftControl)) return;
            if (!Status.is3thCam)
            {
                float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
                if (mouseWheel > 0.1)
                {
                    Camera.main.transform.localPosition += (Vector3.up * 0.1f);
                }
                else if (mouseWheel < -0.1)
                {
                    Camera.main.transform.localPosition -= (Vector3.up * 0.1f);
                }
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Mod_Fly.Toggle();
                return;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                Mod_SpeedHack.Toggle();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                    hit.collider.gameObject.SetActive(false);
                return;
            }
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                Mod_FastTP.Teleport();
                return;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Mod_CamMode.Toggle_Enable();
                UserUtils.SpawnPortal(VRCPlayer.Instance.transform, "wrld_26758d47-a511-441a-85d2-83d16936b1a0", "123456");
                return;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                Mod_Invisible.Toggle();
                return;
            }
        }

        private static bool isLoadedCharacter = false;

        private static _Threads_Update _delegateThreads_Update;
    }
}
