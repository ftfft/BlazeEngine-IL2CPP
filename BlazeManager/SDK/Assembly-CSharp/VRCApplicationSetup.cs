using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;

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

    public string GetGameServerVersion()
    {
        IL2Method method = Instance_Class.GetMethod(nameof(GetGameServerVersion));
        if (method == null)
        {
            var methods = Instance_Class.GetMethods(x => !x.IsStatic && x.ReturnType.Name == typeof(string).FullName && x.GetParameters().Length == 0);
            foreach(var m in methods)
            {
                if (m.Invoke(ptr)?.unbox_ToString().ToString().Contains("_2018_server_") == true)
                    (method = m).Name = nameof(GetGameServerVersion);
            }
        }
        return method?.Invoke(ptr)?.unbox_ToString().ToString();
    }


    public string appVersion
    {
        get => Instance_Class.GetField(nameof(appVersion)).GetValue(ptr)?.unbox_ToString().ToString();
    }
    
    public int buildNumber
    {
        get => Instance_Class.GetField(nameof(buildNumber)).GetValue(ptr).unbox_Unmanaged<int>();
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCApplicationSetup");
}
