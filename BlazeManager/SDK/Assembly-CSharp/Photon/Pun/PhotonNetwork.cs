using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun
{
    public static class PhotonNetwork
    {
        private static IL2Field fieldNetworkingClient = null;
        public static LoadBalancingClient NetworkingClient
        {
            get
            {
                if (fieldNetworkingClient == null)
                {
                    fieldNetworkingClient = Instance_Class.GetFields().First(x => x.ReturnType.Name == LoadBalancingClient.Instance_Class.FullName);
                    if (fieldNetworkingClient == null)
                        return null;
                }
                return fieldNetworkingClient.GetValue()?.unbox<LoadBalancingClient>();
            }
        }
        private static IL2Property propertyPhotonTime = null;
        public static double photonTime
        {
            get
            {
                if (propertyPhotonTime == null)
                {
                    propertyPhotonTime = Instance_Class.GetProperty(x => x.IsStatic && x.GetGetMethod().ReturnType.Name == typeof(double).FullName);
                    if (propertyPhotonTime == null)
                        return default;
                }
                return propertyPhotonTime.GetGetMethod().Invoke().unbox_Unmanaged<double>();
            }
        }

        private static IL2Method methodTransferOwnership = null;
        public static void TransferOwnership(int viewId, int fromId)
        {
            if (methodTransferOwnership == null)
            {
                methodTransferOwnership = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).First();
                if (methodTransferOwnership == null)
                    return;
            }
            methodTransferOwnership.Invoke(new IntPtr[] { viewId.MonoCast(), fromId.MonoCast() });
        }

        private static IL2Method methodRequestOwnership = null;
        public static void RequestOwnership(int viewId, int fromId)
        {
            if (methodRequestOwnership == null)
            {
                methodRequestOwnership = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).Last();
                if (methodRequestOwnership == null)
                    return;
            }
            methodRequestOwnership.Invoke(new IntPtr[] { viewId.MonoCast(), fromId.MonoCast() });
        }

        private static IL2Method methodRPCSecure = null;
        public static void RPCSecure(PhotonView photonView, string command, TargetType target, bool encrypt, IntPtr[] objects)
        {
            if (methodRPCSecure == null)
            {
                methodRPCSecure = Instance_Class.GetMethods(x => x.GetParameters().Length == 5).First(x =>
                x.GetParameters()[0].ReturnType.Name == PhotonView.Instance_Class.FullName &&
                x.GetParameters()[1].ReturnType.Name == typeof(string).FullName &&
                x.GetParameters()[2].ReturnType.Name != PhotonPlayer.Instance_Class.FullName &&
                x.GetParameters()[3].ReturnType.Name == typeof(bool).FullName &&
                x.GetParameters()[4].ReturnType.Name == typeof(object[]).FullName);
                if (methodRPCSecure == null)
                    return;
            }

            methodRPCSecure.Invoke(new IntPtr[] { photonView.ptr, new IL2String(command).ptr, target.MonoCast(), encrypt.MonoCast(), objects.ArrayToIntPtr() });
        }
        private static IL2Method methodRPCSecure2 = null;
        public static void RPCSecure(PhotonView photonView, string command, PhotonPlayer target, bool encrypt, IntPtr[] objects)
        {
            if (methodRPCSecure2 == null)
            {
                methodRPCSecure2 = Instance_Class.GetMethods(x => x.GetParameters().Length == 5).First(x =>
                x.GetParameters()[0].ReturnType.Name == PhotonView.Instance_Class.FullName &&
                x.GetParameters()[1].ReturnType.Name == typeof(string).FullName &&
                x.GetParameters()[2].ReturnType.Name == PhotonPlayer.Instance_Class.FullName &&
                x.GetParameters()[3].ReturnType.Name == typeof(bool).FullName &&
                x.GetParameters()[4].ReturnType.Name == typeof(object[]).FullName);
                if (methodRPCSecure2 == null)
                    return;
            }

            methodRPCSecure2.Invoke(IntPtr.Zero, new IntPtr[] { photonView.ptr, new IL2String(command).ptr, target.ptr, encrypt.MonoCast(), objects.ArrayToIntPtr() });
        }


        private static IL2Method methodOpRaiseEvent = null;
        public static bool OpRaiseEvent(byte operationCode, IntPtr operationParameters, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            if (methodOpRaiseEvent == null)
            {
                methodOpRaiseEvent = Instance_Class.GetMethods(x => x.GetParameters().Length == 4 && x.IsStatic).First(x => x.GetParameters()[0].ReturnType.Name == "System.Byte" && x.HasFlag(IL2BindingFlags.METHOD_PRIVATE));
                if (methodOpRaiseEvent == null)
                    return false;
            }

            IL2Object result = methodOpRaiseEvent.Invoke(new IntPtr[] { operationCode.MonoCast(), operationParameters, raiseEventOptions.ptr, sendOptions.MonoCast() });
            if (result == null)
                return false;

            return result.unbox_Unmanaged<bool>();
        }

        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "Photon.Pun.ServerSettings").Count() == 1);
    }
}
