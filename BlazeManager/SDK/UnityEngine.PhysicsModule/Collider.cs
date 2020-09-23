using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class Collider : Component
    {
        public Collider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyEnabled = null;
        public bool enabled
		{
			get
			{
				if (!IL2Get.Property("enabled", Instance_Class, ref propertyEnabled))
					return default;

				return propertyEnabled.GetGetMethod().Invoke(ptr).Unbox<bool>();
			}
			set
			{
				if (!IL2Get.Property("enabled", Instance_Class, ref propertyEnabled))
					return;

				propertyEnabled.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
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

		private static IL2Property propertyIsTrigger = null;
		public bool isTrigger
		{
			get
			{
				if (!IL2Get.Property("isTrigger", Instance_Class, ref propertyIsTrigger))
					return default;

				return propertyIsTrigger.GetGetMethod().Invoke(ptr).Unbox<bool>();
			}
			set
			{
				if (!IL2Get.Property("isTrigger", Instance_Class, ref propertyIsTrigger))
					return;

				propertyIsTrigger.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
		}

		private static IL2Property propertyContactOffset = null;
		public float contactOffset
		{
			get
			{
				if (!IL2Get.Property("contactOffset", Instance_Class, ref propertyContactOffset))
					return default;

				return propertyContactOffset.GetGetMethod().Invoke(ptr).Unbox<float>();
			}
			set
			{
				if (!IL2Get.Property("contactOffset", Instance_Class, ref propertyContactOffset))
					return;

				propertyContactOffset.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
			}
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
