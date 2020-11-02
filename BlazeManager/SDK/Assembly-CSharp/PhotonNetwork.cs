using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;

public static class PhotonNetwork
{
    private static IL2Field fieldPhotonPeer = null;
    public static NetworkingPeer networkingPeer
    {
        get
        {
            if (fieldPhotonPeer == null)
            {
                fieldPhotonPeer = Instance_Class.GetFields().First(x => x.ReturnType.Name == NetworkingPeer.Instance_Class.FullName);
                if (fieldPhotonPeer == null)
                    return null;
            }
            return fieldPhotonPeer.GetValue()?.unbox<NetworkingPeer>();
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
