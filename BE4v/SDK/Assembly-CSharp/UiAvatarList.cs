using System;
using System.Linq;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public string[] specificListIds
    {
        get => Instance_Class.GetField(x => x.ReturnType.Name == "System.String[]").GetValue(ptr).UnboxArray<string>();
        set => Instance_Class.GetField(x => x.ReturnType.Name == "System.String[]").SetValue(ptr, value.Select(x => new IL2String(x).ptr).ArrayToIntPtr(IL2SystemClass.String));
    }

    unsafe public Category category
    {
        get => Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(Instance_Class.FullName)).GetValue(ptr).GetValuе<Category>();
        set => Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(Instance_Class.FullName)).SetValue(ptr, new IntPtr(&value));
    }

    /*
    public IL2Dictionary<string, ApiAvatar> specificListValues
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(specificListValues));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">")).Name = nameof(specificListValues);
            IL2Object result = field?.GetValue(ptr);
            if (result == null)
                return null;
            return new IL2Dictionary<string, ApiAvatar>(result.ptr);
        }
    }
    */

    public enum Category
    {
        Internal,
        Public,
        Mine,
        Favorite,
        SpecificList,
        PublicQuest,
        Classic,
        Licensed
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">") != null);
}