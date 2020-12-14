using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using IL2ExitGames.Client.Photon;
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

                IL2Object result = property?.GetGetMethod().Invoke();
                if (result == null)
                    return default;
                return result.unbox_Unmanaged<double>();
            }
        }

        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        public static LoadBalancingClient NetworkingClient
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(NetworkingClient));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == LoadBalancingClient.Instance_Class.FullName)).Name = nameof(NetworkingClient);
                return field?.GetValue()?.unbox<LoadBalancingClient>();
            }
        }

        public static void RequestOwnership(int viewId, int fromId)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RequestOwnership));
            if (method == null)
                (method = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).First()).Name = nameof(RequestOwnership);
            method?.Invoke(new IntPtr[] { viewId.MonoCast(), fromId.MonoCast() });
        }

        public static void TransferOwnership(int viewId, int fromId)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(TransferOwnership));
            if (method == null)
                (method = Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 2 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName).Last()).Name = nameof(TransferOwnership);
            method?.Invoke(new IntPtr[] { viewId.MonoCast(), fromId.MonoCast() });
        }

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

        public static bool RaiseEvent(byte operationCode, IntPtr operationParameters, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(RaiseEvent));
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName && x.IsPrivate)).Name = nameof(RaiseEvent);
            IL2Object result = method?.Invoke(new IntPtr[] { operationCode.MonoCast(), operationParameters, raiseEventOptions.ptr, sendOptions.MonoCast() });
            if (result == null)
                return default;
            return result.unbox_Unmanaged<bool>();
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == RaiseEventOptions.Instance_Class.FullName).Count() > 0);
    }
}
