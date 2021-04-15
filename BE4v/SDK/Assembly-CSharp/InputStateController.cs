using System;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public abstract class InputStateController : MonoBehaviour
{
    public InputStateController(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(LocomotionInputController.Instance_Class.BaseType.FullName);
}