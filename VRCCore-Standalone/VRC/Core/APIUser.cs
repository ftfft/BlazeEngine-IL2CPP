using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    unsafe public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyCurrentUser = null;
        public static APIUser CurrentUser
        {
            get
            {
                if (propertyCurrentUser == null)
                {
                    propertyCurrentUser = Instance_Class.GetProperty("CurrentUser");
                    if (propertyCurrentUser == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyCurrentUser.GetGetMethod().Invoke();
                if (result == null)
                    return null;

                return result.ptr.MonoCast<APIUser>();
            }
        }

        private static IL2Property propertyDisplayName = null;
        public string displayName
        {
            get
            {
                if (propertyDisplayName == null)
                {
                    propertyDisplayName = Instance_Class.GetProperty("displayName");
                    if (propertyDisplayName == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyDisplayName.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
        }
        

        private static IL2Property propertyHasVIPAccess = null;
        public bool hasVIPAccess
        {
            get
            {
                if (propertyHasVIPAccess == null)
                {
                    propertyHasVIPAccess = Instance_Class.GetProperty("hasVIPAccess");
                    if (propertyHasVIPAccess == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyHasVIPAccess.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }

        private static IL2Property propertyAllowAvatarCopying = null;
        public bool allowAvatarCopying
        {
            get
            {
                if (propertyAllowAvatarCopying == null)
                {
                    propertyAllowAvatarCopying = Instance_Class.GetProperty("allowAvatarCopying");
                    if (propertyAllowAvatarCopying == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyAllowAvatarCopying.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
            set
            {
                if (propertyAllowAvatarCopying == null)
                {
                    propertyAllowAvatarCopying = Instance_Class.GetProperty("allowAvatarCopying");
                    if (propertyAllowAvatarCopying == null)
                        return;
                }
                propertyAllowAvatarCopying.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyHasModerationPowers = null;
        public bool hasModerationPowers
        {
            get
            {
                if (propertyHasModerationPowers == null)
                {
                    propertyHasModerationPowers = Instance_Class.GetProperty("hasModerationPowers");
                    if (propertyHasModerationPowers == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyHasModerationPowers.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }
        

        private static IL2Property propertyHasScriptingAccess = null;
        public bool hasScriptingAccess
        {
            get
            {
                if (propertyHasScriptingAccess == null)
                {
                    propertyHasScriptingAccess = Instance_Class.GetProperty("hasScriptingAccess");
                    if (propertyHasScriptingAccess == null)
                        return false;
                }

                return *(bool*)propertyHasScriptingAccess.GetGetMethod().Invoke(ptr).Unbox();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(APIUser))
                return false;
            return ((APIUser)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}