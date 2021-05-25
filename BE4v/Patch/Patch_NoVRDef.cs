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
    public delegate void _PortalInternal_ConfigurePortal(IntPtr instance, IntPtr _roomId, IntPtr _idWithTags, int _playerCount, IntPtr instigator);
    public static class Patch_NoVRDef
    {
        public static void Start()
        {/*
            try
            {
                IL2Method method = PortalInternal.Instance_Class.GetMethod("ConfigurePortal", x => x.GetParameters().Length == 4);
                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_PortalInternal_ConfigurePortal)PortalInternal_ConfigurePortal);
                _delegatePortalInternal_ConfigurePortal = patch.CreateDelegate<_PortalInternal_ConfigurePortal>();
                "No VR Def".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "No VR Def".RedPrefix(TMessage.BadPatch);
            }
            */
        }

        public static void PortalInternal_ConfigurePortal(IntPtr instance, IntPtr _roomId, IntPtr _idWithTags, int _playerCount, IntPtr instigator)
        {
            // _delegateVector3Extensions_IsBad.Invoke(vec);
        }

        public static IL2Patch patch;

        public static _PortalInternal_ConfigurePortal _delegatePortalInternal_ConfigurePortal;

    }
}
