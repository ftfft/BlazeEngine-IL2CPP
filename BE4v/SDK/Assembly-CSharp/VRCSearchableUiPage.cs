using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCSearchableUiPage : VRCUiPage
{
    public VRCSearchableUiPage(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("SelectSearchOptions");
}