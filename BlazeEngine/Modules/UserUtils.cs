using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRCSDK2;

unsafe public class UserUtils
{
    #region TeleportTo
    public static void TeleportTo(VRC.Player player) => TeleportTo(player.transform);
    public static void TeleportTo(GameObject gameObject) => TeleportTo(gameObject.transform);
    public static void TeleportTo(Transform transform) => TeleportTo(transform.position);
    public static void TeleportTo(Vector3 position)
    {
        VRC.Player.Instance.transform.position = position;
    }
    #endregion

    #region SpawnPortal
    public static GameObject SpawnPortal(Vector3 Position)
    {
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", Position, new Quaternion(0,0,0,0));
        if (gameObject == null)
            return null;

        string wrld = "wrld";
        string inst = "7777";
        int pl = 0;
        VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
        {
            IL2Import.StringToIntPtr(wrld),
            IL2Import.il2cpp_string_new_len(inst, inst.Length),
            new IntPtr(&pl)
        });
        return gameObject;
    }
    #endregion CreatePortal
}
