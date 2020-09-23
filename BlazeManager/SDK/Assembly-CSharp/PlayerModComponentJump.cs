using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class PlayerModComponentJump : Component
{
    public PlayerModComponentJump(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldVRCInput = null;
    public VRCInput vrcInput
    {
        get
        {
            if(fieldVRCInput == null)
            {
                fieldVRCInput = Instance_Class.GetFields().First(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName);
                if (fieldVRCInput == null)
                    return null;
            }

            return fieldVRCInput.GetValue(ptr)?.Unbox<VRCInput>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerModComponentJump");
}