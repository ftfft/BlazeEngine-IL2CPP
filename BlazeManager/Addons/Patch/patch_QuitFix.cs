using System;
using System.Diagnostics;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _VRCApplication_OnApplicationQuit();
    public static class patch_QuitFix
    {
        public static void Start()
        {

            try
            {
                IL2Method method = VRCApplication.Instance_Class.GetMethod("OnApplicationQuit");
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_VRCApplication_OnApplicationQuit)VRCApplication_OnApplicationQuit);
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("Fast Quit");
            }
        }

        public static void VRCApplication_OnApplicationQuit()
        {
            try
            {
                BlazeManager.SaveSettings();
            }
            finally
            {
                Process.GetCurrentProcess().Kill();
            }
        }

    }
}
