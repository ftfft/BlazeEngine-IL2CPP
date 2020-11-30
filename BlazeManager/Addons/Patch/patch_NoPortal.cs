using System;
using System.Reflection;
using System.Linq;
using System.Text;
using BlazeTools;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;

namespace Addons.Patch
{
    public delegate void _PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider);
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
                ConSole.Success("Patch: No Portal Join");
            }
            catch
            {
                ConSole.Error("Patch: No Portal Join");
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

    }
}
