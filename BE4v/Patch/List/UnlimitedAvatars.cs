using System;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class UnlimitedAvatars : IPatch
    {
        public delegate void _UiAvatarList_Update(IntPtr instance);
        public void Start()
        {
            IL2Method method = UiAvatarList.Instance_Class.GetMethod("Update");

            if (method != null)
            {
                _patch = new IL2Patch(method, (_UiAvatarList_Update)UiAvatarList_Update);
                _delegateUiAvatarList_Update = _patch.CreateDelegate<_UiAvatarList_Update>();
            }
            else
                throw new NullReferenceException();
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
