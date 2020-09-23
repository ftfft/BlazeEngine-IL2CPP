using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Rigidbody : Component
    {
        public Rigidbody(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        private static IL2Property propertyIsKinematic = null;
        public bool isKinematic
        {
            get
            {
                if (propertyIsKinematic == null)
                {
                    propertyIsKinematic = Instance_Class.GetProperty("isKinematic");
                    if (propertyIsKinematic == null)
                        return default;
                }

                return propertyIsKinematic.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyIsKinematic == null)
                {
                    propertyIsKinematic = Instance_Class.GetProperty("isKinematic");
                    if (propertyIsKinematic == null)
                        return;
                }
                propertyIsKinematic.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyUseGravity = null;
        public bool useGravity
        {
            get
            {
                if (propertyUseGravity == null)
                {
                    propertyUseGravity = Instance_Class.GetProperty("useGravity");
                    if (propertyUseGravity == null)
                        return default;
                }

                return propertyUseGravity.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyUseGravity == null)
                {
                    propertyUseGravity = Instance_Class.GetProperty("useGravity");
                    if (propertyUseGravity == null)
                        return;
                }
                propertyUseGravity.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("Rigidbody", "UnityEngine");
    }
}
