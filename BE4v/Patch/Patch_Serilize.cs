using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Realtime;
using BE4v.Mods;
using IL2ExitGames.Client.Photon;
using BE4v.MenuEdit;

namespace BE4v.Patch
{
    public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
    public static class Patch_Serilize
    {
        public static void Toggle()
        {
            Status.isSerilize = !Status.isSerilize;
            ClickClass_Serilize.OnClick_SerilizeToggle_Refresh();
        }

        public static void Start()
        {
            try
            {
                IL2Method method = null;
                (method = LoadBalancingClient.Instance_Class?.GetMethod(x => x.IsPublic && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName)).Name = "OpRaiseEvent";
                if (method == null)
                    new Exception();

                IL2Patch patch = new IL2Patch(method, (_OpRaiseEvent)OpRaiseEvent);
                _delegateOpRaiseEvent = patch.CreateDelegate<_OpRaiseEvent>();
                "Serilize".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Serilize".RedPrefix(TMessage.BadPatch);
            }
        }


        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
        {
            if (Status.isSerilize)
            {
                if (operationCode != 1)
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

        public static _OpRaiseEvent _delegateOpRaiseEvent;
    }
}
