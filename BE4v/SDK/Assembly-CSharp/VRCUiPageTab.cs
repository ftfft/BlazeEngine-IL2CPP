using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiPageTab : MonoBehaviour
{
    public VRCUiPageTab(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowPage") != null);
}