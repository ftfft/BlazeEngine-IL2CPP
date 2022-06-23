using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.SDKBase;
using BE4v.SDK;
using SharpDisasm;
public static class UserUtils
{
    unsafe public static Disassembler GetDisassembler(this IL2Method method, int @size = 0x1000)
    {
        return new Disassembler(*(IntPtr*)method.Pointer, @size, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.Pointer).ToInt64()), true, Vendor.Intel);
    }

    #region SpawnPortal
    public static GameObject SpawnPortal(Transform transform, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde", string instanceId = "Banned Instance\nTupper\0")
    {
        return SpawnPortal(transform.position + (transform.forward * 2), worldId, instanceId);
    }
    public static GameObject SpawnPortal(Vector3 position, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde", string instanceId = "Banned Instance\nTupper\0")
    {
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", position, Quaternion.identity);
        if (gameObject == null)
            return null;

        VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
        {
            new IL2String(worldId).Pointer,
            new IL2String(instanceId).Pointer,
            new IL2Object<int>(0, IL2Int32.Instance_Class).Pointer
        });
        gameObject.GetComponent<PortalInternal>().enabled = false;

        return gameObject;
    }
    #endregion CreatePortal

    public static GameObject SpawnDynLight(Transform transform)
    {
        string[] arrayString = ObjectInstantiator.adminOnlyPrefabs;
        ObjectInstantiator.adminOnlyPrefabs = new string[0];
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Local, "DevProp_DynLight", transform.position + (transform.forward * 2), new Quaternion(0, 0, 0, 0));
        ObjectInstantiator.adminOnlyPrefabs = arrayString;
        return gameObject;
    }

    public static void RemoveInstiatorObjects()
    {
        foreach(var obj in UnityEngine.Object.FindObjectsOfType<ObjectInstantiatorHandle>())
            obj.gameObject.Destroy();
        // RoomManager.userPortals.Clear();
    }
    /*
    internal static APIUser current_User_UserInfo
    {
        get
        {
            // return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<VRCUiPage>()?.user;
            return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<PageUserInfo>()?.user;
        }
    }
    */
}