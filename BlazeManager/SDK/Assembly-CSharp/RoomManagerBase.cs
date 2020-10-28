using System;
using System.Linq;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using VRC.Core;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public RoomManager(IntPtr ptr) : base(ptr) => this.ptr = ptr;

    public static string GetPhotonRoomIDForWorldInstance(ApiWorldInstance apiWorldInstance)
    {
        return apiWorldInstance.instanceWorld.id + ":" + apiWorldInstance.idWithTags;
    }

    private static IL2Method methodGetCurrentOwnerId = null;
    public static string currentOwnerId
    {
        get
        {
            if (methodGetCurrentOwnerId == null)
            {
                foreach (IL2Method method in Instance_Class.GetMethods().Where(x => x.ReturnType.Name == "System.String" && x.GetParameters().Length == 0))
                {
                    string result = method.Invoke().Unbox<string>();
                    if (result.Length == 40)
                    {
                        if (result.Contains("usr_"))
                        {
                            methodGetCurrentOwnerId = method;
                            break;
                        }
                    }
                }
                if (methodGetCurrentOwnerId == null)
                    return string.Empty;
            }

            return methodGetCurrentOwnerId.Invoke()?.Unbox<string>();
        }
    }

    public static string CreatorInstanceId
    {
        get
        {
            if (currentRoom == null)
                return null;

            ApiWorldInstance apiWorldInstance = new ApiWorldInstance(currentRoom, currentRoom.currentInstanceIdWithTags, 0);
            return apiWorldInstance.GetInstanceCreator();
        }
    }

    private static IL2Field fieldCurrentRoom = null;
    public static ApiWorld currentRoom
    {
        get
        {
            if (fieldCurrentRoom == null)
            {
                fieldCurrentRoom = Instance_Class.GetFields().First(x => x.ReturnType.Name == ApiWorld.Instance_Class.FullName);
                if (fieldCurrentRoom == null)
                    return null;
            }
            return fieldCurrentRoom.GetValue()?.Unbox<ApiWorld>();
        }
    }
    

    private static IL2Field fieldPortalInternalList = null;
    public static IL2Dictionary<int, PortalInternal> portalInternalList
    {
        get
        {
            if (fieldPortalInternalList == null)
            {
                fieldPortalInternalList = Instance_Class.GetFields().First(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<" +  typeof(int).FullName + "," + PortalInternal.Instance_Class.FullName + ">");
                if (fieldPortalInternalList == null)
                    return null;
            }
            return new IL2Dictionary<int, PortalInternal>(fieldPortalInternalList.GetValue().ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("RoomManager");
}