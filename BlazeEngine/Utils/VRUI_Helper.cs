/*
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using NET_SDK.Reflection;

public static class VRUI_Helper
{
    private static IL2CPP_Field fieldCategory;
    private static IL2CPP_Field fieldCachedSpecificList;

    public static UiAvatarList AddNewList(string title, int index)
    {
        UiAvatarList[] uiAvatarLists = Resources.FindObjectsOfTypeAll<UiAvatarList>();

        if (uiAvatarLists.Length == 0)
        {
            return null;
        }

        UiAvatarList gameFavList = null;
        foreach (UiAvatarList list in uiAvatarLists)
        {
            if (list.name.Contains("Favorite") && !list.name.Contains("Quest"))
            {
                gameFavList = list;
                break;
            }
        }
        if (gameFavList == null)
        {
            return null;
        }
        UiAvatarList newList = GameObject.Instantiate<UiAvatarList>(gameFavList, gameFavList.transform.parent);

        newList.GetComponentInChildren<Button>(true).GetComponentInChildren<Text>().text = title;
        newList.gameObject.SetActive(true);

        newList.transform.SetSiblingIndex(index);

        if (fieldCategory == null)
        {
            fieldCategory = UiAvatarList.Instance_Class.GetField("category");
        }
        if (fieldCategory == null)
            return null;


        IntPtr intPointer = IntPtr.Zero;
        try
        {
            intPointer = Marshal.AllocHGlobal(sizeof(int));
            Marshal.WriteInt32(intPointer, 4);
            fieldCategory.SetValue(newList.ptr, intPointer);
        }
        finally
        {
            Marshal.FreeHGlobal(intPointer);
        }

        return newList;
    }

    public static void ClearSpecificList(this UiAvatarList list)
    {
        if (fieldCachedSpecificList == null)
        {
            IL2CPP_Field[] npInstFields = UiAvatarList.Instance_Class.GetFields(IL2CPP_BindingFlags.FIELD_PRIVATE);
            foreach (IL2CPP_Field fi in npInstFields)
            {
                if (fi.GetReturnType().Name == "System.Collections.Generic.Dictionary<string, ApiAvatar>")
                {
                    fieldCachedSpecificList = fi;
                    break;
                }
            }
        }
        if (fieldCachedSpecificList == null)
            return;

        Console.WriteLine("I Cleaned field cached");
        // ((Dictionary<string, ApiAvatar>)fieldCachedSpecificList.GetValue(list)).Clear();
        // list.ClearAll();
    }
}
*/