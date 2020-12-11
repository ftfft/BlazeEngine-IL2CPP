using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCFlowManager : MonoBehaviour
{
    public VRCFlowManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCFlowManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<VRCFlowManager>();
        }
    }
    
    public string DestinationWorldId
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(DestinationWorldId));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(DestinationWorldId);
            return property?.GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
        }
        set
        {
            IL2Property property = Instance_Class.GetProperty(nameof(DestinationWorldId));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(DestinationWorldId);
            property?.GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCFlowManager");
}