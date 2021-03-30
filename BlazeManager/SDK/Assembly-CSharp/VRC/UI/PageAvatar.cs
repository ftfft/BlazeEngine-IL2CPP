using System;
using System.Linq;
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
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == SimpleAvatarPedestal.Instance_Class.FullName)).Name = nameof(avatar);
                return field.GetValue(ptr)?.unbox<SimpleAvatarPedestal>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(avatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == SimpleAvatarPedestal.Instance_Class.FullName)).Name = nameof(avatar);
                field.SetValue(ptr, value.ptr);
            }
        }

        public void ChangeToSelectedAvatar()
        {
            Instance_Class.GetMethod(nameof(ChangeToSelectedAvatar)).Invoke(ptr);
        }
        
        public void ChangeToSelectedAvatar2()
        {
            Instance_Class.GetMethod(nameof(ChangeToSelectedAvatar)).Invoke(ptr);
        }


        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetMethod("ChangeToSelectedAvatar") != null);
    }
}