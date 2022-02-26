using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using IL2ExitGames.Client.Photon;
using IL2Photon.Pun;
using IL2Photon.Realtime;

namespace IL2Photon.Pun
{
    public static class PhotonNetwork
    {
        // <!---------- ---------- ---------->
        // <!---------- PROPERTY'S ---------->
        // <!---------- ---------- ---------->
        public static double Time
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Time));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(double).FullName)).Name = nameof(Time);
                return property?.GetGetMethod().Invoke()?.GetValuе<double>() ?? default(double);
            }
        }

        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        unsafe public static void RequestOwnership(int viewId, int fromId)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RequestOwnership));
            if (method == null)
                (method = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).First()).Name = nameof(RequestOwnership);
            method?.Invoke(new IntPtr[] { new IntPtr(&viewId), new IntPtr(&fromId) });
        }

        unsafe public static void TransferOwnership(int viewId, int fromId)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(TransferOwnership));
            if (method == null)
                (method = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).Last()).Name = nameof(TransferOwnership);
            method?.Invoke(new IntPtr[] { new IntPtr(&viewId), new IntPtr(&fromId) });
        }
        /*
        public static void RPC(PhotonView view, string methodName, RpcTarget target, bool encrypt, IntPtr[] parameters)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RPC), x => x.GetParameters().Length == 5 && x.GetParameters()[2].ReturnType.Name != IL2Photon.Realtime.Player.Instance_Class.FullName);
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 5 && x.GetParameters()[2].ReturnType.Name != IL2Photon.Realtime.Player.Instance_Class.FullName)).Name = nameof(RPC);
            method?.Invoke(new IntPtr[] { view.ptr, new IL2String(methodName).ptr, target.MonoCast(), encrypt.MonoCast(), parameters.ArrayToIntPtr() });
        }

        public static void RPC(PhotonView view, string methodName, IL2Photon.Realtime.Player targetPlayer, bool encrypt, IntPtr[] parameters)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RPC), x => x.GetParameters().Length == 5 && x.GetParameters()[2].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName);
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 5 && x.GetParameters()[2].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName)).Name = nameof(RPC);
            method?.Invoke(new IntPtr[] { view.ptr, new IL2String(methodName).ptr, targetPlayer.ptr, encrypt.MonoCast(), parameters.ArrayToIntPtr() });
        }

        public static void RPC(PhotonView view, string methodName, RpcTarget target, IL2Photon.Realtime.Player player, bool encrypt, IntPtr[] parameters)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RPC), x => x.GetParameters().Length == 6);
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 6 && x.GetParameters()[3].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName)).Name = nameof(RPC);
            method?.Invoke(new IntPtr[] { view.ptr, new IL2String(methodName).ptr, target.MonoCast(), player.ptr, encrypt.MonoCast(), parameters.ArrayToIntPtr() });
        }
        */

        unsafe public static bool RaiseEvent(byte operationCode, IntPtr operationParameters, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RaiseEvent));
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName && x.IsPrivate)).Name = nameof(RaiseEvent);
                if (method == null)
                    return false;
            }
            return method.Invoke(new IntPtr[] { new IntPtr(&operationCode), operationParameters, raiseEventOptions == null ? IntPtr.Zero : raiseEventOptions.ptr, new IntPtr(&sendOptions) }).GetValuе<bool>();
        }



        public static LoadBalancingClient NetworkingClient
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(NetworkingClient));
                if (field == null)
                {
                    (field = Instance_Class.GetField(LoadBalancingClient.Instance_Class)).Name = nameof(NetworkingClient);
                    if (field == null)
                        return null;
                }
                return field.GetValue().GetValue<LoadBalancingClient>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(NetworkingClient));
                if (field == null)
                {
                    (field = Instance_Class.GetField(LoadBalancingClient.Instance_Class)).Name = nameof(NetworkingClient);
                    if (field == null)
                        return;
                }
                field.GetValue(value == null ? IntPtr.Zero : value.ptr);
            }
        }


        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(LoadBalancingClient.Instance_Class) != null);
    }
}
