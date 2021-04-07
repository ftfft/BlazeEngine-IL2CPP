using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class Rigidbody : Component
    {
        public Rigidbody(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        unsafe public bool isKinematic
        {
            get => Instance_Class.GetProperty(nameof(isKinematic)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(isKinematic)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool useGravity
        {
            get => Instance_Class.GetProperty(nameof(useGravity)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(useGravity)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("Rigidbody", "UnityEngine");
    }
}
