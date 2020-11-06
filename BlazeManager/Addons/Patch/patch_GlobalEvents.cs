using System;
using System.Linq;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using VRC.SDKBase;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent(IntPtr instance, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, IntPtr instagatorId, IntPtr fastForward);
    public static class patch_GlobalEvents
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Global Events", !BlazeManager.GetForPlayer<bool>("Global Events"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Global Events");
            BlazeManagerMenu.Main.togglerList["Global Events"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Global Events"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = VRC.SDKBase.VRC_EventHandler.Instance_Class.GetMethod("InternalTriggerEvent");
                if (method == null)
                    throw new Exception();

                pGlobalEvents = IL2Ch.Patch(method, (_VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent)VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent);
                ConSole.Success("Patch: Global Events");
            }
            catch
            {
                ConSole.Error("Patch: Global Events");
            }
        }

        public static void VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent(IntPtr instance, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, IntPtr instagatorId, IntPtr fastForward)
        {
            if (BlazeManager.GetForPlayer<bool>("Global Events"))
                broadcast = VRC_EventHandler.VrcBroadcastType.Always;

            pGlobalEvents.InvokeOriginal(instance, new IntPtr[] { e, new IntPtr((int)broadcast), instagatorId, fastForward });
        }

        public static IL2Patch pGlobalEvents;
    }
}
