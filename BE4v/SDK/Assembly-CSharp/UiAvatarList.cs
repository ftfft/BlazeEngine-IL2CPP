using System;
using System.Linq;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    static UiAvatarList()
    {
        // Find: specificListIds
        Instance_Class.GetField(x => x.ReturnType.Name == "System.String[]").Name = nameof(specificListIds);
        // Find: category
        Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(Instance_Class.FullName)).Name = nameof(category);
        // Find Method: SingleAvatarAvailable
        Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == ApiContainer.Instance_Class.FullName).Name = nameof(SingleAvatarAvailable);
        // Find Method: FetchAndRenderElements(int page)
        IL2Method method = UiVRCList.Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        Instance_Class.GetMethod(method.OriginalName).Name = nameof(FetchAndRenderElements);
    }

    public new void Refresh()
    {
        FetchAndRenderElements(currentPage);
    }

    public new void FetchAndRenderElements(int page)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiAvatarList::FetchAndRenderElements");
            return;
        }
        unsafe
        {
            method.Invoke(ptr, new IntPtr[] { new IntPtr(&page) }, true);
        }
    }
    public void SingleAvatarAvailable(ApiContainer container)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(SingleAvatarAvailable));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiAvatarList::SingleAvatarAvailable");
            return;
        }
        method.Invoke(ptr, new IntPtr[] { container == null ? IntPtr.Zero : container.ptr });
    }

    public string[] specificListIds
    {
        get => Instance_Class.GetField(nameof(specificListIds)).GetValue(ptr).UnboxArray<string>();
        set => Instance_Class.GetField(nameof(specificListIds)).SetValue(ptr, value.Select(x => new IL2String(x).ptr).ArrayToIntPtr(IL2SystemClass.String));
    }

    unsafe public Category category
    {
        get => Instance_Class.GetField(nameof(category)).GetValue(ptr).GetValuе<Category>();
        set => Instance_Class.GetField(nameof(category)).SetValue(ptr, new IntPtr(&value));
    }
    
    public IL2Dictionary<string, ApiAvatar> specificListValues
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(specificListValues));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">")).Name = nameof(specificListValues);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::specificListValues");
                    return null;
                }
            }
            IL2Object result = field.GetValue(ptr);
            if (result == null)
                return null;
            return new IL2Dictionary<string, ApiAvatar>(result.ptr);
        }
    }
    
    public IL2HashSet HashSet_field
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(HashSet_field));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.HashSet"))).Name = nameof(HashSet_field);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::HashSet_field");
                    return null;
                }
            }
            IL2Object result = field.GetValue(ptr);
            if (result == null)
                return null;
            return new IL2HashSet(result.ptr);
        }
    }

    public enum Category
    {
        Internal,
        Public,
        Mine,
        Favorite,
        SpecificList,
        PublicQuest,
        Classic,
        Licensed,
        PublicFallback,
        MineFallback
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">") != null);
}