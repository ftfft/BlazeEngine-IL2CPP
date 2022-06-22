using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class UiTooltip : MonoBehaviour
{
    public UiTooltip(IntPtr ptr) : base(ptr) { }

    public string text
    {
        get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[0].GetValue(this)?.GetValue<IL2String>().ToString();
        set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[0].SetValue(this, new IL2String(value).Pointer);
    }

    public string alternateText
    {
        get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[1].GetValue(this)?.GetValue<IL2String>().ToString();
        set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(string).FullName)[1].SetValue(this, new IL2String(value).Pointer);
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses()
        .FirstOrDefault(x => 
            x.GetMethod("OnPointerExit") != null &&
            x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Text.Instance_Class.FullName).Length == 2 &&
            x.GetFields(y => y.ReturnType.Name == typeof(string).FullName).Length == 2
        );
}
