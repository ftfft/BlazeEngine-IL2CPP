using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class VRCApplicationSetup : MonoBehaviour
{
    public VRCApplicationSetup(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCApplicationSetup Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<VRCApplicationSetup>();
        }
    }

    public string appVersion
    {
        get => Instance_Class.GetField(nameof(appVersion)).GetValue(ptr)?.unbox_ToString().ToString();
    }
    
    public int buildNumber
    {
        get => Instance_Class.GetField(nameof(buildNumber)).GetValue(ptr).unbox_Unmanaged<int>();
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCApplicationSetup");
}
