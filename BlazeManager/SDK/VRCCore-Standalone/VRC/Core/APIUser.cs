using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;

namespace VRC.Core
{
    public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static APIUser CurrentUser
        {
            get => Instance_Class.GetProperty(nameof(CurrentUser)).GetGetMethod().Invoke()?.unbox<APIUser>();
        }

        public static bool IsFriendsWith(string userId) => IsFriendsWith(new IL2String(userId).ptr);
        public static bool IsFriendsWith(IntPtr userId)
        {
            return Instance_Class.GetMethod(nameof(IsFriendsWith)).Invoke(new IntPtr[] { userId }).unbox_Unmanaged<bool>();
        }

        public bool HasTag(string tag) => HasTag(new IL2String(tag).ptr);
        public bool HasTag(IntPtr tag)
        {
            return Instance_Class.GetMethod(nameof(HasTag)).Invoke(ptr, new IntPtr[] { tag }).unbox_Unmanaged<bool>();
        }

        public string displayName
        {
            get => Instance_Class.GetProperty(nameof(displayName)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
        }

        public string[] tags
        {
            get
            {
                return new IL2List<string>(Instance_Class.GetProperty(nameof(tags)).GetGetMethod().Invoke(ptr).ptr).ToArray();
            }
        }
        
        public bool hasVIPAccess
        {
            get => Instance_Class.GetProperty(nameof(hasVIPAccess)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool allowAvatarCopying
        {
            get => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public bool hasModerationPowers
        {
            get => Instance_Class.GetProperty(nameof(hasModerationPowers)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }
        
        public bool hasScriptingAccess
        {
            get => Instance_Class.GetProperty(nameof(hasScriptingAccess)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool hasKnownTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasKnownTrustLevel)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool hasVeteranTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasVeteranTrustLevel)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool hasTrustedTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasTrustedTrustLevel)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool hasBasicTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasBasicTrustLevel)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool hasNegativeTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasNegativeTrustLevel)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public string location
        {
            get => Instance_Class.GetProperty(nameof(location)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}