using System;
using System.Runtime.InteropServices;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool isGrounded
        {
            get => Instance_Class.GetProperty(nameof(isGrounded)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(isGrounded)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }
        
        public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
            set => Instance_Class.GetProperty(nameof(velocity)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public CollisionFlags Move(Vector3 motion)
        {
            return Instance_Class.GetMethod(nameof(Move)).Invoke(ptr, new IntPtr[] { motion.MonoCast() }).GetValuе<CollisionFlags>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
