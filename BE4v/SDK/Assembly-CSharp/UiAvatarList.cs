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
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">")).Name = nameof(specificListValues);
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