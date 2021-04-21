using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiPageTOS : VRCUiPage
{
    public VRCUiPageTOS(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ContinuePressed") != null && x.GetMethod("OpenPrivacyPolicy") != null);
}