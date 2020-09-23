using System;
using System.Linq;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.Core
{
    public class ApiWorldInstance : IL2Base
    {
        public ApiWorldInstance(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            if (!IL2Get.Constructor(x => x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "_count",
                Instance_Class, ref constructors[0]))
                return;

            ptr = constructors[0].Invoke().ptr;
        }

        private static IL2Method methodGetInstanceCreator;
        public string GetInstanceCreator()
        {
            if (!IL2Get.Method("GetInstanceCreator", Instance_Class, ref methodGetInstanceCreator))
                return null;

            return methodGetInstanceCreator.Invoke(ptr)?.Unbox<string>();
        }

        private static IL2Field fieldInstanceWorld;
        public ApiWorld instanceWorld
        {
            get
            {
                if (!IL2Get.Field("instanceWorld", Instance_Class, ref fieldInstanceWorld))
                    return null;

                return fieldInstanceWorld.GetValue(ptr)?.Unbox<ApiWorld>();
            }
        }

        private static IL2Field fieldIdWithTags;
        public string idWithTags
        {
            get
            {
                if (!IL2Get.Field("idWithTags", Instance_Class, ref fieldIdWithTags))
                    return null;

                return fieldIdWithTags.GetValue(ptr)?.Unbox<string>();
            }
        }

        private static IL2Constructor[] constructors = new IL2Constructor[1];

        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiWorldInstance", "VRC.Core");
    }
}