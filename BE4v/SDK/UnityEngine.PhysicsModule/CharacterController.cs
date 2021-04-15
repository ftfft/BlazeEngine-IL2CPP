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
        }
        
        unsafe public Vector3 velocity
        {
            get => Instance_Class.GetProperty(nameof(velocity)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
        }

        unsafe public CollisionFlags Move(Vector3 motion)
        {
            return Instance_Class.GetMethod(nameof(Move)).Invoke(ptr, new IntPtr[] { new IntPtr(&motion) }).GetValuе<CollisionFlags>();
        }
        
        unsafe public bool SimpleMove(Vector3 speed)
        {
            return Instance_Class.GetMethod(nameof(SimpleMove)).Invoke(ptr, new IntPtr[] { new IntPtr(&speed) }).GetValuе<bool>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("CharacterController", "UnityEngine");
    }
}
