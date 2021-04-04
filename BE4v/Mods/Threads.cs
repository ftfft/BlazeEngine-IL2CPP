using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (Status.isFly)
                Mod_Fly.Update();

            _delegateThreads_Update.Invoke(instance);

            if (!Input.GetKey(KeyCode.LeftControl)) return;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Status.isFly = !Status.isFly;
                Physics.gravity = Vector3.up * -9.5f;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
            }

        }


        public static _Threads_Update _delegateThreads_Update;
    }
}
