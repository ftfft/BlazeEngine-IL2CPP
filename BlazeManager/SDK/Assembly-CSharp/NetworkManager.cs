using System;
using System.Linq;
using UnityEngine;
using VRC;
using BlazeIL.il2cpp;

public class NetworkManager : Component
{
    public NetworkManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldInstance = null;
    public static NetworkManager Instance
    {
        get
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.ReturnType.Name == Instance_Class.FullName);
                if (fieldInstance == null)
                    return null;
            }

            return fieldInstance.GetValue()?.Unbox<NetworkManager>();
        }
    }

    private static IL2Method methodOnVRCPlayerLeft = null;
    public void OnVRCPlayerLeft(Player player)
    {
        if (methodOnVRCPlayerLeft == null)
        {
            methodOnVRCPlayerLeft = Instance_Class.GetMethods().OrderBy(x => x.Token).Last(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName);
            if (methodOnVRCPlayerLeft == null)
                return;
        }
        methodOnVRCPlayerLeft.Invoke(ptr, new IntPtr[] { player.ptr });
    }

    private static IL2Method methodOnVRCPlayerJoined = null;
    public void OnVRCPlayerJoined(Player player)
    {
        if (methodOnVRCPlayerJoined == null)
        {
            methodOnVRCPlayerJoined = Instance_Class.GetMethods().OrderBy(x => x.Token).First(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName);
            if (methodOnVRCPlayerJoined == null)
                return;
        }
        methodOnVRCPlayerJoined.Invoke(ptr, new IntPtr[] { player.ptr });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("NetworkManager");
}
