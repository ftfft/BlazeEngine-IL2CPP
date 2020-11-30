using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

public class UiVRCList : Component
{
    public UiVRCList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public void Refresh()
    {
        Refresh(currentPage);
    }

    private static IL2Method methodRefresh = null;
    public void Refresh(int pageIndex)
    {
        if (methodRefresh == null)
        {
            methodRefresh = Instance_Class.GetMethods().First(x =>
                x.HasFlag(IL2BindingFlags.METHOD_ABSTRACT) &&
                x.GetParameters().Length == 1 &&
                x.GetParameters()[0].ReturnType.Name == typeof(int).FullName
            );
            if (methodRefresh == null)
                return;
        }

        methodRefresh.Invoke(ptr, new IntPtr[] { pageIndex.MonoCast() }, true);
    }

    private static IL2Field fieldCurrentPage = null;
    public int currentPage
    {
        get
        {
            if (!IL2Get.Field("currentPage", Instance_Class, ref fieldCurrentPage))
                return default;

            return fieldCurrentPage.GetValue(ptr).Unbox<int>();
        }
        set
        {
            if (!IL2Get.Field("currentPage", Instance_Class, ref fieldCurrentPage))
                return;

            fieldCurrentPage.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Field fieldExtendRows = null;
    public int extendRows
    {
        get
        {
            if (!IL2Get.Field("extendRows", Instance_Class, ref fieldExtendRows))
                return default;

            return fieldExtendRows.GetValue(ptr).Unbox<int>();
        }
        set
        {
            if (!IL2Get.Field("extendRows", Instance_Class, ref fieldExtendRows))
                return;

            fieldExtendRows.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Field fieldExpandedHeight = null;
    public float expandedHeight
    {
        get
        {
            if (!IL2Get.Field("expandedHeight", Instance_Class, ref fieldExpandedHeight))
                return default;

            return fieldExpandedHeight.GetValue(ptr).Unbox<float>();
        }
        set
        {
            if (!IL2Get.Field("expandedHeight", Instance_Class, ref fieldExpandedHeight))
                return;

            fieldExpandedHeight.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Method methodClearAll = null;
    public void ClearAll()
    {
        if (methodClearAll == null)
        {
            methodClearAll = Instance_Class.GetMethods()
                .Where(x => x.ReturnType.Name == "System.Void")
                .Where(x => !x.HasFlag(IL2BindingFlags.METHOD_STATIC))
                .Where(x => x.GetParameters().Length == 0)
                .Where(x => x.Name.Length > 20)
                .First(x => x.HasFlag(IL2BindingFlags.METHOD_PUBLIC));
            if (methodClearAll == null)
                return;
        }
        methodClearAll.Invoke(ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiVRCList");
}