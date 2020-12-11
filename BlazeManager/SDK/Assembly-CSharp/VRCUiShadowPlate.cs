using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using UnityEngine.UI;

public class VRCUiShadowPlate : MonoBehaviour
{
    public VRCUiShadowPlate(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public void Hide()
    {
        gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dropShadow.gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        mainText.gameObject.SetActive(true);
        dropShadow.gameObject.SetActive(true);
    }

    public Text mainText
    {
        get => Instance_Class.GetField(nameof(mainText)).GetValue(ptr)?.unbox<Text>();
    }

    public Text dropShadow
    {
        get => Instance_Class.GetField(nameof(dropShadow)).GetValue(ptr)?.unbox<Text>();
    }

    public Image image
    {
        get => Instance_Class.GetField(nameof(image)).GetValue(ptr)?.unbox<Image>();
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCUiShadowPlate");
}
