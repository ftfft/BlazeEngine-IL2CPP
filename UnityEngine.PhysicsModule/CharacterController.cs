using System;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

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

                IL2Object result = null;
                result = propertyIsGrounded.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
            set
            {
                if (propertyIsGrounded == null)
                {
                    propertyIsGrounded = Instance_Class.GetProperty("isGrounded");
                    if (propertyIsGrounded == null)
                        return;
                }
                if (ptr == IntPtr.Zero)
                    return;

                propertyIsGrounded.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
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

                IL2Object result = null;
                result = propertyVelocity.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
            set
            {
                if (propertyVelocity == null)
                {
                    propertyVelocity = Instance_Class.GetProperty("velocity");
                    if (propertyVelocity == null)
                        return;
                }

                propertyVelocity.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
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

            IL2Object result = null;
            result = methodMove.Invoke(ptr, new IntPtr[] { new IntPtr(&motion) });
            if (result == null)
                return CollisionFlags.None;

            return *(CollisionFlags*)result.Unbox();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(CharacterController))
                return false;
            return ((CharacterController)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
