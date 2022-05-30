using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using VRC.Core;

public abstract class UiVRCList : MonoBehaviour
{
    public UiVRCList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    static UiVRCList()
    {
        // 
        // Find: protected abstract void FetchAndRenderElements(int page);
        // 
        Instance_Class.GetMethod(x => x.IsAbstract && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName).Name = nameof(FetchAndRenderElements);

        // 
        // Find: protected void StartRenderElementsCoroutine<T>(List<T> list, int offset = 0, bool endOfPickers = true, [Optional] VRCUiContentButton contentHeaderElement)
        // 
        Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName
            && x.GetParameters().Length == 4
            && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName
            && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName
            ).Name = nameof(StartRenderElementsCoroutine);
    }

    public void Refresh()
    {
        FetchAndRenderElements(currentPage);
    }

    public void FetchAndRenderElements(int page)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiVRCList::FetchAndRenderElements");
            return;
        }
        unsafe
        {
            method.Invoke(ptr, new IntPtr[] { new IntPtr(&page) }, true);
        }
    }
    
    public void StartRenderElementsCoroutine<T>(IL2List<T> list, int offset = 0, bool endOfPickers = true, VRCUiContentButton contentHeaderElement = null)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiVRCList::StartRenderElementsCoroutine");
            return;
        }
        unsafe
        {
            method.Invoke(ptr, new IntPtr[] { list == null ? IntPtr.Zero : list.ptr, new IntPtr(&offset), new IntPtr(&endOfPickers), contentHeaderElement == null ? IntPtr.Zero : contentHeaderElement.ptr, Instance_Class.GetMethod(nameof(StartRenderElementsCoroutine)).ptr }, true);
        }
    }

    // Alternative
    public void ClearList()
    {
        int count = pickers.IL2ToArray().Length;
        ClearListRange(0, count);
    }

    unsafe public void ClearListRange(int offset, int count)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ClearListRange));
        if (method == null)
        {
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 2
                && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName
                && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName
            )).Name = nameof(ClearListRange);
            if (method == null)
                return;
        }
        method.Invoke(ptr, new IntPtr[] { new IntPtr(&offset), new IntPtr(&count) });
    }

    unsafe public int currentPage
    {
        get => Instance_Class.GetField(x => x.Token == 0xC4).GetValue(ptr).GetValuе<int>();
        set => Instance_Class.GetField(x => x.Token == 0xC4).SetValue(ptr, new IntPtr(&value));
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
    
    public IL2List<VRCUiContentButton> pickers
    {
        get
        {
            IL2Object result = Instance_Class.GetField(nameof(pickers)).GetValue(ptr);
            if (result == null)
                return null;

            return new IL2List<VRCUiContentButton>(result.ptr);
        }
        set => Instance_Class.GetField(nameof(pickers)).SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
    }


    public IL2Dictionary<int, IL2List<ApiModel>> paginatedLists
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(paginatedLists));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary<" + typeof(int).FullName + ","))).Name = nameof(paginatedLists);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::paginatedLists");
                    return null;
                }
            }
            IL2Object result = field.GetValue(ptr);
            if (result == null)
                return null;
            return new IL2Dictionary<int, IL2List<ApiModel>>(result.ptr);
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(UiAvatarList.Instance_Class.BaseType.FullName);
}