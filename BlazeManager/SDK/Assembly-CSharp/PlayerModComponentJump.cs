using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class PlayerModComponentJump : MonoBehaviour
{
    public PlayerModComponentJump(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public LocomotionInputController _controller
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(_controller));
            if(field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == LocomotionInputController.Instance_Class.FullName)).Name = nameof(_controller);

            return field?.GetValue(ptr)?.unbox<LocomotionInputController>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerModComponentJump");
}