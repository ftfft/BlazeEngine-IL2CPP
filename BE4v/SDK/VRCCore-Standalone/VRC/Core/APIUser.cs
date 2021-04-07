using BE4v.SDK.CPP2IL;
using System;
using System.Data.SqlTypes;

namespace VRC.Core
{
    public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static APIUser CurrentUser
        {
            get => Instance_Class.GetProperty(nameof(CurrentUser)).GetGetMethod().Invoke()?.GetValue<APIUser>();
        }

        public static bool IsFriendsWith(string userId) => IsFriendsWith(new IL2String(userId).ptr);
        public static bool IsFriendsWith(IntPtr userId)
        {
            return Instance_Class.GetMethod(nameof(IsFriendsWith)).Invoke(new IntPtr[] { userId }).GetValuе<bool>();
        }

        public bool HasTag(string tag) => HasTag(new IL2String(tag).ptr);
        public bool HasTag(IntPtr tag)
        {
            return Instance_Class.GetMethod(nameof(HasTag)).Invoke(ptr, new IntPtr[] { tag }).GetValuе<bool>();
        }

        public string displayName
        {
            get => Instance_Class.GetProperty(nameof(displayName)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
        }

        public string[] tags
        {
            get
            {
                return Instance_Class.GetProperty(nameof(tags)).GetGetMethod().Invoke(ptr).ToIL2List<string>().IL2ToArray();
            }
        }
        
        public bool hasVIPAccess
        {
            get => Instance_Class.GetProperty(nameof(hasVIPAccess)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        unsafe public bool allowAvatarCopying
        {
            get => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        public bool hasModerationPowers
        {
            get => Instance_Class.GetProperty(nameof(hasModerationPowers)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }
        
        public bool hasScriptingAccess
        {
            get => Instance_Class.GetProperty(nameof(hasScriptingAccess)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public bool hasKnownTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasKnownTrustLevel)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public bool hasVeteranTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasVeteranTrustLevel)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public bool hasTrustedTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasTrustedTrustLevel)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public bool hasBasicTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasBasicTrustLevel)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public bool hasNegativeTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasNegativeTrustLevel)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
        }

        public string location
        {
            get => Instance_Class.GetProperty(nameof(location)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
        }

        public string avatarId
        {
            get => Instance_Class.GetProperty(nameof(avatarId)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
        }

        public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}