using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2reflection;
using BlazeIL.il2generic;
using BlazeIL.il2cpp;
using VRC.Core;

public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public string[] specificListIds
    {
        get => Instance_Class.GetField(nameof(specificListIds)).GetValue(ptr).unbox_ToArray_String();
        set => Instance_Class.GetField(nameof(specificListIds)).SetValue(ptr, value.Select(x => new IL2String(x).ptr).ToArray().ArrayToIntPtr());
    }

    public Category category
    {
        get => Instance_Class.GetField(nameof(category)).GetValue(ptr).unbox_Unmanaged<Category>();
        set => Instance_Class.GetField(nameof(category)).SetValue(ptr, value.MonoCast());
    }

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

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("UiAvatarList");
}