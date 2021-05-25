using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using System.IO;
using System.Text;

public class VRCUiPopupManager : MonoBehaviour
{
    public VRCUiPopupManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static VRCUiPopupManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property.GetGetMethod().Invoke().GetValue<VRCUiPopupManager>();
        }
    }

    unsafe public void ShowAlert(string title, string body, float timeout = 10f)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ShowAlert));
        if (method == null)
            (method = Instance_Class.GetMethods(x => x.GetParameters().Length == 3 && x.GetParameters()[2].ReturnType.Name == typeof(float).FullName).First(x => x.GetDisassembler().Disassemble().Count() == 1010)).Name = nameof(ShowAlert);
        method.Invoke(ptr, new IntPtr[] { new IL2String(title).ptr, new IL2String(body).ptr, new IntPtr(&timeout) });
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowControllerBindingsPopup") != null);
}