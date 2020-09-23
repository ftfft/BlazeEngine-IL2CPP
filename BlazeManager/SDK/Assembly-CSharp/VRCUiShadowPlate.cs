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

    private static IL2Field fieldMainText = null;
    public Text mainText
    {
        get
        {
            if (!IL2Get.Field("mainText", Instance_Class, ref fieldMainText))
                return null;

            return fieldMainText.GetValue(ptr)?.Unbox<Text>();
        }
    }


    private static IL2Field fieldDropShadow = null;
    public Text dropShadow
    {
        get
        {
            if (!IL2Get.Field("dropShadow", Instance_Class, ref fieldDropShadow))
                return null;

            return fieldDropShadow.GetValue(ptr)?.Unbox<Text>();
        }
    }

    private static IL2Field fieldImage = null;
    public Image image
    {
        get
        {
            if (!IL2Get.Field("image", Instance_Class, ref fieldImage))
                return null;

            return fieldImage.GetValue(ptr)?.Unbox<Image>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCUiShadowPlate");
}
