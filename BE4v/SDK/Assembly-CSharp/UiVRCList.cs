using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public abstract class UiVRCList : MonoBehaviour
{
    public UiVRCList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public void Refresh()
    {
        try
        {
            Refresh(currentPage);
        }
        catch { }
    }

    unsafe public void Refresh(int pageIndex)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(Refresh));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.IsAbstract && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName)).Name = nameof(Refresh);

        method?.Invoke(ptr, new IntPtr[] { new IntPtr(&pageIndex) }, true);
    }

    unsafe public int currentPage
    {
        get => Instance_Class.GetField(nameof(currentPage)).GetValue(ptr).GetValuе<int>();
        set => Instance_Class.GetField(nameof(currentPage)).SetValue(ptr, new IntPtr(&value));
    }

    unsafe public int extendRows
    {
        get => Instance_Class.GetField(nameof(extendRows)).GetValue(ptr).GetValuе<int>();
        set => Instance_Class.GetField(nameof(extendRows)).SetValue(ptr, new IntPtr(&value));
    }

    unsafe public float expandedHeight
    {
        get => Instance_Class.GetField(nameof(expandedHeight)).GetValue(ptr).GetValuе<float>();
        set => Instance_Class.GetField(nameof(expandedHeight)).SetValue(ptr, new IntPtr(&value));
    }

    public void ClearAll()
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ClearAll));
        if (method == null)
            (method = Instance_Class.GetMethod(x => !x.IsStatic && x.IsPublic && x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 0 && x.Name.Length > 10)).Name = nameof(ClearAll);
        method?.Invoke(ptr);
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType == MonoBehaviour.Instance_Class && x.GetMethod("ToggleExtend") != null);
}