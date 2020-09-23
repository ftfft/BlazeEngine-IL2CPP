using System;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRCSDK2
{
    public class VRC_PlayerApi : MonoBehaviour
    {
        public VRC_PlayerApi(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyIsMaster = null;
        public bool isMaster
        {
            get
            {
                if (!IL2Get.Property("isMaster", Instance_Class, ref propertyIsMaster))
                    return default;

                return propertyIsMaster.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyIsModerator;
        public bool isModerator
        {
            get
            {
                if (!IL2Get.Property("isModerator", Instance_Class, ref propertyIsModerator))
                    return default;

                return propertyIsModerator.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyIsSuper = null;
        public bool isSuper
        {
            get
            {
                if (!IL2Get.Property("isSuper", Instance_Class, ref propertyIsSuper))
                    return default;

                return propertyIsSuper.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("VRC_PlayerApi", "VRCSDK2");
    }
}
