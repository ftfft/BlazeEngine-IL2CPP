using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRC_StationInternal2 : VRC_StationInternal
{
    public VRC_StationInternal2(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType == VRC_StationInternal.Instance_Class && x.GetMethod("ProvideEvents") != null);
}