using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine.UI;

public class UserInteractMenu : UnityEngine.Object
{
    public UserInteractMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public Button cloneAvatarButton
    {
        get => Instance_Class.GetField(nameof(cloneAvatarButton)).GetValue(ptr)?.unbox<Button>();
        set => Instance_Class.GetField(nameof(cloneAvatarButton)).SetValue(ptr, value.ptr);
    }

    public Text cloneAvatarButtonText
    {
        get => Instance_Class.GetField(nameof(cloneAvatarButtonText)).GetValue(ptr)?.unbox<Text>();
        set => Instance_Class.GetField(nameof(cloneAvatarButtonText)).SetValue(ptr, value.ptr);
    }

    public MenuController menuController
    {
        get => Instance_Class.GetField(nameof(menuController)).GetValue(ptr)?.unbox<MenuController>();
        set => Instance_Class.GetField(nameof(menuController)).SetValue(ptr, value.ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UserInteractMenu");
}
