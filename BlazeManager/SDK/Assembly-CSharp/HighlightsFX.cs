using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;

// PostEffectsBase -> MonoBehaviour
public class HighlightsFX : MonoBehaviour
{
    public HighlightsFX(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static HighlightsFX Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.Instance);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<HighlightsFX>();
        }
    }

    private static IL2Method methodEnableOutline = null;
    public void EnableOutline(Renderer renderer, bool isEnabled)
    {
        if (methodEnableOutline == null)
        {
            methodEnableOutline = Instance_Class.GetMethods().First(x => x.GetParameters().Length == 2 && !x.HasFlag(IL2BindingFlags.METHOD_STATIC));
            if (methodEnableOutline == null)
                return;
        }

        methodEnableOutline.Invoke(ptr, new IntPtr[] { renderer.ptr, isEnabled.MonoCast() });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("HighlightsFX");
}