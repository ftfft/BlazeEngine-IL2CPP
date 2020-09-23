using System;
using BlazeIL;
using BlazeIL.il2cpp;
using VRC.Core;

public class MenuController : UnityEngine.Object
{
    public MenuController(IntPtr newPtr) : base(newPtr) =>
        ptr = newPtr;


    private static IL2Field fieldActiveUser = null;
    public APIUser activeUser
    {
        get
        {
            if (fieldActiveUser == null)
            {
                fieldActiveUser = Instance_Class.GetField("activeUser");
                if (fieldActiveUser == null)
                    return null;
            }

            IL2Object result = null;
            result = fieldActiveUser.GetValue(ptr);
            if (result == null)
                return null;

            return result.ptr.MonoCast<APIUser>();
        }
        set
        {
            if (fieldActiveUser == null)
            {
                fieldActiveUser = Instance_Class.GetField("activeUser");
                if (fieldActiveUser == null)
                    return;
            }
            fieldActiveUser.SetValue(ptr, value.ptr);
        }
    }
    private static IL2Field fieldActiveAvatar = null;
    public ApiAvatar activeAvatar
    {
        get
        {
            if (fieldActiveAvatar == null)
            {
                fieldActiveAvatar = Instance_Class.GetField("activeAvatar");
                if (fieldActiveAvatar == null)
                    return null;
            }
            var result = fieldActiveAvatar.GetValue(ptr);
            if (result == null)
                return null;

            return result.ptr.MonoCast<ApiAvatar>();
        }
        set
        {
            if (fieldActiveAvatar == null)
            {
                fieldActiveAvatar = Instance_Class.GetField("activeAvatar");
                if (fieldActiveAvatar == null)
                    return;
            }
            fieldActiveAvatar.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("MenuController");
}
