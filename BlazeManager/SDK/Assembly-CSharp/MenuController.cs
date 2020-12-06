using System;
using BlazeIL.il2cpp;
using VRC.Core;

public class MenuController : UnityEngine.Object
{
    public MenuController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public APIUser activeUser
    {
        get => Instance_Class.GetField(nameof(activeUser)).GetValue(ptr)?.unbox<APIUser>();
        set => Instance_Class.GetField(nameof(activeUser)).SetValue(ptr, value.ptr);
    }
    
    public ApiAvatar activeAvatar
    {
        get => Instance_Class.GetField(nameof(activeAvatar)).GetValue(ptr)?.unbox<ApiAvatar>();
        set => Instance_Class.GetField(nameof(activeAvatar)).SetValue(ptr, value.ptr);
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("MenuController");
}
