using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class UiTooltip : MonoBehaviour
{
    public UiTooltip(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public string text
    {
        get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[0].GetValue(ptr)?.GetValue<string>();
        set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[0].SetValue(ptr, new IL2String(value).ptr);
    }

    public string alternateText
    {
        get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[1].GetValue(ptr)?.GetValue<string>();
        set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[1].SetValue(ptr, new IL2String(value).ptr);
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses()
        .FirstOrDefault(x => 
            x.GetMethod("OnPointerExit") != null &&
            x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Text.Instance_Class.FullName).Length == 2 &&
            x.GetFields(y => y.ReturnType.Name == typeof(string).FullName).Length == 2
        );
}
