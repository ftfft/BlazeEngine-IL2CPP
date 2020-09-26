using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using BlazeIL.il2generic;

namespace VRC.Core
{
    public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyCurrentUser = null;
        public static APIUser CurrentUser
        {
            get
            {
                if (!IL2Get.Property("CurrentUser", Instance_Class, ref propertyCurrentUser))
                    return null;

                return propertyCurrentUser.GetGetMethod().Invoke()?.MonoCast<APIUser>();
            }
        }

        private static IL2Method methodIsFriendsWith = null;
        public static bool IsFriendsWith(string userId)
        {
            if (!IL2Get.Method("IsFriendsWith", Instance_Class, ref methodIsFriendsWith))
                return default;

            return methodIsFriendsWith.Invoke(IntPtr.Zero, new IntPtr[] { IL2Import.StringToIntPtr(userId) }).Unbox<bool>();
        }

        private static IL2Method methodHasTag = null;
        public bool HasTag(string tag)
        {
            if (!IL2Get.Method("HasTag", Instance_Class, ref methodHasTag))
                return default;

            return methodHasTag.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(tag) }).Unbox<bool>();
        }

        private static IL2Property propertyDisplayName = null;
        public string displayName
        {
            get
            {
                if (!IL2Get.Property("displayName", Instance_Class, ref propertyDisplayName))
                    return null;

                return propertyDisplayName.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
        }

        private static IL2Property propertyTags = null;
        public string[] tags
        {
            get
            {
                if (!IL2Get.Property("tags", Instance_Class, ref propertyTags))
                    return null;

                return new IL2List<string>(propertyTags.GetGetMethod().Invoke(ptr).ptr).ToArray();
            }
        }
        

        private static IL2Property propertyHasVIPAccess = null;
        public bool hasVIPAccess
        {
            get
            {
                if (!IL2Get.Property("hasVIPAccess", Instance_Class, ref propertyHasVIPAccess))
                    return default;

                IL2Object obj = propertyHasVIPAccess.GetGetMethod().Invoke(ptr);
                if (obj == null)
                    return default;

                return obj.Unbox<bool>();
            }
        }

        private static IL2Property propertyAllowAvatarCopying = null;
        public bool allowAvatarCopying
        {
            get
            {
                if (!IL2Get.Property("allowAvatarCopying", Instance_Class, ref propertyAllowAvatarCopying))
                    return default;

                return propertyAllowAvatarCopying.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (!IL2Get.Property("allowAvatarCopying", Instance_Class, ref propertyAllowAvatarCopying))
                    return;

                propertyAllowAvatarCopying.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyHasModerationPowers = null;
        public bool hasModerationPowers
        {
            get
            {
                if (!IL2Get.Property("hasModerationPowers", Instance_Class, ref propertyHasModerationPowers))
                    return default;

                return propertyHasModerationPowers.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }
        

        private static IL2Property propertyHasScriptingAccess = null;
        public bool hasScriptingAccess
        {
            get
            {
                if (!IL2Get.Property("hasScriptingAccess", Instance_Class, ref propertyHasScriptingAccess))
                    return default;

                return propertyHasScriptingAccess.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyHasKnownTrustLevel = null;
        public bool hasKnownTrustLevel
        {
            get
            {
                if (!IL2Get.Property("hasKnownTrustLevel", Instance_Class, ref propertyHasKnownTrustLevel))
                    return default;

                return propertyHasKnownTrustLevel.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyHasVeteranTrustLevel = null;
        public bool hasVeteranTrustLevel
        {
            get
            {
                if (!IL2Get.Property("hasVeteranTrustLevel", Instance_Class, ref propertyHasVeteranTrustLevel))
                    return default;

                return propertyHasVeteranTrustLevel.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyHasTrustedTrustLevel = null;
        public bool hasTrustedTrustLevel
        {
            get
            {
                if (!IL2Get.Property("hasTrustedTrustLevel", Instance_Class, ref propertyHasTrustedTrustLevel))
                    return default;

                return propertyHasTrustedTrustLevel.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyHasBasicTrustLevel = null;
        public bool hasBasicTrustLevel
        {
            get
            {
                if (!IL2Get.Property("hasBasicTrustLevel", Instance_Class, ref propertyHasBasicTrustLevel))
                    return default;

                return propertyHasBasicTrustLevel.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyHasNegativeTrustLevel = null;
        public bool hasNegativeTrustLevel
        {
            get
            {
                if (!IL2Get.Property("hasNegativeTrustLevel", Instance_Class, ref propertyHasNegativeTrustLevel))
                    return default;

                return propertyHasNegativeTrustLevel.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyLocation = null;
        public string location
        {
            get
            {
                if (!IL2Get.Property("location", Instance_Class, ref propertyLocation))
                    return default;

                return propertyLocation.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
        }
        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}