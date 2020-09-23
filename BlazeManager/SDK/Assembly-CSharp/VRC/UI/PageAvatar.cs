using System;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.UI
{
    public class PageAvatar : Component
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal avatar
        {
            get
            {
                if (!IL2Get.Field("avatar", Instance_Class, ref f_avatar))
                    return default;

                return f_avatar.GetValue(ptr)?.Unbox<SimpleAvatarPedestal>();
            }
            set
            {
                if (!IL2Get.Field("avatar", Instance_Class, ref f_avatar))
                    return;

                f_avatar.SetValue(ptr, value.ptr);
            }
        }

        private static IL2Field f_avatar;

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageAvatar", "VRC.UI");
    }
}