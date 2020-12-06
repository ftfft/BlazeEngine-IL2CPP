using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_Pickup : MonoBehaviour
	{
		public VRC_Pickup(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public bool pickupable
		{
			get => Instance_Class.GetField(nameof(pickupable)).GetValue(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetField(nameof(pickupable)).SetValue(ptr, value.MonoCast());
		}

		public float proximity
		{
			get => Instance_Class.GetField(nameof(proximity)).GetValue(ptr).unbox_Unmanaged<float>();
			set => Instance_Class.GetField(nameof(proximity)).SetValue(ptr, value.MonoCast());
		}
		
		public bool allowManipulationWhenEquipped
		{
			get => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).GetValue(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).SetValue(ptr, value.MonoCast());
		}

		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRC_Pickup", "VRC.SDKBase");
	}
}
