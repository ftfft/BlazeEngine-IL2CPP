using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class UiTooltip : Component
{
    public UiTooltip(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Field fieldText = null;
    public string text
    {
        get
        {
            if (fieldText == null)
            {
                fieldText = Instance_Class.GetField("text");
                if (fieldText == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldText.GetValue(ptr);
            if (result == null)
                return null;

            return result.UnboxString();
        }
        set
        {
            if (fieldText == null)
            {
                fieldText = Instance_Class.GetField("text");
                if (fieldText == null)
                    return;
            }

            fieldText.SetValue(ptr, IL2Import.StringToIntPtr(value));
        }
    }

    private static IL2Field fieldAlternateText = null;
    public string alternateText
    {
        get
        {
            if (fieldAlternateText == null)
            {
                fieldAlternateText = Instance_Class.GetField("alternateText");
                if (fieldAlternateText == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldAlternateText.GetValue(ptr);
            if (result == null)
                return null;

            return result.UnboxString();
        }
        set
        {
            if (fieldAlternateText == null)
            {
                fieldAlternateText = Instance_Class.GetField("alternateText");
                if (fieldAlternateText == null)
                    return;
            }

            fieldAlternateText.SetValue(ptr, IL2Import.StringToIntPtr(value));
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(UiTooltip))
            return false;
        return ((UiTooltip)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiTooltip");
}
