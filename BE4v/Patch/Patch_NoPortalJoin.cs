using System;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.MenuEdit;

namespace BE4v.Patch
{
    public delegate void _PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider);
    public static class Patch_NoPortalJoin
    {
        public static void Toggle()
        {
            Status.isNoPortalJoin = !Status.isNoPortalJoin;
            ClickClass_NoPortalJoin.OnClick_NoPortalJoin_Refresh();
        }

        public static void Start()
        {
            try
            {
                IL2Method method = PortalTrigger.Instance_Class.GetMethod("OnTriggerEnter");
                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_PortalTrigger_OnTriggerEnter)PortalTrigger_OnTriggerEnter);
                _delegatePortalTrigger_OnTriggerEnter = patch.CreateDelegate<_PortalTrigger_OnTriggerEnter>();
                "No Portal Join".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "No Portal Join".RedPrefix(TMessage.BadPatch);
            }
        }

        public static void PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider)
        {
            if (instance == IntPtr.Zero)
                return;

            if (Status.isNoPortalJoin)
                return;

            _delegatePortalTrigger_OnTriggerEnter.Invoke(instance, collider);
        }

        public static IL2Patch patch;

        public static _PortalTrigger_OnTriggerEnter _delegatePortalTrigger_OnTriggerEnter;

    }
}
