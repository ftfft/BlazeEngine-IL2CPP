using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;
using BE4v.Mods.Min;

namespace BE4v.Patch.List
{
    public class QuickMenu : IPatch
    {
        public delegate void _QuickMenu_OnEnable(IntPtr instance);
        public void Start()
        {

            try
            {
                IL2Method method = VRC.UI.Elements.QuickMenu.Instance_Class.GetMethod("OnEnable");
                if (method == null)
                    throw new NullReferenceException();
            
                patch = new IL2Patch(method, (_QuickMenu_OnEnable)QuickMenu_OnEnable);
                _delegateQuickMenu_OnEnable = patch.CreateDelegate<_QuickMenu_OnEnable>();

            }
            catch
            {
                "QuickMenu Edit".RedPrefix("Patch");
            }
        }

        public static void QuickMenu_OnEnable(IntPtr instance)
        {
            _delegateQuickMenu_OnEnable(instance);
            patch.Enabled = false;
            ModifyQuickMenu.isLoadedMenu = true;
        }

        public static IL2Patch patch;

        public static _QuickMenu_OnEnable _delegateQuickMenu_OnEnable;
    }
}
