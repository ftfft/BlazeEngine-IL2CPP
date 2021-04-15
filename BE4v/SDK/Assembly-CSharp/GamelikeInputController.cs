using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class GamelikeInputController : LocomotionInputController
{
    public GamelikeInputController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == LocomotionInputController.Instance_Class.FullName && x.GetMethod("LateUpdate") != null);
}