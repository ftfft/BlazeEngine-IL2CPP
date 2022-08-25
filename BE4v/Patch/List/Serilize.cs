using System;
using IL2CPP_Core.Objects;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;
using BE4v.Mods;
using BE4v.MenuEdit;
using BE4v.Patch.Core;
using UnityEngine;

namespace BE4v.Patch.List
{
    public class Serilize // : IPatch
    {
        public delegate bool _OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions);
        public static void Toggle()
        {
            Status.isSerilize = !Status.isSerilize;
            BE4V_MainMenu.Serilize.Refresh();
        }

        public void Start()
        {
            if (ClientDebug.IsEnableDebug())
            {
                IL2Method method = IL2Photon.Realtime.LoadBalancingClient.Instance_Class.GetMethod("OpRaiseEvent");
                if (method == null)
                    throw new NullReferenceException();

                __OpRaiseEvent = PatchUtils.FastPatch<_OpRaiseEvent>(method, OpRaiseEvent);
            }
        }


        public static bool OpRaiseEvent(IntPtr instance, byte operationCode, IntPtr operationParameters, IntPtr raiseEventOptions, SendOptions sendOptions)
        {
            /*
            if (operationCode == 7 && Mods.Min.ClientConsole.isTest)
            {
                IL2Array<byte> bytes = new IL2Array<byte>(operationParameters);
                if (bytes != null && bytes.Length > 60)
                {
                    byte[] array = new byte[12];
                    byte[] nan = BitConverter.GetBytes(float.NaN);
                    Buffer.BlockCopy(nan, 0, array, 0, 4);
                    Buffer.BlockCopy(nan, 0, array, 4, 4);
                    Buffer.BlockCopy(nan, 0, array, 8, 4);
                    for(int i=0;i<12;i++)
                    {
                        bytes[i + 48] = array[i];
                    }
                }
            }
            */
            /*
            (operationCode + "").RedPrefix("TTT");
            if (operationParameters == IntPtr.Zero)
            {
                "operationParameters == null".RedPrefix("TTT");
            }
            else
            {
                byte[] bytes = new IL2Array<byte>(operationParameters).GetAsByteArray();
                if (bytes.Length > 0)
                {
                    ("operationParameters: [" + BitConverter.ToString(bytes) + "]").RedPrefix("TTT");
                    ("operationParameters (Base64): [" + Convert.ToBase64String(bytes) + "]").RedPrefix("TTT");
                }
                else
                {
                    "operationParameters byte[] == 0".RedPrefix("TTT");
                }
            }
            */
            if (Mods.Min.ClientConsole.isLog)
            {
                byte[] array = null;
                if (operationParameters != IntPtr.Zero)
                {
                    array = new IL2Array<byte>(operationParameters).GetAsByteArray();
                }
                $"Event Code: {operationCode} by len: {(array?.Length??-1)} |".RedPrefix("Logger");
            }

            if (Status.isSerilize)
            {
                if (operationCode != 1
                && operationCode != 6
                && operationCode != 66
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
                return __OpRaiseEvent(instance, operationCode, operationParameters, raiseEventOptions, sendOptions);
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                ("Instance == " + instance).RedPrefix("Debug");
                ("operationCode == " + operationCode).RedPrefix("Debug");
                ("operationParameters == " + operationParameters).RedPrefix("Debug");

                if (operationParameters != IntPtr.Zero)
                {
                    byte[] array = null;
                    array = new IL2Array<byte>(operationParameters).GetAsByteArray();
                    ("array[] len: == " + array).RedPrefix("Debug");
                }
                ("raiseEventOptions == " + raiseEventOptions).RedPrefix("Debug");
                ("sendOptions[]").RedPrefix("Debug");
                ("- Channel" + sendOptions.Channel).RedPrefix("Debug");
                ("- DeliveryMode" + sendOptions.DeliveryMode).RedPrefix("Debug");
                ("- Encrypt" + sendOptions.Encrypt).RedPrefix("Debug");
                
                return false;
            }
        }

        public static _OpRaiseEvent __OpRaiseEvent;
    }
}
