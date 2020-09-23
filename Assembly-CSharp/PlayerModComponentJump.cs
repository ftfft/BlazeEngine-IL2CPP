#if (DEBUG)
using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class PlayerModComponentJump : Component
{
    public PlayerModComponentJump(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Field fieldVRCInput = null;
    public VRCInput vrcInput
    {
        get
        {
            if(fieldVRCInput == null)
            {
                fieldVRCInput = Instance_Class.GetFields().First(x => x.GetReturnType().Name.Length > 64);
                if (fieldVRCInput == null)
                    return null;
            }
            if (ptr == IntPtr.Zero)
                return null;

            IL2Object result = fieldVRCInput.GetValue(ptr);
            if (result == null)
                return null;

            return result.MonoCast<VRCInput>();
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(PlayerModComponentJump))
            return false;
        return ((PlayerModComponentJump)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();



    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerModComponentJump");
}
#endif