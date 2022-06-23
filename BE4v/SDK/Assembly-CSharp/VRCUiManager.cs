using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRCUiManager : MonoBehaviour
{
    public VRCUiManager(IntPtr ptr) : base(ptr) { }

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

    public void HideScreen(string screenType)
    {
        Instance_Class.GetMethod(nameof(HideScreen)).Invoke(this, new IntPtr[] { new IL2String(screenType).Pointer });
    }

    public static T GetPage<T>(string screenPath) where T : VRCUiPage
	{
        return GameObject.Find(screenPath)?.GetComponent<T>();
    }

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("HideScreen") != null);
}