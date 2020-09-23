using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCMotionState : Component
{
    public VRCMotionState(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static IL2Method methodJump = null;
    public void Jump(float size)
    {

    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCMotionState");
}