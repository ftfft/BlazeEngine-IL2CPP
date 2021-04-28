using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRC_TriggerInternal : MonoBehaviour
{
    public VRC_TriggerInternal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField("hasColliderTriggers") != null);
}