using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class SyncPhysics : VRCNetworkBehaviour
{
    public SyncPhysics(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    static SyncPhysics()
    {
        Instance_Class.GetMethod(x => x.GetParameters().Length == 3 && x.GetParameters()[1].ReturnType.Name == typeof(float).FullName).Name = "ApplyEvent";
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("EnableKinematic");
}