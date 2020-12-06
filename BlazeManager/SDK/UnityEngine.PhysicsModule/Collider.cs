using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class Collider : Component
    {
        public Collider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public bool enabled
		{
			get => Instance_Class.GetProperty(nameof(enabled)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(enabled)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
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
		public bool isTrigger
		{
			get => Instance_Class.GetProperty(nameof(isTrigger)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(isTrigger)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public float contactOffset
		{
			get => Instance_Class.GetProperty(nameof(contactOffset)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<float>();
			set => Instance_Class.GetProperty(nameof(contactOffset)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
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

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("Collider", "UnityEngine");
    }
}
