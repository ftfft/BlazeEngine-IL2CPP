using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

public class HighlightsFXStandalone : HighlightsFX
{
    public HighlightsFXStandalone(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public HighlightsFXStandalone() : base(IntPtr.Zero)
    {
        ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
        Instance_Class.GetMethod(".ctor").Invoke(ptr);
    }

    unsafe public Color highlightColor
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(highlightColor));
            if (field == null)
                (field = Instance_Class.GetField(Color.Instance_Class)).Name = nameof(highlightColor);

            return field.GetValue(ptr).GetValuе<Color>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(highlightColor));
            if (field == null)
                (field = Instance_Class.GetField(Color.Instance_Class)).Name = nameof(highlightColor);

            field.SetValue(ptr, new IntPtr(&value));
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPreRender") != null && x.BaseType.FullName != MonoBehaviour.Instance_Class.FullName);
}
