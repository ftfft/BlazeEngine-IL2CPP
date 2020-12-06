using System;
using BlazeIL.il2cpp;
using UnityEngine;

public class UiTooltip : MonoBehaviour
{
    public UiTooltip(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public string text
    {
        get => Instance_Class.GetField(nameof(text)).GetValue(ptr)?.unbox_ToString().ToString();
        set => Instance_Class.GetField(nameof(text)).SetValue(ptr, new IL2String(value).ptr);
    }

    public string alternateText
    {
        get => Instance_Class.GetField(nameof(alternateText)).GetValue(ptr)?.unbox_ToString().ToString();
        set => Instance_Class.GetField(nameof(alternateText)).SetValue(ptr, new IL2String(value).ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiTooltip");
}
