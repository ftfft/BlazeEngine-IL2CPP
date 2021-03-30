using System;
using System.Threading;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using BlazeWebAPI;

namespace Addons.Patch
{
    // public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, IntPtr authenticationRequired, IntPtr disableCache, IntPtr cacheLifetime, IntPtr retryCount, IntPtr credentials);
    public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData);
    public static class patch_InvisAPI
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("Invis API", !BlazeManager.GetForPlayer<bool>("Invis API"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Invis API");
            BlazeManagerMenu.Main.togglerList["Invis API"].SetToggleToOn(toggle, false);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = VRC.Core.API.Instance_Class.GetMethod("SendRequestInternal");
                if (method == null)
                    throw new Exception();

                var patch = IL2Ch.Patch(method, (_VRC_Core_API_SendRequestInternal)VRC_Core_API_SendRequestInternal);
                _delegateVRC_Core_API_SendRequestInternal = patch.CreateDelegate<_VRC_Core_API_SendRequestInternal>();
                Dll_Loader.success_Patch.Add("InvisAPI");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("InvisAPI");
            }
        }

        private static void VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData)
        {
            string point = new IL2String(endpoint).ToString();
            new Thread(() =>
            {
                new WebRequest(point);
            });

            if ((point == "visits" || point == "joins" || (point.StartsWith("avatars/avtr_") && point.EndsWith("/select"))) && BlazeManager.GetForPlayer<bool>("Invis API"))
                return;

            _delegateVRC_Core_API_SendRequestInternal.Invoke(
                endpoint,
                method,
                responseContainer,
                requestParams,
                authenticationRequired,
                disableCache,
                cacheLifetime,
                retryCount,
                credentials,
                formData
            );
        }

        public static _VRC_Core_API_SendRequestInternal _delegateVRC_Core_API_SendRequestInternal;
    }
}
