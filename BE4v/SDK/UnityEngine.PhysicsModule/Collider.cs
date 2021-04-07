using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine
{
    public class Collider : Component
    {
        public Collider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public bool enabled
		{
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		/*
		public Rigidbody attachedRigidbody
		{
			[Address(RVA = "0x181B15170", Offset = "0x1B13770")]
			get
			{
			}
		}
		*/
		unsafe public bool isTrigger
		{
			get => Instance_Class.GetProperty(nameof(isTrigger)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(isTrigger)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public float contactOffset
		{
			get => Instance_Class.GetProperty(nameof(contactOffset)).GetGetMethod().Invoke(ptr).GetValuе<float>();
			set => Instance_Class.GetProperty(nameof(contactOffset)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		/*
		public Vector3 ClosestPoint(Vector3 position)
		{
		}

		public Bounds bounds
		{
			[Address(RVA = "0x181B15240", Offset = "0x1B13840")]
			get
			{
			}
		}

		public PhysicMaterial sharedMaterial
		{
			[Address(RVA = "0x181B15450", Offset = "0x1B13A50")]
			get
			{
			}
			[Address(RVA = "0x181B15670", Offset = "0x1B13C70")]
			set
			{
			}
		}

		public PhysicMaterial material
		{
			[Address(RVA = "0x181B153F0", Offset = "0x1B139F0")]
			get
			{
			}
			[Address(RVA = "0x181B15600", Offset = "0x1B13C00")]
			set
			{
			}
		}
		*/

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("Collider", "UnityEngine");
    }
}
