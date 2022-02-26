using System;
using System.Linq;
using VRC;
using VRC.Udon;
using UnityEngine;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;

namespace BE4v.Patch
{
    public delegate void _SendCustomEvent(IntPtr instance, IntPtr eventName);
    public delegate void _UdonSyncRunProgramAsRPC(IntPtr eventName, IntPtr instigator);
    public static class Patch_GlobalUdonEvents
    {
        public static void Start()
        {
            try
            {
                IL2Method method = UdonBehaviour.Instance_Class.GetMethod("SendCustomEvent");
                patch[0] = new IL2Patch(method, (_SendCustomEvent)SendCustomEvent);
                _delegateSendCustomEvent = patch[0].CreateDelegate<_SendCustomEvent>();
                "Global Udon Events [1]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Global Udon Events [1]".RedPrefix(TMessage.BadPatch);
            }

            try
            {
                IL2Method method = VRC.Networking.UdonSync.Instance_Class.GetMethod("UdonSyncRunProgramAsRPC");
                patch[1] = new IL2Patch(method, (_UdonSyncRunProgramAsRPC)UdonSyncRunProgramAsRPC);
                "Global Udon Events [2]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Global Udon Events [2]".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void SendCustomEvent(IntPtr instance, IntPtr eventName)
        {
            if (instance == IntPtr.Zero || eventName == IntPtr.Zero) return;
            UdonBehaviour udon = new UdonBehaviour(instance);
            string nameEvent = new IL2String(eventName).ToString();
            GameObject gameObject = udon.gameObject;
            if (gameObject != null)
            {
                Network.RPC(VRC_EventHandler.VrcTargetType.All, gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { eventName });
            }
            try
            {
                _delegateSendCustomEvent(instance, eventName);
            }
            catch { }
        }
        
        public static void UdonSyncRunProgramAsRPC(IntPtr instance, IntPtr eventName)
        {
        }

        public static IL2Patch[] patch = new IL2Patch[2];

        public static _SendCustomEvent _delegateSendCustomEvent = null;
    }
}
