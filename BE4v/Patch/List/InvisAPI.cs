using System;
using BE4v.MenuEdit;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using BE4v.Mods;

namespace BE4v.Patch.List
{
    public class InvisAPI : IPatch
    {
        public delegate void _VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData);
        public static void Toggle()
        {
            Mods.Status.isInvisAPI = !Mods.Status.isInvisAPI;
            BE4V_ModeMenu.InvisAPI.Refresh();
        }

        public void Start()
        {
            IL2Method method = VRC.Core.API.Instance_Class.GetMethod("SendRequestInternal");
            if (method != null)
            {
                patch = new IL2Patch(method, (_VRC_Core_API_SendRequestInternal)VRC_Core_API_SendRequestInternal);
                _SendRequestInternal = patch.CreateDelegate<_VRC_Core_API_SendRequestInternal>();
            }
            else
                throw new NullReferenceException();
        }

        private static void VRC_Core_API_SendRequestInternal(IntPtr endpoint, IntPtr method, IntPtr responseContainer, IntPtr requestParams, bool authenticationRequired, bool disableCache, float cacheLifetime, int retryCount, IntPtr credentials, IntPtr formData)
        {
            if (Status.isInvisAPI)
            {
                string point = new IL2Object(endpoint).GetValue<string>();
                if (point == "visits" || point == "joins") return;
            }

            _SendRequestInternal(
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

        public static IL2Patch patch;

        public static _VRC_Core_API_SendRequestInternal _SendRequestInternal;
    }
}
