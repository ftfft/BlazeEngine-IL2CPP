using System;
using System.Reflection;
using System.Linq;
using System.Text;
using BlazeTools;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine;
using Addons.Utils;

namespace Addons.Patch
{
    public delegate void _PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider);
    public delegate void _PortalInternal_ConfigurePortal(IntPtr instance, IntPtr _roomId, IntPtr _idWithTags, int _playerCount, IntPtr instigator);
    public static class patch_NoPortal
    {
        public static void Toggle_Enable_Join()
        {
            BlazeManager.SetForPlayer("No Portal Join", !BlazeManager.GetForPlayer<bool>("No Portal Join"));
            RefreshStatusJoin();
        }
        public static void Toggle_Enable_Spawn()
        {
            BlazeManager.SetForPlayer("No Portal Spawn", !BlazeManager.GetForPlayer<bool>("No Portal Spawn"));
            RefreshStatusSpawn();
        }

        public static void RefreshStatusJoin()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("No Portal Join");
            BlazeManagerMenu.Main.togglerList["No Portal Join"].SetToggleToOn(toggle, false);
        }

        public static void RefreshStatusSpawn()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("No Portal Spawn");
            BlazeManagerMenu.Main.togglerList["No Portal Spawn"].SetToggleToOn(toggle, false);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = PortalTrigger.Instance_Class.GetMethod("OnTriggerEnter");
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_PortalTrigger_OnTriggerEnter)PortalTrigger_OnTriggerEnter);
                _delegatePortalTrigger_OnTriggerEnter = patch.CreateDelegate<_PortalTrigger_OnTriggerEnter>();
                Dll_Loader.success_Patch.Add("No Portal Join");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("No Portal Join");
            }
            try
            {
                IL2Method method = PortalInternal.Instance_Class.GetMethod("ConfigurePortal");
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_PortalInternal_ConfigurePortal)PortalInternal_ConfigurePortal);
                _delegatePortalInternal_ConfigurePortal = patch.CreateDelegate<_PortalInternal_ConfigurePortal>();
                Dll_Loader.success_Patch.Add("PortalNoCollider");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("PortalNoCollider");
            }
        }

        public static void PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider)
        {
            if (instance == IntPtr.Zero)
                return;

            if (BlazeManager.GetForPlayer<bool>("No Portal Join"))
                return;

            _delegatePortalTrigger_OnTriggerEnter.Invoke(instance, collider);
        }

        public static _PortalTrigger_OnTriggerEnter _delegatePortalTrigger_OnTriggerEnter;

        private static void PortalInternal_ConfigurePortal(IntPtr instance, IntPtr _roomId, IntPtr _idWithTags, int _playerCount, IntPtr instigator)
        {
            PortalInternal portalInternal = new PortalInternal(instance);
            if (portalInternal?.transform == null || instigator == IntPtr.Zero) return;
            if (BlazeManager.GetForPlayer<bool>("No Portal Spawn"))
            {
                portalInternal.gameObject?.Destroy();
                return;
            }
            try
            {
                _delegatePortalInternal_ConfigurePortal(instance, _roomId, _idWithTags, _playerCount, instigator);
            }
            catch { }
        }

        public static _PortalInternal_ConfigurePortal _delegatePortalInternal_ConfigurePortal;

    }
}
