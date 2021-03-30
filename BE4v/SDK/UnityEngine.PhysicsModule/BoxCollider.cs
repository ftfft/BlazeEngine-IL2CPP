using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class BoxCollider : Collider
    {
        public BoxCollider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public Vector3 center
		{
			get => Instance_Class.GetProperty(nameof(center)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
			set => Instance_Class.GetProperty(nameof(center)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public Vector3 size
		{
			get => Instance_Class.GetProperty(nameof(size)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
			set => Instance_Class.GetProperty(nameof(size)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public Vector3 extents
		{
			get => Instance_Class.GetProperty(nameof(extents)).GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
			set => Instance_Class.GetProperty(nameof(extents)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("BoxCollider", "UnityEngine");
    }
}
