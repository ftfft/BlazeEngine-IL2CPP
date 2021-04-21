using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public abstract class UiVRCList : MonoBehaviour
{
    public UiVRCList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ToggleExtend") != null && x.BaseType.FullName == MonoBehaviour.Instance_Class.FullName);
}