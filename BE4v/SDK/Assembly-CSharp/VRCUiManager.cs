using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class VRCUiManager : MonoBehaviour
{
    public VRCUiManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCUiManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<VRCUiManager>();
        }
    }


	public static T GetPage<T>(string screenPath) where T : VRCUiPage
	{
        return GameObject.Find(screenPath)?.GetComponent<T>();
    }

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("HideScreen") != null);
}