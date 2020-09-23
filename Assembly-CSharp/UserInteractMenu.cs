using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using UnityEngine.UI;

public class UserInteractMenu : UnityEngine.Object
{
    public UserInteractMenu(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    private static IL2Field fieldCloneAvatarButton = null;
    public Button cloneAvatarButton
    {
        get
        {
            if (fieldCloneAvatarButton == null)
            {
                fieldCloneAvatarButton = Instance_Class.GetField("cloneAvatarButton");
                if (fieldCloneAvatarButton == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldCloneAvatarButton.GetValue(ptr);
            if (result == null)
                return null;

            return result.ptr.MonoCast<Button>();
        }
        set
        {
            if (fieldCloneAvatarButton == null)
            {
                fieldCloneAvatarButton = Instance_Class.GetField("cloneAvatarButton");
                if (fieldCloneAvatarButton == null)
                    return;
            }
            fieldCloneAvatarButton.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldCloneAvatarButtonText = null;
    public Text cloneAvatarButtonText
    {
        get
        {
            if (fieldCloneAvatarButtonText == null)
            {
                fieldCloneAvatarButtonText = Instance_Class.GetField("cloneAvatarButtonText");
                if (fieldCloneAvatarButtonText == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldCloneAvatarButtonText.GetValue(ptr);
            if (result == null)
                return null;

            return result.ptr.MonoCast<Text>();
        }
        set
        {
            if (fieldCloneAvatarButtonText == null)
            {
                fieldCloneAvatarButtonText = Instance_Class.GetField("cloneAvatarButtonText");
                if (fieldCloneAvatarButtonText == null)
                    return;
            }
            fieldCloneAvatarButtonText.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldMenuController = null;
    public MenuController menuController
    {
        get
        {
            if (fieldMenuController == null)
            {
                fieldMenuController = Instance_Class.GetField("menuController");
                if (fieldMenuController == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldMenuController.GetValue(ptr);
            if (result == null)
                return null;

            return result.ptr.MonoCast<MenuController>();
        }
        set
        {
            if (fieldMenuController == null)
            {
                fieldMenuController = Instance_Class.GetField("menuController");
                if (fieldMenuController == null)
                    return;
            }
            fieldMenuController.SetValue(ptr, value.ptr);
        }
    }
    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UserInteractMenu");
}
