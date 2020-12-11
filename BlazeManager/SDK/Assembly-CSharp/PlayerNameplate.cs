using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameplate : MonoBehaviour
{
    public PlayerNameplate(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public TextMeshProUGUI uiName
    {
        get => Instance_Class.GetField(nameof(uiName)).GetValue(ptr)?.unbox<TextMeshProUGUI>();
    }
    public Graphic uiNameBackground
    {
        get => Instance_Class.GetField(nameof(uiNameBackground)).GetValue(ptr)?.unbox<Graphic>();
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PlayerNameplate");
}
