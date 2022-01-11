using System;
using System.Linq;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;

namespace BE4v.Patch
{
    // public delegate void TriggerEvent(VRC_EventHandler handler, VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
    public delegate void _TriggerEvent(IntPtr instance, IntPtr handler, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward);
    public static class Patch_EventLogger
    {
        public static void Start()
        {

            try
            {
                IL2Method method = VRC_EventDispatcherRFC.Instance_Class.GetMethod("TriggerEvent");
                patch = new IL2Patch(method, (_TriggerEvent)TriggerEvent);
                _delegateTriggerEvent = patch.CreateDelegate<_TriggerEvent>();
                "Event Logger".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Event Logger".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void TriggerEvent(IntPtr instance, IntPtr handler, IntPtr e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
        {
            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent(e);
            
            if (Status.isRPCLogger)
            {
                Console.WriteLine($"=== [RPC by {instagatorId}] ===");
                Console.WriteLine($"* Broadcast: " + broadcast);
                Console.WriteLine($"* TargetType: " + (VRC_EventHandler.VrcTargetType)vrcEvent.ParameterInt);
                Console.WriteLine($"* GameObject: " + vrcEvent.ParameterObject.name);
                Console.WriteLine($"* RPC Message: " + vrcEvent.ParameterString);
            }
            try
            {
                _delegateTriggerEvent.Invoke(instance, handler, e, broadcast, instagatorId, fastForward);
            }
            catch { }
        }

        public static IL2Patch patch;

        public static _TriggerEvent _delegateTriggerEvent = null;
    }
}
