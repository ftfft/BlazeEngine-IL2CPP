using System;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;
using BE4v.SDK.CPP2IL;

public class VRC_EventDispatcherRFC : VRC_EventDispatcher
{
    public VRC_EventDispatcherRFC(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType == VRC_EventDispatcher.Instance_Class);
}