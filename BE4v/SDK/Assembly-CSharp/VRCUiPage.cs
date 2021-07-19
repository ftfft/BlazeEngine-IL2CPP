using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiPage : MonoBehaviour
{
    public VRCUiPage(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = VRCUiPopup.Instance_Class.BaseType;
}