using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;
using BE4v.Mods;
using BE4v.MenuEdit;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class Serilize : IPatch
    {
        public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
        public static void Toggle()
        {
            Status.isSerilize = !Status.isSerilize;
            BE4V_MainMenu.Serilize.Refresh();
        }

        public void Start()
        {
            IL2Method method = null;
            (method = IL2Photon.Realtime.LoadBalancingClient.Instance_Class?.GetMethod(x => x.IsPublic && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName)).Name = "OpRaiseEvent";
            if (method != null)
            {
                patch = new IL2Patch(method, (_OpRaiseEvent)OpRaiseEvent);
                _delegateOpRaiseEvent = patch.CreateDelegate<_OpRaiseEvent>();
            }
            else
                throw new NullReferenceException();
        }


        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
        {
            if (BE4v.Mods.Min.ClientConsole.isLog)
            {
                byte[] array = null;
                if (operationParameters != IntPtr.Zero)
                {
                    array = new IL2Array<byte>(operationParameters).ToBytesArray();
                }
                $"Event Code: {operationCode} by len: {(array?.Length??-1)} |".RedPrefix("Logger");
            }

            if (operationCode == 189) return true;
            if (Status.isSerilize)
            {
                if (operationCode != 1
                && operationCode != 6
                && operationCode != EventCode.Join
                && operationCode != EventCode.Leave
                )
                {
                    return true;
                }
            }
            /*
            if (Mod_Console.crashToggle)
            {
                if (operationCode == 6)
                {
                    IL2Array<byte> array = new IL2Array<byte>(operationParameters);
                    int len = array.Length;
                    int ifCount = 0;
                    short sh = 0;
                    for (int i = len - 1; i <= 0; i--)
                    {
                        if (array[i] == 4)
                        {
                            if (i + 5 < len)
                            {
                                // 80, 108, 97, 121
                                if (
                                    array[i + 2] == 80
                                && array[i + 3] == 108
                                && array[i + 4] == 97
                                && array[i + 5] == 121
                                )
                                {
                                    byte[] bytes = new byte[2];
                                    sh = 80;
                                    bytes = BitConverter.GetBytes(sh);

                                    array[i] = bytes[0];
                                    array[i + 1] = bytes[1];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            */
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
