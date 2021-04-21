using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class PortalInternal : MonoBehaviour
{
    public PortalInternal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    unsafe public void SetTimerRPC(float timer, VRC.Player player)
    {
        Instance_Class.GetMethod(nameof(SetTimerRPC)).Invoke(ptr, new IntPtr[] { new IntPtr(&timer), player.ptr });
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("SetTimerRPC") != null);
}
