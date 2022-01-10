using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

public static class UserUtils
{

    #region SpawnPortal
    public static GameObject SpawnPortal(Transform transform, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde", string instanceId = "Banned Instance\nTupper\0")
    {
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", transform.position + (transform.forward * 2), Quaternion.identity);
        if (gameObject == null)
            return null;

        VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
        {
            new IL2String(worldId).ptr,
            new IL2String(instanceId).ptr,
            Import.Object.CreateNewObject(0, IL2SystemClass.Int32)
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