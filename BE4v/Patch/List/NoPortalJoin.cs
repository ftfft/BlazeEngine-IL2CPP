using System;
using System.Reflection;
using System.Linq;
using System.Text;
using UnityEngine;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.MenuEdit;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class NoPortalJoin : IPatch
    {
        public delegate void _PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider);
        public static void Toggle()
        {
            Status.isNoPortalJoin = !Status.isNoPortalJoin;
            ClickClass_NoPortalJoin.OnClick_NoPortalJoin_Refresh();
        }

        public void Start()
        {
            IL2Method method = PortalTrigger.Instance_Class.GetMethod("OnTriggerEnter");
            if (method != null)
            {
                patch = new IL2Patch(method, (_PortalTrigger_OnTriggerEnter)PortalTrigger_OnTriggerEnter);
                _delegatePortalTrigger_OnTriggerEnter = patch.CreateDelegate<_PortalTrigger_OnTriggerEnter>();
            }
            else
                throw new NullReferenceException();
        }

        public static void PortalTrigger_OnTriggerEnter(IntPtr instance, IntPtr collider)
        {
            if (instance == IntPtr.Zero)
                return;

            if (Status.isNoPortalJoin)
                return;

            _delegatePortalTrigger_OnTriggerEnter(instance, collider);
        }

        public static IL2Patch patch;

        public static _PortalTrigger_OnTriggerEnter _delegatePortalTrigger_OnTriggerEnter;

    }
}
