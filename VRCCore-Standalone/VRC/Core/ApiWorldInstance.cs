using System;
using System.Linq;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    unsafe public class ApiWorldInstance : IL2Base
    {
        public ApiWorldInstance(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method constructApiWorldInstanceType1 = null;
        public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            if (constructApiWorldInstanceType1 == null)
            {
                constructApiWorldInstanceType1 = Instance_Class.GetMethods()
                    .Where(x => x.Name == ".ctor" && x.GetParameters().Length == 3)
                    .First(x => x.GetParameters()[2].Name == "_count");

                if (constructApiWorldInstanceType1 == null)
                    return;
            }
            ptr = constructApiWorldInstanceType1.Invoke().ptr;
        }

        private static IL2Method methodGetInstanceCreator = null;
        public string GetInstanceCreator()
        {
            if (methodGetInstanceCreator == null)
            {
                methodGetInstanceCreator = Instance_Class.GetMethod("GetInstanceCreator");
                if (methodGetInstanceCreator == null)
                    return null;
            }

            IL2Object result = null;
            result = methodGetInstanceCreator.Invoke(ptr);
            if (result == null)
                return null;

            return result.UnboxString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(ApiWorldInstance))
                return false;
            return ((ApiWorldInstance)obj).ptr == ptr;
        }


        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorldInstance", "VRC.Core");
    }
}