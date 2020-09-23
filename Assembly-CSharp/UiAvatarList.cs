using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2generic;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


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

    private static IL2Field fieldSpecificListIds = null;
    public string[] specificListIds
    {
        get
        {
            if (!Execute.CheckOrSetField("specificListIds", Instance_Class, ref fieldSpecificListIds))
                return default;

            IL2Object result = fieldSpecificListIds.GetValue(ptr);
            if (result == null)
                return default;

            return result.UnboxArrayString();
        }
        set
        {
            if (!Execute.CheckOrSetField("specificListIds", Instance_Class, ref fieldSpecificListIds))
                return;

            List<IntPtr> list = new List<IntPtr>();
            foreach(string text in value)
                list.Add(IL2Import.il2cpp_string_new(text));

            fieldSpecificListIds.SetValue(ptr, list.ToArray().ArrayToIntPtr());
        }
    }

    private static IL2Field fieldCategory = null;
    public Category category
    {
        get
        {
            if (!Execute.CheckOrSetField("category", Instance_Class, ref fieldCategory))
                return default;

            IL2Object result = fieldCategory.GetValue(ptr);
            if (result == null)
                return default;

            return *(Category*)result.Unbox();
        }
        set
        {
            if (!Execute.CheckOrSetField("category", Instance_Class, ref fieldCategory))
                return;

            fieldCategory.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Field fieldCacheSpecificList = null;
    public IL2Dictionary cacheSpecificList
    {
        get
        {
            if (fieldCacheSpecificList == null)
            {
                fieldCacheSpecificList = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "System.Collections.Generic.Dictionary<System.String,VRC.Core.ApiAvatar>");
                if (fieldCacheSpecificList == null)
                    return default;
            }
            IL2Object result = fieldCacheSpecificList.GetValue(ptr);
            if (result == null)
                return default;

            return result.ptr.MonoCast<IL2Dictionary>();
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(UiAvatarList))
            return false;
        return ((UiAvatarList)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();



    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiAvatarList");
}