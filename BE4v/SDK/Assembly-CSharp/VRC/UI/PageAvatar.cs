using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.UI
{
    public class PageAvatar : VRCUiPage
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal avatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == SimpleAvatarPedestal.Instance_Class.FullName)).Name = nameof(avatar);
                return field.GetValue(ptr)?.GetValue<SimpleAvatarPedestal>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == SimpleAvatarPedestal.Instance_Class.FullName)).Name = nameof(avatar);
                field.SetValue(ptr, value.ptr);
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ChangeToSelectedAvatar") != null);
    }
}
