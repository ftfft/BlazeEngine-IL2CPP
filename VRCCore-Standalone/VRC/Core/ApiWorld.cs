using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    unsafe public class ApiWorld : ApiModel
    {
        public ApiWorld(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Field fieldCurrentInstanceIdWithTags = null;
        public string currentInstanceIdWithTags
        {
            get
            {
                if (fieldCurrentInstanceIdWithTags == null)
                {
                    fieldCurrentInstanceIdWithTags = Instance_Class.GetField("currentInstanceIdWithTags");
                    if (fieldCurrentInstanceIdWithTags == null)
                        return null;
                }

                IL2Object result = null;
                result = fieldCurrentInstanceIdWithTags.GetValue(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
        }
        private static IL2Property propertyAuthorId = null;
        public string authorId
        {
            get
            {
                if (propertyAuthorId == null)
                {
                    propertyAuthorId = Instance_Class.GetProperty("authorId");
                    if (propertyAuthorId == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyAuthorId.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
            set
            {
                if (propertyAuthorId == null)
                {
                    propertyAuthorId = Instance_Class.GetProperty("authorId");
                    if (propertyAuthorId == null)
                        return;
                }
                propertyAuthorId.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ApiWorld))
                return false;
            return ((ApiWorld)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorld", "VRC.Core");
    }
}