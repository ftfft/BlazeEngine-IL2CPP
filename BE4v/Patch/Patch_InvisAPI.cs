using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    // public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, IntPtr authenticationRequired, IntPtr disableCache, IntPtr cacheLifetime, IntPtr retryCount, IntPtr credentials);
    public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData);
    public static class patch_InvisAPI
    {
        public static void Toggle_Enable()
        {
            Mods.Status.isInvisAPI = !Mods.Status.isInvisAPI;
            // RefreshStatus();
        }

        /*
        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("Invis API");
            BlazeManagerMenu.Main.togglerList["Invis API"].SetToggleToOn(toggle, false);
        }
        */
        public static void Start()
        {
            try
            {
                IL2Method method = VRC.Core.API.Instance_Class.GetMethod("SendRequestInternal");
                if (method == null)
                    throw new Exception();

                var patch = new IL2Patch(method, (_VRC_Core_API_SendRequestInternal)VRC_Core_API_SendRequestInternal);
                _delegateVRC_Core_API_SendRequestInternal = patch.CreateDelegate<_VRC_Core_API_SendRequestInternal>();
                "Invis API".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Invis API".RedPrefix(TMessage.BadPatch);
            }
        }

        private static void VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData)
        {
            string point = new IL2Object(endpoint).GetValue<string>();
            /*
            new Thread(() =>
            {
                new WebRequest(point);
            });
            */
            if ((point == "visits" || point == "joins" || (point.StartsWith("avatars/avtr_") && point.EndsWith("/select"))))
            {
                if (Mods.Status.isInvisAPI)
                    return;
            }

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
