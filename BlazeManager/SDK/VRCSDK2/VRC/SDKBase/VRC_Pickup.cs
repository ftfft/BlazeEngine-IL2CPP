using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_Pickup : MonoBehaviour
	{
		public VRC_Pickup(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		private static IL2Field fieldPickupable = null;
		public bool pickupable
		{
			get
			{
				if (fieldPickupable == null)
				{
					fieldPickupable = Instance_Class.GetField("pickupable");
					if (fieldPickupable == null)
						return default;
				}
				return fieldPickupable.GetValue(ptr).MonoCast<bool>();
			}
			set
			{
				if (fieldPickupable == null)
				{
					fieldPickupable = Instance_Class.GetField("pickupable");
					if (fieldPickupable == null)
						return;
				}
				fieldPickupable.SetValue(ptr, value.MonoCast());
			}
		}

		private static IL2Field fieldProximity = null;
		public float proximity
		{
			get
			{
				if (fieldProximity == null)
				{
					fieldProximity = Instance_Class.GetField("proximity");
					if (fieldProximity == null)
						return default;
				}
				return fieldProximity.GetValue(ptr).MonoCast<float>();
			}
			set
			{
				if (fieldProximity == null)
				{
					fieldProximity = Instance_Class.GetField("proximity");
					if (fieldProximity == null)
						return;
				}
				fieldProximity.SetValue(ptr, value.MonoCast());
			}
		}

		private static IL2Field fieldAllowManipulationWhenEquipped = null;
		public bool allowManipulationWhenEquipped
		{
			get
			{
				if (fieldAllowManipulationWhenEquipped == null)
				{
					fieldAllowManipulationWhenEquipped = Instance_Class.GetField("allowManipulationWhenEquipped");
					if (fieldAllowManipulationWhenEquipped == null)
						return default;
				}
				return fieldAllowManipulationWhenEquipped.GetValue(ptr).MonoCast<bool>();
			}
			set
			{
				if (fieldAllowManipulationWhenEquipped == null)
				{
					fieldAllowManipulationWhenEquipped = Instance_Class.GetField("allowManipulationWhenEquipped");
					if (fieldAllowManipulationWhenEquipped == null)
						return;
				}
				fieldAllowManipulationWhenEquipped.SetValue(ptr, value.MonoCast());
			}
		}

		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRC_Pickup", "VRC.SDKBase");
	}
}
