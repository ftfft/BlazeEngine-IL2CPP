using System;
using BE4v.SDK.CPP2IL;
using VRC.Core;
using UnityEngine;

public class MenuController : ScriptableObject
{
    public MenuController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public APIUser activeUser
    {
        get => Instance_Class.GetField(nameof(activeUser)).GetValue(ptr)?.GetValue<APIUser>();
        set => Instance_Class.GetField(nameof(activeUser)).SetValue(ptr, value.ptr);
    }
    
    public ApiAvatar activeAvatar
    {
        get => Instance_Class.GetField(nameof(activeAvatar)).GetValue(ptr)?.GetValue<ApiAvatar>();
        set => Instance_Class.GetField(nameof(activeAvatar)).SetValue(ptr, value.ptr);
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("MenuController");
}
