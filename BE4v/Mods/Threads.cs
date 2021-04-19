﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BE4v.MenuEdit;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using UnityEngine;

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
                if (_delegateThreads_Update == null)
                    throw new Exception("BE4V: Not found a delegate (Update)");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
        }

        public static void Update(IntPtr instance)
        {
            if (Status.isInfinityJump)
                Mod_InfinityJump.Update();
            if (Status.isFly)
                Mod_Fly.Update();
            if (Status.isSpeedHack)
                Mod_SpeedHack.Update();

            _delegateThreads_Update.Invoke(instance);


            if (isFirstControl > 0)
            {
                if (--isFirstControl == 0)
                {
                    Application.targetFrameRate = 101;
                    BE4V_MainMenu.Delete();
                    BE4V_MainMenu.Start();
                }
                return;
            }

            if (!Input.GetKey(KeyCode.LeftControl)) return;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Mod_Fly.Toggle();
            }
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                Mod_FastTP.Teleport();
            }
            // FileDebug.debugGameObject("test.txt", QuickMenu.Instance.gameObject);
            if (Input.GetKeyDown(KeyCode.G))
            {
                Mod_SpeedHack.Toggle();
            }

        }

        private static int isFirstControl = 50;

        private static _Threads_Update _delegateThreads_Update;
    }
}
