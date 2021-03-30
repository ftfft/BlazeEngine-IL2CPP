using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BlazeIL.il2cpp;

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

            return field?.GetValue(ptr)?.unbox<VRCInput>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses()
    .FirstOrDefault(
        x => x.GetField(
            y => x.GetFields(z => z.ReturnType.Name == y.ReturnType.Name).Length > 9
        ) != null
    );
}