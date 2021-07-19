using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class ObjectInstantiator : MonoBehaviour
{
    public ObjectInstantiator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("_InstantiateObject");
}
