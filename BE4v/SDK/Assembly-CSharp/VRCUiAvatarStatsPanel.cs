using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiAvatarStatsPanel : MonoBehaviour
{
    public VRCUiAvatarStatsPanel(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("BackPressed") != null && x.BaseType.FullName == MonoBehaviour.Instance_Class.FullName);
}