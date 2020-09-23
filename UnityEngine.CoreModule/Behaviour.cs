using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	unsafe public class Behaviour : Component
	{
		public Behaviour(IntPtr ptrONew) : base(ptrONew) =>
			ptr = ptrONew;

		private static IL2Property propertyEnabled = null;
		public bool enabled
		{
			get
			{
				if (propertyEnabled == null)
				{
					propertyEnabled = Instance_Class.GetProperty("enabled");
					if (propertyEnabled == null)
						return default;
				}
				IL2Object result = propertyEnabled.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(bool*)result.Unbox();
			}
			set
			{
				if (propertyEnabled == null)
				{
					propertyEnabled = Instance_Class.GetProperty("enabled");
					if (propertyEnabled == null)
						return;
				}
				propertyEnabled.GetGetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
			}
		}

		private static IL2Property propertyIsActiveAndEnabled = null;
		public bool isActiveAndEnabled
		{
			get
			{
				if (propertyIsActiveAndEnabled == null)
				{
					propertyIsActiveAndEnabled = Instance_Class.GetProperty("propertyIsActiveAndEnabled");
					if (propertyIsActiveAndEnabled == null)
						return default;
				}
				IL2Object result = propertyIsActiveAndEnabled.GetGetMethod().Invoke(ptr);
				if (result == null)
					return default;

				return *(bool*)result.Unbox();
			}
		}
		public override bool Equals(object obj)
		{
			if (obj.GetType() != typeof(Behaviour))
				return false;
			return ((Behaviour)obj).ptr == ptr;
		}

		public override int GetHashCode() =>
			ptr.GetHashCode();

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Behaviour", "UnityEngine");
	}
}
