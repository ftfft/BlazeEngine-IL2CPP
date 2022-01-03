using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.UI.Elements;

namespace BE4v.Patch
{
    public delegate void _QuickMenu_OnEnable(IntPtr instance);
    public static class Patch_QuickMenuLoaded
    {
        public static void Start()
        {

            try
            {
                IL2Method method = QuickMenu.Instance_Class.GetMethod("OnEnable");
                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_QuickMenu_OnEnable)QuickMenu_OnEnable);
                if (patch != null)
                    _delegateQuickMenu_OnEnable = patch.CreateDelegate<_QuickMenu_OnEnable>();
            }
            catch
            {
                "QuickMenu Edit".RedPrefix("Patch");
            }
        }

        public static void QuickMenu_OnEnable(IntPtr instance)
        {
            _delegateQuickMenu_OnEnable.Invoke(instance);
            patch.Enabled = false;

            MenuEdit.BE4V_MainMenu.Delete();
        }

        public static IL2Patch patch;

        public static _QuickMenu_OnEnable _delegateQuickMenu_OnEnable;
    }
}
