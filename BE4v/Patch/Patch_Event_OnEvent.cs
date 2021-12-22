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
            /*
            switch (eventData.Code)
            {
                case 1:
                    {
                        //if (player.IsMuted)
                        //    return;
                        break;
                        //break;
                    }
                case EventCode.SetProperties:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case EventCode.Leave:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case 6:
                    {

                        if (Status.isRPCBlock && VRC.Player.Instance?.PhotonPlayer?.ActorNumber != eventData.Sender)
                            return;

                        break;
                    }
                    */
                /*
                case 7:
                    {
                        if (isSelf)
                            return;
                        if ((BlazeManager.GetForPlayer<bool>("NoMove")))
                            return;

                        break;
                    }
                case PunEvent.OwnershipRequest:
                    {
                        if (!isSelf && (BlazeManager.GetForPlayer<bool>("Hide Pickup")))
                            return;

                        break;
                    }
                case PunEvent.OwnershipTransfer:
                    {
                        if (!isSelf && (BlazeManager.GetForPlayer<bool>("Hide Pickup")))
                            return;

                        break;
                    }
                case EventCode.SetProperties:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case EventCode.Leave:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        break;
                    }
                case EventCode.Join:
                    {
                        TabMenu.players = PlayerManager.Instance.PlayersCopy;
                        if (BlazeManager.GetForPlayer<bool>("DeathMap"))
                            return;

                        break;
                    }
                    */
            // }
            
            try
            {
                if (!userList.Contains(eventData.Sender))
                    _delegateLoadBalancingClient_OnEvent.Invoke(instance, pEventData);
            }
            catch { }
        }

        public static List<int> userList = new List<int>();

        public static IL2Patch patch;

        public static _LoadBalancingClient_OnEvent _delegateLoadBalancingClient_OnEvent;
    }
}
