using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using VRC.Core;

namespace VRC.UI
{
    public class PageUserInfo : VRCUiPage
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public APIUser user
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                return field.GetValue(ptr)?.GetValue<APIUser>();
            }
        }

        public static PageUserInfo Instance
        {
            get => VRCUiManager.GetPage<PageUserInfo>(userInfoScreenPath);
        }

        public static string userInfoScreenPath
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(userInfoScreenPath));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.IsStatic && x.ReturnType.Name == typeof(string).FullName && x.GetValue()?.GetValue<string>()?.StartsWith("UserInterface") == true)).Name = nameof(userInfoScreenPath);
                return field.GetValue()?.GetValue<string>();
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("RequestInvitation");
    }
}
