using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

public class ModerationManager : IL2Base
{
    public ModerationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static ModerationManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.Instance);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<ModerationManager>();
        }
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "System.Collections.Generic.List<VRC.Core.ApiPlayerModeration>").Count() == 1);
}