using System;
using UnityEngine;
using BlazeIL.il2cpp;
using System.Linq;

public class VRCApplication : MonoBehaviour
{
    public VRCApplication(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCApplication Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<VRCApplication>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().Where(x => x.GetMethods(y => y.Name == "OnApplicationQuit" && y.IsPrivate).Length == 1 && x.GetMethods(y => y.Name == "OnApplicationPause" && y.IsPrivate).Length == 1).FirstOrDefault(x => x.GetProperties(y => y.Instance).Length == 1);
}
