using System;
using System.Linq;
using UnityEngine;
using Transmtn.DTO.Notifications;
using VRC.UI;
using BE4v.SDK.CPP2IL;

public class NotificationManager : MonoBehaviour
{
    public NotificationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static NotificationManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);

            return property?.GetGetMethod().Invoke()?.GetValue<NotificationManager>();
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
                var disassembler = method.GetDisassembler(0x1000);
                var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall);
                foreach (var instruction in instructions)
                {
                    try
                    {

                        IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
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

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("NotificationManager");
}
