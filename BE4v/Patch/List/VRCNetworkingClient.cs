using System;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class VRCNetworkingClient : IPatch
    {
        public delegate void _VRCNetworkingClient_OnEvent(IntPtr instance, IntPtr pEventData);
        public void Start()
        {
            IL2Method method = VRC.Core.VRCNetworkingClient.Instance_Class.GetMethod("OnEvent");
            if (method != null)
            {
                _OnEvent = PatchUtils.FastPatch<_VRCNetworkingClient_OnEvent>(method, VRCNetworkingClient_OnEvent);
            }
            else
                throw new NullReferenceException();
        }

        public static void VRCNetworkingClient_OnEvent(IntPtr instance, IntPtr pEventData)
        {
            if (NetworkSanity.NetworkSanity.VRCNetworkingClient.OnEvent(pEventData))
                _OnEvent(instance, pEventData);
        }

        public static _VRCNetworkingClient_OnEvent _OnEvent;
    }
}