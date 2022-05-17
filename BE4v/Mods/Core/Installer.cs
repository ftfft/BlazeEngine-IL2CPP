using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;

namespace BE4v.Mods.Core
{
    public delegate void _InteractivePlayer_Update(IntPtr instance);
    public delegate void _OVRLipSyncMicInput_OnGUI(IntPtr instance);
    public delegate void _OVRLipSyncMicInput_0x6001E6C(IntPtr instance);
    public static class Installer
    {
        public static _InteractivePlayer_Update _delegateInteractivePlayer_Update;
        public static _OVRLipSyncMicInput_OnGUI _delegateOVRLipSyncMicInput_OnGUI;

        private static T1[] LoadInterfaces<T1>() where T1 : IThread
        {
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            List<T1> list = new List<T1>();
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(T1).IsAssignableFrom(t))
                    continue;

                var sanitizer = (T1)Activator.CreateInstance(t);
                list.Add(sanitizer);
                $"Load Functions: {t.Name}".GreenPrefix(typeof(T1).Name);
            }
            return list.ToArray();
        }

        public static void Start()
        {
            try
            {
                IL2Method method = InteractivePlayer.Instance_Class.GetMethod("Update");
                if (method != null)
                {
                    updates = LoadInterfaces<IUpdate>();
                    _delegateInteractivePlayer_Update = PatchUtils.FastPatch<_InteractivePlayer_Update>(method, Update);
                }
                else
                    $"Installer: Method Update not found!".RedPrefix("Patch");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
            // ---
            try
            {
                IL2Method method = OVRLipSyncMicInput.Instance_Class.GetMethod("OnGUI");
                if (method != null)
                {
                    onGUIs = LoadInterfaces<IOnGUI>();
                    _delegateOVRLipSyncMicInput_OnGUI = PatchUtils.FastPatch<_OVRLipSyncMicInput_OnGUI>(method, OnGUI);
                }
                else
                    $"Installer: Method OnGUI not found!".RedPrefix("Patch");
            }
            catch (Exception ex)
            {
                ex.ToString().WriteMessage("Patch");
            }
        }

        private static IUpdate[] updates = new IUpdate[0];
        public static void Update(IntPtr instance)
        {
            Threads.isCtrl = Input.GetKey(KeyCode.LeftControl);
            try
            {
                foreach (var i in updates)
                {
                    i.Update();
                }
            }
            finally
            {
                _delegateInteractivePlayer_Update(instance);
            }
        }

        public static void Nulled(IntPtr instance) { }

        private static IOnGUI[] onGUIs = new IOnGUI[0];
        public static void OnGUI(IntPtr instance)
        {
            try
            {
                foreach (var i in onGUIs)
                {
                    i.OnGUI();
                }
            }
            finally
            {
                _delegateOVRLipSyncMicInput_OnGUI(instance);
            }
        }
    }
}
