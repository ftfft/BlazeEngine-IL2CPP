using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace VRC.UI
{
    public class PageAvatar : VRCUiPage
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public PageAvatar() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public SimpleAvatarPedestal avatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(SimpleAvatarPedestal.Instance_Class)).Name = nameof(avatar);
                return field.GetValue(ptr)?.GetValue<SimpleAvatarPedestal>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(SimpleAvatarPedestal.Instance_Class)).Name = nameof(avatar);
                field.SetValue(ptr, value.ptr);
            }
        }

        public void ChangeToSelectedAvatar()
        {
            Instance_Class.GetMethod(nameof(ChangeToSelectedAvatar)).Invoke(ptr);
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ChangeToSelectedAvatar") != null);
    }
}
