using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using Transmtn.DTO.Notifications;

public class NotificationManager : MonoBehaviour
{
    public NotificationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static NotificationManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Instance_Class.FullName && x.HasFlag(IL2BindingFlags.FIELD_STATIC));
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<NotificationManager>();
        }
    }

    private static IL2Method methodSendNotification = null;
    public void SendNotification(string receiverUserId, string type, string message, NotificationDetails details)
    {
        if (methodSendNotification == null)
        {
            // methodSendNotification = Instance_Class;
            if (methodSendNotification == null)
                return;
        }

        Console.WriteLine("test");
        // methodSendNotification.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(receiverUserId), IL2Import.StringToIntPtr(type), IL2Import.StringToIntPtr(message), details.ptr });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("NotificationManager");
}
