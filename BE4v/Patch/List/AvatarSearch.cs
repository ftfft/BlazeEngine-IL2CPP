using System;
using System.Threading;
using BE4v.MenuEdit;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using BE4v.Mods;
using BE4v.Mods.API;
using VRC.Core;
using VRC.UI;

namespace BE4v.Patch.List
{
    public class AvatarSearch : IPatch
    {
        public delegate void _OnEnable(IntPtr instance);
        public delegate void _OnDisable(IntPtr instance);

        public void Start()
        {
            IL2Method method = PageAvatar.Instance_Class.GetMethod("OnEnable");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_OnEnable)OnEnable);
                __OnEnable = patch.CreateDelegate<_OnEnable>();
            }
            else
                throw new NullReferenceException("PageAvatar::OnEnable");

            method = PageAvatar.Instance_Class.GetMethod("OnDisable");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_OnDisable)OnDisable);
                __OnDisable = patch.CreateDelegate<_OnDisable>();
            }
            else
                throw new NullReferenceException("PageAvatar::OnDisable");
        }

        private static void OnEnable(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            __OnEnable(instance);
            "PageAvatar::OnEnable trigger ".RedPrefix("DEBUG");
        }
        private static void OnDisable(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            __OnDisable(instance);
            "PageAvatar::OnDisable trigger ".RedPrefix("DEBUG");
        }

        public static _OnEnable __OnEnable;
        public static _OnDisable __OnDisable;
    }
}
