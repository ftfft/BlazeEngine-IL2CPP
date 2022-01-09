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
            if (instance == IntPtr.Zero) return;
            EventData eventData = new EventData(pEventData);
            if (eventData == null) return;
            if (userList.Contains(eventData.Sender) || !isValidData(eventData)) return;
            int eventCode = eventData.Code;
            
            switch (eventCode)
            {
                case 6:
                    {
                        if (Status.isRPCBlock && VRC.Player.Instance?.PhotonPlayer?.ActorNumber != eventData.Sender)
                            return;

                        break;
                    }
                case EventCode.Join:
                    {
                        if (BE4V_ModeMenu.DeathMap.isEnabled)
                            return;

                        break;
                    }
                
            }

            try
            {
                _delegateLoadBalancingClient_OnEvent.Invoke(instance, pEventData);
            }
            catch { }
        }

        public static bool isValidData(EventData eventData)
        {
            // Thanks Nemox
            if (eventData.Sender == 0) return true;
            int eventCode = eventData.Code;
            int maxLength;
            switch (eventCode)
            {
                case 1:
                    {
                        maxLength = 960;
                        break;
                    }
                case 4:
                    {
                        maxLength = 32;
                        break;
                    }
                case 6:
                    {
                        maxLength = 128;
                        break;
                    }
                case 7:
                    {
                        maxLength = 224;
                        break;
                    }
                case 9:
                    {
                        maxLength = 256;
                        break;
                    }
                case 210:
                    {
                        maxLength = 8;
                        break;
                    }
                default:
                    {
                        maxLength = 200;
                        break;
                    }
            }
            uint len;
            IL2Object customData = eventData.CustomData;
            if (customData != null)
            {
                len = Import.Object.il2cpp_array_get_byte_length(customData.ptr);
                if (len > maxLength)
                {
                    if (eventCode != 1)
                        userList.Add(eventData.Sender);
                    ($"User {eventData.Sender} is blocked by packet #{eventData.Code} (Size of {len})").RedPrefix("Packet block");
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
