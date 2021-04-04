using BE4v.SDK.CPP2IL;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserInteractMenu : MonoBehaviour
{
    public UserInteractMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public Text cloneAvatarButtonText
    {
        get => Instance_Class.GetField(Text.Instance_Class).GetValue(ptr)?.GetValue<Text>();
        set => Instance_Class.GetField(Text.Instance_Class).SetValue(ptr, value.ptr);
    }

    public MenuController menuController
    {
        get => Instance_Class.GetField(MenuController.Instance_Class).GetValue(ptr)?.GetValue<MenuController>();
        set => Instance_Class.GetField(MenuController.Instance_Class).SetValue(ptr, value.ptr);
    }
    
    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetFields(y => y.ReturnType.Name == Button.Instance_Class.FullName).Length == 3 && x.GetField(MenuController.Instance_Class) != null);
}
