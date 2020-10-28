using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

public class VRCUiManager : MonoBehaviour
{
    public VRCUiManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldInstance = null;
    public static VRCUiManager Instance
    {
        get
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.Instance);
                if (fieldInstance == null)
                    return null;
            }
            return fieldInstance.GetValue()?.Unbox<VRCUiManager>();
        }
        set
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.Instance);
                if (fieldInstance == null)
                    return;
            }
            fieldInstance.SetValue(value.ptr);
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

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCUiManager");
}
