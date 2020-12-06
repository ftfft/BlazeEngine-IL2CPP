using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

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

    public void Refresh(int pageIndex)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(Refresh));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.IsAbstract && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName)).Name = nameof(Refresh);

        method?.Invoke(ptr, new IntPtr[] { pageIndex.MonoCast() }, true);
    }

    public int currentPage
    {
        get => Instance_Class.GetField(nameof(currentPage)).GetValue(ptr).unbox_Unmanaged<int>();
        set => Instance_Class.GetField(nameof(currentPage)).SetValue(ptr, value.MonoCast());
    }

    public int extendRows
    {
        get => Instance_Class.GetField(nameof(extendRows)).GetValue(ptr).unbox_Unmanaged<int>();
        set => Instance_Class.GetField(nameof(extendRows)).SetValue(ptr, value.MonoCast());
    }

    public float expandedHeight
    {
        get => Instance_Class.GetField(nameof(expandedHeight)).GetValue(ptr).unbox_Unmanaged<float>();
        set => Instance_Class.GetField(nameof(expandedHeight)).SetValue(ptr, value.MonoCast());
    }

    public void ClearAll()
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ClearAll));
        if (method == null)
            (method = Instance_Class.GetMethod(x => !x.IsStatic && x.IsPublic && x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 0 && x.Name.Length > 20)).Name = nameof(ClearAll);
        method?.Invoke(ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiVRCList");
}