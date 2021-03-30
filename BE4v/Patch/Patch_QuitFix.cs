using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    public delegate void _VRCApplication_OnApplicationQuit();
    public static class Patch_QuitFix
    {
        public static void Start()
        {

            try
            {
                IL2Method method = VRCApplication.Instance_Class.GetMethod("OnApplicationQuit");
                if (method == null)
                    throw new Exception();

                new IL2Patch(method, (_VRCApplication_OnApplicationQuit)VRCApplication_OnApplicationQuit);
            }
            catch
            {
                // Dll_Loader.failed_Patch.Add("Fast Quit");
            }
        }

        public static void VRCApplication_OnApplicationQuit()
        {
            try
            {
                // BlazeManager.SaveSettings();
            }
            finally
            {
                Process.GetCurrentProcess().Kill();
            }
        }

    }
}
