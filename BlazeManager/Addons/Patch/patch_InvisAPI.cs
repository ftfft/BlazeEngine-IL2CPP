using System;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using BlazeWebAPI;

namespace Addons.Patch
{
    public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, IntPtr authenticationRequired, IntPtr disableCache, IntPtr cacheLifetime, IntPtr retryCount, IntPtr credentials);
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
            BlazeManagerMenu.Main.togglerList["Invis API"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["Invis API"].btnOff.SetActive(!toggle);
        }

        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["VRCCore-Standalone"].GetClass("API", "VRC.Core").GetMethod("SendRequestInternal");
                if (method == null)
                    throw new Exception();

                pInvisMode = IL2Ch.Patch(method, (_VRC_Core_API_SendRequestInternal)VRC_Core_API_SendRequestInternal);
                ConSole.Success("Patch: InvisAPI");
            }
            catch
            {
                ConSole.Error("Patch: InvisAPI");
            }
        }

        private static void VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, IntPtr authenticationRequired, IntPtr disableCache, IntPtr cacheLifetime, IntPtr retryCount, IntPtr credentials)
        {
            string point = endpoint.MonoCast<string>();
            new WebRequest(point);

            if ((point == "visits" || point == "joins" || (point.StartsWith("avatars/avtr_") && point.EndsWith("/select"))) && BlazeManager.GetForPlayer<bool>("Invis API"))
                return;

            pInvisMode.InvokeOriginal(IntPtr.Zero, new IntPtr[] {
                endpoint,
                method,
                responseContainer,
                requestParams,
                authenticationRequired,
                disableCache,
                cacheLifetime,
                retryCount,
                credentials
            });
        }

        public static IL2Patch pInvisMode;
    }
}
