using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using Transmtn.DTO.Notifications;
using VRC.UI;

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
                propertyInstance = Instance_Class.GetProperties().First(x => x.Instance);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.unbox<NotificationManager>();
        }
    }

    private static IL2Method methodSendNotification = null;
    public void SendNotification(string receiverUserId, string type, string message, NotificationDetails details)
    {
        if (methodSendNotification == null)
        {
            IL2Method method = PageUserInfo.Instance_Class.GetMethod("RequestInvitation");
            unsafe
            {
                var disassembler = disasm.GetDisassembler(method, 0x1000);
                var instructions = disassembler.Disassemble().Where(x => ILCode.IsCall(x));
                foreach (var instruction in instructions)
                {
                    try
                    {

                        IntPtr addr = ILCode.GetPointer(instruction);
                        methodSendNotification = Instance_Class.GetMethods().Where(x => !x.IsStatic && x.GetParameters().Length == 4).FirstOrDefault(x => *(IntPtr*)x.ptr == addr);
                        if (methodSendNotification != null)
                            break;
                    }
                    catch
                    {
                    }
                }
            }
            if (methodSendNotification == null)
                return;
        }

        methodSendNotification.Invoke(ptr, new IntPtr[] { new IL2String(receiverUserId).ptr, new IL2String(type).ptr, new IL2String(message).ptr, details.ptr });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("NotificationManager");
}
