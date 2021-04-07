using System;
using System.Runtime.InteropServices;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class CharacterController : Collider
    {
        public CharacterController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public bool isGrounded
        {
            get => Instance_Class.GetProperty(nameof(isGrounded)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(isGrounded)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }
        
        unsafe public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
            set => Instance_Class.GetProperty(nameof(velocity)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public CollisionFlags Move(Vector3 motion)
        {
            return Instance_Class.GetMethod(nameof(Move)).Invoke(ptr, new IntPtr[] { new IntPtr(&motion) }).GetValuе<CollisionFlags>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
