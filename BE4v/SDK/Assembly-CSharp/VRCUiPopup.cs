using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiPopup : VRCUiPage
{
    public VRCUiPopup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = PopupReport.Instance_Class.BaseType;
}