using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCFlowManager : Component
{
    public VRCFlowManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCFlowManager Instance
    {
        get
        {
            if (!properties.ContainsKey(nameof(Instance)))
            {
                properties.Add(nameof(Instance), Instance_Class.GetProperties().First(x => x.Instance));
                if (!properties.ContainsKey(nameof(Instance)))
                    return null;
            }

            return properties[nameof(Instance)].GetGetMethod().Invoke()?.unbox<VRCFlowManager>();
        }
    }
    
    public string WorldInstance
    {
        get
        {
            if (!properties.ContainsKey(nameof(WorldInstance)))
            {
                properties.Add(nameof(WorldInstance), Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName));
                if (!properties.ContainsKey(nameof(WorldInstance)))
                    return null;
            }

            return properties[nameof(WorldInstance)].GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
        }
        set
        {

            if (!properties.ContainsKey(nameof(WorldInstance)))
            {
                properties.Add(nameof(WorldInstance), Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName));
                if (!properties.ContainsKey(nameof(WorldInstance)))
                    return;
            }
            properties[nameof(WorldInstance)].GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }
    }


    public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
    public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
    public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCFlowManager");
}