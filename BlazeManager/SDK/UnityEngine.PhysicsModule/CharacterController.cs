using System;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyIsGrounded = null;
        public bool isGrounded
        {
            get
            {
                if (propertyIsGrounded == null)
                {
                    propertyIsGrounded = Instance_Class.GetProperty("isGrounded");
                    if (propertyIsGrounded == null)
                        return default;
                }

                return propertyIsGrounded.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (propertyIsGrounded == null)
                {
                    propertyIsGrounded = Instance_Class.GetProperty("isGrounded");
                    if (propertyIsGrounded == null)
                        return;
                }

                propertyIsGrounded.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }
        
        private static IL2Property propertyVelocity = null;
        public Vector3 velocity
        {
            get
            {
                if (propertyVelocity == null)
                {
                    propertyVelocity = Instance_Class.GetProperty("velocity");
                    if (propertyVelocity == null)
                        return default;
                }

                return propertyVelocity.GetGetMethod().Invoke(ptr).Unbox<Vector3>();
            }
            set
            {
                if (propertyVelocity == null)
                {
                    propertyVelocity = Instance_Class.GetProperty("velocity");
                    if (propertyVelocity == null)
                        return;
                }

                propertyVelocity.GetSetMethod().Invoke(ptr, new IntPtr[] {value.MonoCast() });
            }
        }

        private static IL2Method methodMove = null;
        public CollisionFlags Move(Vector3 motion)
        {
            if(methodMove == null)
            {
                methodMove = Instance_Class.GetMethod("Move");
                if (methodMove == null)
                    return CollisionFlags.None;
            }

            return methodMove.Invoke(ptr, new IntPtr[] { motion.MonoCast() }).Unbox<CollisionFlags>();
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
