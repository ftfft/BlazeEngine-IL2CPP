using System;
using BlazeIL.il2cpp;

namespace VRC.UI
{
    public class PageAvatar : VRCUiPage
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal avatar
        {
            get => Instance_Class.GetField(nameof(avatar)).GetValue(ptr)?.unbox<SimpleAvatarPedestal>();
            set => Instance_Class.GetField(nameof(avatar)).SetValue(ptr, value.ptr);
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageAvatar", "VRC.UI");
    }
}