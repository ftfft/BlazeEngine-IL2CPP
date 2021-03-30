using System;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _UiAvatarList_Update(IntPtr instance);
    public static class patch_AvatarTools
    {
        public static void Start()
        {
            try
            {
                IL2Method method = UiAvatarList.Instance_Class.GetMethod("Update");

                if (method == null)
                    new Exception();

                var patch = IL2Ch.Patch(method, (_UiAvatarList_Update)UiAvatarList_Update);
                _delegateUiAvatarList_Update = patch.CreateDelegate<_UiAvatarList_Update>();
                Dll_Loader.success_Patch.Add("Avatar Tools");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("Avatar Tools");
            }
        }

        public static void UiAvatarList_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            _delegateUiAvatarList_Update.Invoke(instance);
            Avatars.UIAvatar.Update();
        }

        public static _UiAvatarList_Update _delegateUiAvatarList_Update;
    }
}
