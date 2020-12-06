using System;
using System.Linq;
using UnityEngine;
using VRC;
using BlazeIL.il2cpp;

public class NetworkManager : MonoBehaviour
{
    public NetworkManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static NetworkManager Instance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(Instance));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
            return field?.GetValue()?.unbox<NetworkManager>();
        }
    }
    /*
    private static IL2Method methodOnVRCPlayerLeft = null;
    public void OnVRCPlayerLeft(Player player)
    {
        if (methodOnVRCPlayerLeft == null)
        {
            methodOnVRCPlayerLeft = Instance_Class.GetMethods().Last(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName);
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
            methodOnVRCPlayerJoined = Instance_Class.GetMethods().First(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName);
            if (methodOnVRCPlayerJoined == null)
                return;
        }
        methodOnVRCPlayerJoined.Invoke(ptr, new IntPtr[] { player.ptr });
    }
    */
    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("NetworkManager");
}
