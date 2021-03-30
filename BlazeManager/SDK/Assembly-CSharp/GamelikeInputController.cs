using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BlazeIL.il2cpp;

public class GamelikeInputController : LocomotionInputController
{
    public GamelikeInputController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == LocomotionInputController.Instance_Class.FullName && x.GetMethod("LateUpdate") != null);
}