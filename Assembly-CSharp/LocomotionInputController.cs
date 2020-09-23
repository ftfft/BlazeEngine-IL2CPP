using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class LocomotionInputController : Component
{
    public LocomotionInputController(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(LocomotionInputController))
            return false;
        return ((LocomotionInputController)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("LocomotionInputController");
}