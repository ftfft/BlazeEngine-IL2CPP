using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    unsafe public class ApiModel : IL2Base
    {
        public ApiModel(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyId = null;
        public string id
        {
            get
            {
                if (propertyId == null)
                {
                    propertyId = Instance_Class.GetProperty("id");
                    if (propertyId == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyId.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
            set
            {

                if (propertyId == null)
                {
                    propertyId = Instance_Class.GetProperty("id");
                    if (propertyId == null)
                        return;
                }

                propertyId.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }
    
        private static IL2Property propertyPopulated = null;
        public bool Populated
        {
            get
            {
                if (propertyPopulated == null)
                {
                    propertyPopulated = Instance_Class.GetProperty("Populated");
                    if (propertyPopulated == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyPopulated.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ApiModel))
                return false;
            return ((ApiModel)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();


        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiModel", "VRC.Core");
    }
}