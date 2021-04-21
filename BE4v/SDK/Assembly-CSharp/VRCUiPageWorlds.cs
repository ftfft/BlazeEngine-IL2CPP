using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiPageWorlds : VRCSearchableUiPage
{
    public VRCUiPageWorlds(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRCUiPlaylists.Instance_Class.BaseType.FullName);
}