using System;
using System.Collections;
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
        }


        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
    {
            if (operationParameters != IntPtr.Zero)
            {
                if (operationCode == 6)
                {
                    try
                    {
                        Console.WriteLine("ByteCode: " + operationCode);
                        Console.WriteLine("Type Param: " + new IL2ObjectSystem(operationParameters).ToString() + " (Len: " + Import.Object.il2cpp_array_get_byte_length(operationParameters) + ")");
                        byte[] bytes = new IL2Object(operationParameters).UnboxArraу<byte>();
                        Console.WriteLine("str: " + System.Text.Encoding.UTF8.GetString(bytes));
                    }
                    catch { }
                }
            }
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

        public static IL2Patch patch;

        public static _OpRaiseEvent _delegateOpRaiseEvent;
    }
}
