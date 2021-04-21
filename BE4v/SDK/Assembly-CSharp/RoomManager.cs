using System;
using System.Linq;
using VRC.Core;
using UnityEngine;
using BE4v.SDK.CPP2IL;

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
                    string result = method.Invoke().GetValue<string>();
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

            return methodGetCurrentOwnerId.Invoke()?.GetValue<string>();
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

    public static ApiWorld currentRoom
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(currentRoom));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == ApiWorld.Instance_Class.FullName)).Name = nameof(currentRoom);
            return field?.GetValue()?.GetValue<ApiWorld>();
        }
    }
    /*
    public static IL2Dictionary<int, PortalInternal> userPortals
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(userPortals));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<" +  typeof(int).FullName + "," + PortalInternal.Instance_Class.FullName + ">")).Name = nameof(userPortals);

            IL2Object result = field?.GetValue();
            if (result == null)
                return null;

            return new IL2Dictionary<int, PortalInternal>(result.ptr);
        }
    }
    */

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == MonoBehaviour.Instance_Class.FullName && x.GetField(y => y.ReturnType.Name == "System.Collections.Generic.Dictionary<" + typeof(int).FullName + "," + PortalInternal.Instance_Class.FullName + ">") != null);
}