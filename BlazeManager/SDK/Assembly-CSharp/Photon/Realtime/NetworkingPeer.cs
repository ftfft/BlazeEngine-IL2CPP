using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;
using Photon.Pun;

namespace Photon.Realtime
{
    public class LoadBalancingClient : IL2Base
    {
        public LoadBalancingClient(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodOpRaiseEvent = null;
        public bool OpRaiseEvent(byte operationCode, IntPtr operationParameters, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            if (methodOpRaiseEvent == null)
            {
                methodOpRaiseEvent = Instance_Class?.GetMethods(x => x.GetParameters().Length == 4).First(x => x.GetParameters()[0].ReturnType.Name == "System.Byte");
                if (methodOpRaiseEvent == null)
                    return false;
            }

            return methodOpRaiseEvent.Invoke(ptr, new IntPtr[] { operationCode.MonoCast(), operationParameters, raiseEventOptions.ptr, sendOptions.MonoCast() }, isVirtual: true, ex: false).unbox_Unmanaged<bool>();
        }

        // public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(PhotonNetwork.Instance_Class.GetFields().First(x => x.Token == 0x10).ReturnType.Name);
        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().Where(x => x.FullName != "Photon.Realtime.AppSettings").First(x => x.GetFields().Where(y => y.ReturnType.Name == "ExitGames.Client.Photon.ConnectionProtocol").Count() == 1);
    }
}