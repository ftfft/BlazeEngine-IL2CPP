using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

public class QuickMenu : Component
{
    public QuickMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static QuickMenu Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Instance_Class.FullName);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<QuickMenu>();
        }
    }

    private static IL2Property propertySelectedUser = null;
    public APIUser SelectedUser
    {
        get
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName);
                if (propertySelectedUser == null)
                    return null;
            }

            return propertySelectedUser.GetGetMethod().Invoke(ptr)?.Unbox<APIUser>();
        }
        set
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName);
                if (propertySelectedUser == null)
                    return;
            }

            propertySelectedUser.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }
    }

    private static IL2Field fieldCurrentMenu = null;
    public GameObject _currentMenu
    {
        get
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.Token == 0xF0);
                if (fieldCurrentMenu == null)
                    return null;
            }
            return fieldCurrentMenu.GetValue(ptr)?.Unbox<GameObject>();
        }
        set
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.Token == 0xF0);
                if (fieldCurrentMenu == null)
                    return;
            }
            fieldCurrentMenu.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("QuickMenu");
}
