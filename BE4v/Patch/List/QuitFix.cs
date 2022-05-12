using System;
using System.Diagnostics;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class QuitFix : IPatch
    {
        public delegate void _VRCApplication_OnApplicationQuit();
        public void Start()
        {
            IL2Method method = VRCApplication.Instance_Class.GetMethod("OnApplicationQuit");
            if (method != null)
            {
                new IL2Patch(method, (_VRCApplication_OnApplicationQuit)VRCApplication_OnApplicationQuit);
            }
            else
                throw new NullReferenceException();
        }

        public static void VRCApplication_OnApplicationQuit()
        {
            try
            {
                BVault.Save();
            }
            finally
            {
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                Process.GetCurrentProcess().Kill();
            }
        }

    }
}
