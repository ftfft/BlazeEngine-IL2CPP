using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCUiManager : MonoBehaviour
{
    public VRCUiManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCUiManager Instance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(Instance));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.Instance)).Name = nameof(Instance);
            return field?.GetValue()?.unbox<VRCUiManager>();
        }
    }

    public VRCUiPage GetPage(string name)
    {
        GameObject gameObject = GameObject.Find(name);
        VRCUiPage vrcuiPage = null;
        if (gameObject != null)
        {
            vrcuiPage = gameObject.GetComponent<VRCUiPage>();
            if (vrcuiPage == null)
            {
                Console.WriteLine("Screen Not Found - " + name);
            }
        }
        else
        {
            Console.WriteLine("Screen Not Found - " + name);
        }
        return vrcuiPage;
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(
        x =>
        x.GetFields().Where(y => y.ReturnType.Name.Contains(VRCUiPage.Instance_Class.FullName)).Count() > 0
    );
}
