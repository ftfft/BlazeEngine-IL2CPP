using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.Core;

namespace VRC.UI
{
    public class PageUserInfo : VRCUiPage
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public PageUserInfo() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public APIUser user
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                return field.GetValue(ptr)?.GetValue<APIUser>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                {
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
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

        public void InitiateVoteToKick()
        {
            Instance_Class.GetMethod(nameof(InitiateVoteToKick)).Invoke(ptr);
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("RequestInvitation");
    }
}
