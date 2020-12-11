using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Rigidbody : Component
    {
        public Rigidbody(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        public bool isKinematic
        {
            get => Instance_Class.GetProperty(nameof(isKinematic)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(isKinematic)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public bool useGravity
        {
            get => Instance_Class.GetProperty(nameof(useGravity)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(useGravity)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginephysicsmodule]].GetClass("Rigidbody", "UnityEngine");
    }
}
