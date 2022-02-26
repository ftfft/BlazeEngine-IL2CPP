using System;
using System.Collections.Generic;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;
using BE4v.MenuEdit.IMGUI;
using VRC;

namespace BE4v.Patch
{
    public delegate void _LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData);
    public static class Patch_Event_OnEvent
    {
        public static void Start()
        {
            try
            {
                IL2Method method = LoadBalancingClient.Instance_Class.GetMethod("OnEvent");
                patch = new IL2Patch(method, (_LoadBalancingClient_OnEvent)LoadBalancingClient_OnEvent);
                _delegateLoadBalancingClient_OnEvent = patch.CreateDelegate<_LoadBalancingClient_OnEvent>();
                "[Event] OnEvent (Patch)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "[Event] OnEvent (Patch)".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (instance == IntPtr.Zero || pEventData == IntPtr.Zero) return;
            try
            {
                if (isValidData(new EventData(pEventData)))
                    _delegateLoadBalancingClient_OnEvent(instance, pEventData);
            }
            catch { }
        }

        public static Dictionary<int, uint> LenEvent = new Dictionary<int, uint>();

        public static bool isValidData(EventData eventData)
        {
            int sender = eventData.Sender;
            if (sender < 1) return true;
            int eventCode = eventData.Code;
            if (eventCode == EventCode.Leave)
            {
                if (userList.Contains(sender))
                    userList.Remove(sender);
                return true;
            }
            if (userList.Contains(sender)) return false;
            if (eventCode == 7) return true;
            IL2Object customData = eventData.CustomData;
            int len = 0;
            int maxLength = 0;
            if (Status.isRPCBlock)
            {
                if (eventCode == 6)
                    return false;
            }
            if (BE4V_ModeMenu.DeathMap.isEnabled)
            {
                if (eventCode == EventCode.Join)
                    return false;
            }
            if (customData != null)
            {
                len = Convert.ToInt32(Import.Object.il2cpp_array_get_byte_length(customData.ptr));
            }
            if (Mod_Console.isLog)
            {
                if (eventCode != 1)
                {
                    ($"User {sender} sended packet {eventCode} (Size of {len})").RedPrefix("Packet Tracer");
                    if (Mod_Console.isLogDetail)
                    {
                        if (len > 0)
                        {
                            string stringBytes = string.Empty;
                            IL2Array<byte> bytes = new IL2Array<byte>(customData.ptr);
                            for (int i = 0; i < len; i++)
                            {
                                if (!string.IsNullOrEmpty(stringBytes))
                                    stringBytes += "-";
                                stringBytes += bytes[i];
                            }
                            ("[" + stringBytes + "]").RedPrefix("Packet Tracer");
                        }
                    }
                }
            }
            if (len > 0)
            {
                switch (eventCode)
                {
                    case 1:
                        {
                            maxLength = 1050;
                            break;
                        }
                    case 4:
                        {
                            maxLength = 512;
                            break;
                        }
                    case 6:
                        {
                            maxLength = 256;
                            break;
                        }
                    case 9:
                        {
                            maxLength = 201;
                            break;
                        }
                    case PunEvent.OwnershipRequest:
                        {
                            maxLength = 8;
                            break;
                        }
                    case PunEvent.OwnershipTransfer:
                        {
                            maxLength = 8;
                            break;
                        }
                }
                if (maxLength == 0) return false;
                IL2Array<byte> bytes = new IL2Array<byte>(customData.ptr);
                if (len > 4)
                {
                    if (bytes[len - 1] == 0 && bytes[len - 2] == 0 && bytes[len - 3] == 0 && bytes[len - 4] == 0)
                        return false;
                    if (eventCode == 9)
                    {
                        if (len > 200)
                        {
                            if (Mod_Console.isLog)
                            {
                                byte[] bytesArray = new byte[len];
                                for(int i=0;i<len;i++)
                                {
                                    bytesArray[i] = bytes[i];
                                }
                                System.IO.File.WriteAllBytes("testBytes", bytesArray);
                            }
                            return false;
                        }
                    }
                }

                if (len > maxLength)
                {
                    if (eventCode != 1)
                        userList.Add(sender);
                    ($"User {sender} is blocked by packet #{eventCode} (Size of {len})").RedPrefix("Packet block");
                    return false;
                }
            }
            return true;
        }

        public static List<int> userList = new List<int>();

        public static IL2Patch patch;

        public static _LoadBalancingClient_OnEvent _delegateLoadBalancingClient_OnEvent;
    }
}
