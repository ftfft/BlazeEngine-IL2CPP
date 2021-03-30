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
            BlazeManagerMenu.Main.togglerList["Global Events"].SetToggleToOn(toggle, false);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = VRC.SDKBase.VRC_EventHandler.Instance_Class.GetMethod("InternalTriggerEvent");
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent)VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent);
                _delegateVRC_SDKBase_VRC_EventHandler_InternalTriggerEvent = patch.CreateDelegate<_VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent>();
                Dll_Loader.success_Patch.Add("Global Events");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("Global Events");
            }
        }

        public static void VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent(IntPtr instance, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, IntPtr instagatorId, IntPtr fastForward)
        {
            if (BlazeManager.GetForPlayer<bool>("Global Events"))
                broadcast = VRC_EventHandler.VrcBroadcastType.Always;

            _delegateVRC_SDKBase_VRC_EventHandler_InternalTriggerEvent.Invoke(instance, e, broadcast, instagatorId, fastForward);
        }

        public static _VRC_SDKBase_VRC_EventHandler_InternalTriggerEvent _delegateVRC_SDKBase_VRC_EventHandler_InternalTriggerEvent;
    }
}
