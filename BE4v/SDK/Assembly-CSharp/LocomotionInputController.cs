using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class LocomotionInputController : InputStateController
{
    public LocomotionInputController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public VRCInput inJump
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(inJump));
            if (field == null)
                (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName)).Name = nameof(inJump);

            return field?.GetValue(ptr)?.GetValue<VRCInput>();
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(PlayerModComponentSpeed.Instance_Class.GetField(x => x.ReturnType.Name.Length > 40).ReturnType.Name);
}