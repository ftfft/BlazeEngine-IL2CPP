using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

public sealed class HighlightsFXStandalone : HighlightsFX
{
    public HighlightsFXStandalone(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static IL2Method constructHighlightsFXStandalone;
    public HighlightsFXStandalone() : base(IntPtr.Zero)
    {

        if (constructHighlightsFXStandalone == null)
        {
            constructHighlightsFXStandalone = Instance_Class.GetMethod(".ctor");
            if (constructHighlightsFXStandalone == null)
                return;
        }

        ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
        constructHighlightsFXStandalone.Invoke(ptr);
    }

    private static IL2Field field_highlightColor = null;
    public Color highlightColor
    {
        get
        {
            if (field_highlightColor == null)
            {
                field_highlightColor = Instance_Class.GetField(x => x.ReturnType.Name == Color.Instance_Class.FullName);
                if (field_highlightColor == null)
                    return default;
            }

            return field_highlightColor.GetValue(ptr).unbox_Unmanaged<Color>();
        }
        set
        {
            if (field_highlightColor == null)
            {
                field_highlightColor = Instance_Class.GetField(x => x.ReturnType.Name == Color.Instance_Class.FullName);
                if (field_highlightColor == null)
                    return;
            }

            field_highlightColor.SetValue(ptr, value.MonoCast());
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("HighlightsFXStandalone");
}