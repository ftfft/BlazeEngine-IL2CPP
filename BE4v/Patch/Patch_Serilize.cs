using System;
using System.Collections;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Realtime;
using BE4v.Mods;
using IL2ExitGames.Client.Photon;
using BE4v.MenuEdit;
using VRC.SDKBase;

namespace BE4v.Patch
{
    public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
    // public delegate void _TriggerEvent(IntPtr instance, IntPtr e, IntPtr ev, VRC_EventHandler.VrcBroadcastType type, int i, float f);
    public delegate void _TriggerEventNew(IntPtr instance, IntPtr vrcPlayer, IntPtr ev, VRC_EventHandler.VrcBroadcastType type, int i, float f);
    public static class Patch_Serilize
    {
        public static void Toggle()
        {
            Status.isSerilize = !Status.isSerilize;
            BE4V_MainMenu.Serilize.Refresh();
        }

        public static void Start()
        {
            try
            {
                IL2Method method = null;
                (method = LoadBalancingClient.Instance_Class?.GetMethod(x => x.IsPublic && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName)).Name = "OpRaiseEvent";
                if (method == null)
                    new Exception();

                patch = new IL2Patch(method, (_OpRaiseEvent)OpRaiseEvent);
                _delegateOpRaiseEvent = patch.CreateDelegate<_OpRaiseEvent>();
                "Serilize".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Serilize".RedPrefix(TMessage.BadPatch);
            }
            try
            {
                IL2Method method = null;
                method = VRC_EventDispatcherRFC.Instance_Class.GetMethod(x => 
                    x.ReturnType.Name == typeof(void).FullName
                    && x.GetParameters().Length == 5
                    && x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName
                );
                if (method == null)
                    new Exception();

                patch2 = new IL2Patch(method, (_TriggerEventNew)TriggerEvent);
                _delegateTriggerEvent = patch2.CreateDelegate<_TriggerEventNew>();
                "ByteCrash".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "ByteCrash".RedPrefix(TMessage.BadPatch);
                ex.Message.RedPrefix("Ex:");
            }
        }


        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
        {
            if (Status.isSerilize)
            {
                if (operationCode != 1 && operationCode != EventCode.Join && operationCode != EventCode.Leave)
                {
                    return true;
                }
            }
            try
            {
                return _delegateOpRaiseEvent(instance, operationCode, operationParameters, raiseEventOptions, sendOptions);
            }
            catch { return false; }
        }

        public static void TriggerEvent(IntPtr instance, IntPtr vrcPlayer, IntPtr ev, VRC_EventHandler.VrcBroadcastType type, int i, float f)
        {
            if (Status.isRPCInject)
            {
                return;
            }
            try
            {
                _delegateTriggerEvent(instance, vrcPlayer, ev, type, i, f);
            }
            catch { }
        }
        

        public static IL2Patch patch;

        public static IL2Patch patch2;

        public static _OpRaiseEvent _delegateOpRaiseEvent;

        public static _TriggerEventNew _delegateTriggerEvent;
    }
}
