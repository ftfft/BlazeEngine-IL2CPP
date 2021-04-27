using System;
using UnityEngine;
using System.Linq;
using BE4v.SDK.CPP2IL;

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
            return property?.GetGetMethod().Invoke()?.GetValue<VRCApplicationSetup>();
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "VRC.Core.ApiServerEnvironment") != null);
}
