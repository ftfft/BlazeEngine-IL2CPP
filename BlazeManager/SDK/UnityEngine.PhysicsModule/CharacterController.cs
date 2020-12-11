using System;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool isGrounded
        {
            get => Instance_Class.GetProperty(nameof(isGrounded)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(isGrounded)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }
        
        public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
            set => Instance_Class.GetProperty(nameof(velocity)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public CollisionFlags Move(Vector3 motion)
        {
            return Instance_Class.GetMethod(nameof(Move)).Invoke(ptr, new IntPtr[] { motion.MonoCast() }).unbox_Unmanaged<CollisionFlags>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginephysicsmodule]].GetClass("CharacterController", "UnityEngine");
    }
}
