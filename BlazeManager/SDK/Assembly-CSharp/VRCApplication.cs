using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class VRCApplication : MonoBehaviour
{
    public VRCApplication(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    private static IL2Property propertyInstance = null;
    public static VRCApplication Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.Instance);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<VRCApplication>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCApplication");
}
