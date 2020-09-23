#if (DEBUG)
using System;
using System.Linq;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class UiVRCList : Component
{
    public UiVRCList(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public void Refresh()
    {
        Refresh(currentPage);
    }

    private static IL2Method methodRefresh = null;
    public void Refresh(int pageIndex)
    {
        if (methodRefresh == null)
        {
            foreach (IL2Method method in Instance_Class.GetMethods())
            {
                if (method.HasFlag(IL2BindingFlags.METHOD_STATIC))
                    continue;

                if (method.HasFlag(IL2BindingFlags.METHOD_ABSTRACT))
                {
                    if (method.GetReturnType().Name != "System.Void")
                        continue;

                    if (method.GetParameters().Length != 1)
                        continue;

                    if (IL2Import.il2cpp_type_get_name(method.GetParameters()[0].ptr) != "System.Int32")
                        continue;

                    methodRefresh = method;
                    break;
                }
            }
            if (methodRefresh == null)
                return;
        }
        if (ptr == IntPtr.Zero)
            return;

        methodRefresh.Invoke(ptr, new IntPtr[] { new IntPtr(&pageIndex) });
    }

    private static IL2Field fieldCurrentPage = null;
    public int currentPage
    {
        get
        {
            if (fieldCurrentPage == null)
            {
                fieldCurrentPage = Instance_Class.GetField("currentPage");
                if (fieldCurrentPage == null)
                    return -1;
            }

            return *(int*)fieldCurrentPage.GetValue(ptr).Unbox();
        }
        set
        {
            if (fieldCurrentPage == null)
            {
                fieldCurrentPage = Instance_Class.GetField("currentPage");
                if (fieldCurrentPage == null)
                    return;
            }

            fieldCurrentPage.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Field fieldExtendRows = null;
    public int extendRows
    {
        get
        {
            if (fieldExtendRows == null)
            {
                fieldExtendRows = Instance_Class.GetField("extendRows");
                if (fieldExtendRows == null)
                    return -1;
            }

            return *(int*)fieldExtendRows.GetValue(ptr).Unbox();
        }
        set
        {
            if (fieldExtendRows == null)
            {
                fieldExtendRows = Instance_Class.GetField("extendRows");
                if (fieldExtendRows == null)
                    return;
            }

            fieldExtendRows.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Field fieldExpandedHeight = null;
    public float expandedHeight
    {
        get
        {
            if (fieldExpandedHeight == null)
            {
                fieldExpandedHeight = Instance_Class.GetField("expandedHeight");
                if (fieldExpandedHeight == null)
                    return -1;
            }

            return *(float*)fieldExpandedHeight.GetValue(ptr).Unbox();
        }
        set
        {
            if (fieldExpandedHeight == null)
            {
                fieldExpandedHeight = Instance_Class.GetField("expandedHeight");
                if (fieldExpandedHeight == null)
                    return;
            }

            fieldExpandedHeight.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Method methodClearAll = null;
    public void ClearAll()
    {
        if (methodClearAll == null)
        {
            methodClearAll = Instance_Class.GetMethods()
                .Where(x => x.GetReturnType().Name == "System.Void")
                .Where(x => !x.HasFlag(IL2BindingFlags.METHOD_STATIC))
                .Where(x => x.GetParameters().Length == 0)
                .Where(x => x.Name.Length > 20)
                .First(x => x.HasFlag(IL2BindingFlags.METHOD_PUBLIC));
            if (methodClearAll == null)
                return;
        }
        methodClearAll.Invoke(ptr);
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(UiTooltip))
            return false;
        return ((UiTooltip)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();



    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiVRCList");
}
#endif