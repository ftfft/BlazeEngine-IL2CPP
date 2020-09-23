using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiAvatar : ApiModel
    {
        public ApiAvatar(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyReleaseStatus = null;
        public string releaseStatus
		{
			get
            {
                if (propertyReleaseStatus == null)
                {
                    propertyReleaseStatus = Instance_Class.GetProperty("releaseStatus");
                    if (propertyReleaseStatus == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyReleaseStatus.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
			set
            {
                if (propertyReleaseStatus == null)
                {
                    propertyReleaseStatus = Instance_Class.GetProperty("releaseStatus");
                    if (propertyReleaseStatus == null)
                        return;
                }
                propertyReleaseStatus.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
		}

        
        private static IL2Property propertyAuthorId = null;
        public string authorId
        {
            get
            {
                if (!Execute.CheckOrSetProperty("authorId", Instance_Class, ref propertyAuthorId))
                    return default;

                IL2Object result = propertyAuthorId.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return result.UnboxString();
            }
            set
            {
                if (!Execute.CheckOrSetProperty("authorId", Instance_Class, ref propertyAuthorId))
                    return;

                propertyAuthorId.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }


        private static IL2Property propertyAssetUrl = null;
        public string assetUrl
        {
            get
            {
                if (!Execute.CheckOrSetProperty("assetUrl", Instance_Class, ref propertyAssetUrl))
                    return default;

                IL2Object result = propertyAssetUrl.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return result.UnboxString();
            }
            set
            {
                if (!Execute.CheckOrSetProperty("assetUrl", Instance_Class, ref propertyAssetUrl))
                    return;

                propertyAssetUrl.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        private static IL2Method methodSaveReleaseStatus = null;
        public void SaveReleaseStatus(Action<ApiContainer> onSuccess = null, Action<ApiContainer> onFailure = null)
        {
            if (methodSaveReleaseStatus == null)
            {
                methodSaveReleaseStatus = Instance_Class.GetMethod("SaveReleaseStatus");
                if (methodSaveReleaseStatus == null)
                    return;
            }

            IntPtr ptrSucc = IntPtr.Zero;
            IntPtr ptrFail = IntPtr.Zero;
            if (onSuccess != null)
                ptrSucc = UnityEngine.Events._UnityAction.CreateDelegate(onSuccess, null, il2action);
            if(onFailure != null)
                ptrFail = UnityEngine.Events._UnityAction.CreateDelegate(onFailure, null, il2action);
            methodSaveReleaseStatus.Invoke(ptr, new IntPtr[] { ptrSucc, ptrFail });
        }

        public static IL2Type il2action = Assemblies.a["mscorlib"].GetClass("Action`1", "System");

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiAvatar", "VRC.Core");
    }
}
