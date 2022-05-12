using System;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class LoadBalancingClient : IPatch
    {
        public delegate void _LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData);
        public void Start()
        {
            IL2Method method = IL2Photon.Realtime.LoadBalancingClient.Instance_Class.GetMethod("OnEvent");
            if (method != null)
            {
                _OnEvent = PatchUtils.FastPatch<_LoadBalancingClient_OnEvent>(method, LoadBalancingClient_OnEvent);
            }
            else
                throw new NullReferenceException();
        }

        public static void LoadBalancingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (NetworkSanity.NetworkSanity.LoadBalancingClient.OnEvent(pEventData))
                _OnEvent(instance, pEventData);
        }
        
        public static _LoadBalancingClient_OnEvent _OnEvent;
    }
}
