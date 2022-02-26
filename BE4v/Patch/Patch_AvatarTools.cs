using System;
using BE4v.Mods;
using BE4v.Mods.Avatars;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    public delegate void _UiAvatarList_Update(IntPtr instance);
    public static class Patch_AvatarTools
    {
        public static void Start()
        {
            try
            {
                IL2Method method = UiAvatarList.Instance_Class.GetMethod("Update");

                if (method == null)
                    new Exception();

                _patch = new IL2Patch(method, (_UiAvatarList_Update)UiAvatarList_Update);
                _delegateUiAvatarList_Update = _patch.CreateDelegate<_UiAvatarList_Update>();
                "Unlimited Favorites".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Unlimited Favorites".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void UiAvatarList_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            _delegateUiAvatarList_Update(instance);
            Mod_Avatars.Update();
        }

        public static IL2Patch _patch;

        public static _UiAvatarList_Update _delegateUiAvatarList_Update;
    }
}
