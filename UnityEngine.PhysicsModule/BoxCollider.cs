using System;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class BoxCollider : Collider
    {
        public BoxCollider(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

		private static IL2Property propertyCenter = null;
		public Vector3 center
		{
			get
			{
				if (!Execute.CheckOrSetProperty("center", Instance_Class, ref propertyCenter))
					return default;

				IL2Object result = propertyCenter.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(Vector3*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("center", Instance_Class, ref propertyCenter))
					return;

				propertyCenter.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
			}
		}

		private static IL2Property propertySize = null;
		public Vector3 size
		{
			get
			{
				if (!Execute.CheckOrSetProperty("size", Instance_Class, ref propertySize))
					return default;

				IL2Object result = propertySize.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(Vector3*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("size", Instance_Class, ref propertySize))
					return;

				propertySize.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
			}
		}

		private static IL2Property propertyExtents = null;
		public Vector3 extents
		{
			get
			{
				if (!Execute.CheckOrSetProperty("extents", Instance_Class, ref propertyExtents))
					return default;

				IL2Object result = propertySize.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(Vector3*)result.Unbox();
			}
			set
			{
				if (!Execute.CheckOrSetProperty("extents", Instance_Class, ref propertyExtents))
					return;

				propertySize.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
			}
		}


		public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(BoxCollider))
                return false;
            return ((BoxCollider)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("BoxCollider", "UnityEngine");
    }
}
