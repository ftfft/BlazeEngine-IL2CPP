using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;

unsafe public class VRCApplicationSetup : Component
{
    public VRCApplicationSetup(IntPtr newPtr) : base(newPtr) =>
        ptr = newPtr;


    private static IL2Property propertyInstance = null;
    public static VRCApplicationSetup Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCApplicationSetup");
                if (propertyInstance == null)
                    return null;
            }

            IL2Object result = propertyInstance.GetGetMethod().Invoke();
            if (result == null)
                return null;

            return result.MonoCast<VRCApplicationSetup>();
        }
    }

    private static IL2Field fieldBuildNumber = null;
    public int buildNumber
    {
        get
        {
            if (fieldBuildNumber == null)
            {
                fieldBuildNumber = Instance_Class.GetField("buildNumber");
                if (fieldBuildNumber == null)
                    return default;
            }

            IL2Object result = fieldBuildNumber.GetValue(ptr);
            if (result == null)
                return default;

            return *(int*)result.Unbox();
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(VRCApplicationSetup))
            return false;
        return ((VRCApplicationSetup)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCApplicationSetup");
}
