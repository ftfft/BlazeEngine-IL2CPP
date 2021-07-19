using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class EffectSettings : MonoBehaviour
{
    public EffectSettings(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("Deactivate") != null && x.GetMethod("OnEnable") != null && string.IsNullOrEmpty(x.Namespace));
}