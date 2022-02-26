﻿using System;
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
