using System;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class Collider : Component
    {
        public Collider(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyEnabled = null;
        public bool enabled
		{
			get
			{
				if (!Execute.CheckOrSetProperty("enabled", Instance_Class, ref propertyEnabled))
					return default;

				IL2Object result = propertyEnabled.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(bool*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("enabled", Instance_Class, ref propertyEnabled))
					return;

				propertyEnabled.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
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
				if (!Execute.CheckOrSetProperty("isTrigger", Instance_Class, ref propertyIsTrigger))
					return default;

				IL2Object result = propertyIsTrigger.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(bool*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("isTrigger", Instance_Class, ref propertyIsTrigger))
					return;

				propertyIsTrigger.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
			}
		}

		private static IL2Property propertyContactOffset = null;
		public float contactOffset
		{
			get
			{
				if (!Execute.CheckOrSetProperty("contactOffset", Instance_Class, ref propertyContactOffset))
					return default;

				IL2Object result = propertyContactOffset.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(float*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("contactOffset", Instance_Class, ref propertyContactOffset))
					return;

				propertyContactOffset.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
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

		public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Collider))
                return false;
            return ((Collider)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("Collider", "UnityEngine");
    }
}
