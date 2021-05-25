using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;

public static class Vector3Extensions
{
    public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethods().Length == 2 && x.GetMethod(y => y.IsStatic && y.GetParameters().Length == 1 && y.GetParameters()[0].ReturnType.Name == "UnityEngine.Vector3") != null  && x.GetMethod(y => y.IsStatic && y.GetParameters().Length == 4 && y.GetParameters()[0].ReturnType.Name == "UnityEngine.Vector3") != null);
}