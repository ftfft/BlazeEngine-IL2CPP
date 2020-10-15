using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

public class ModerationManager : Component
{
    public ModerationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static ModerationManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Instance_Class.FullName);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<ModerationManager>();
        }
    }

    
    public static IL2Method methodIsBlockedEitherWay = null;
    public bool IsBlockedEitherWay(string userId) => IsBlockedEitherWay(IL2Import.StringToIntPtr(userId));
    public bool IsBlockedEitherWay(IntPtr userId)
    {
        if (methodIsBlockedEitherWay == null)
            return false;

        return methodIsBlockedEitherWay.Invoke(ptr, new IntPtr[] { userId }).Unbox<bool>();
    }

    

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ModerationManager");
}