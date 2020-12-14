using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.UI
{
    public class PageAvatar : VRCUiPage
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public PageAvatar() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor().Invoke(ptr);
        }

        public SimpleAvatarPedestal avatar
        {
            get => Instance_Class.GetField(nameof(avatar)).GetValue(ptr)?.unbox<SimpleAvatarPedestal>();
            set => Instance_Class.GetField(nameof(avatar)).SetValue(ptr, value.ptr);
        }

        public void ChangeToSelectedAvatar()
        {
            Instance_Class.GetMethod(nameof(ChangeToSelectedAvatar)).Invoke(ptr);
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PageAvatar", "VRC.UI");
    }
}