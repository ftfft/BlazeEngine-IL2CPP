using System;
using System.Linq;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine.UI;

public class UserInteractMenu : UnityEngine.Object
{
    public UserInteractMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public Button cloneAvatarButton
    {
        get => Instance_Class.GetFields(x => x.ReturnType.Name == Button.Instance_Class.FullName).Skip(1).First().GetValue(ptr)?.unbox<Button>();
        set => Instance_Class.GetFields(x => x.ReturnType.Name == Button.Instance_Class.FullName).Skip(1).First().SetValue(ptr, value.ptr);
    }

    public Text cloneAvatarButtonText
    {
        get => Instance_Class.GetField(Text.Instance_Class).GetValue(ptr)?.unbox<Text>();
        set => Instance_Class.GetField(Text.Instance_Class).SetValue(ptr, value.ptr);
    }

    public MenuController menuController
    {
        get => Instance_Class.GetField(MenuController.Instance_Class).GetValue(ptr)?.unbox<MenuController>();
        set => Instance_Class.GetField(MenuController.Instance_Class).SetValue(ptr, value.ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetFields(y => y.ReturnType.Name == Button.Instance_Class.FullName).Length == 3 && x.GetFields(y => y.ReturnType.Name == MenuController.Instance_Class.FullName).Length == 1);
}
