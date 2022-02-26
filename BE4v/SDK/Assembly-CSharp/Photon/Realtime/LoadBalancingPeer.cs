using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE4v.SDK.CPP2IL;
using IL2ExitGames.Client.Photon;
using VRC.Core;


namespace IL2Photon.Realtime
{
    public class LoadBalancingPeer : PhotonPeer
    {
        public LoadBalancingPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public bool OpRaiseEvent(byte eventCode, IntPtr customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(OpRaiseEvent));
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4
                && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName
                )).Name = nameof(OpRaiseEvent);
                if (method == null)
                {
                    "OpRaiseEvent: Not found".RedPrefix("WARN");
                    return default;
                }
            }
            return method.Invoke(ptr, new IntPtr[] { new IntPtr(&eventCode), customEventContent, raiseEventOptions.ptr, new IntPtr(&sendOptions) }).GetValuе<bool>();
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType == PhotonPeer.Instance_Class);
    }
}