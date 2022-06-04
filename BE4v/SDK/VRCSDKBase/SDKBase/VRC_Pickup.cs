using System;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_Pickup : MonoBehaviour
	{
		public VRC_Pickup(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		unsafe public bool pickupable
		{
			get => Instance_Class.GetField(nameof(pickupable)).GetValue(ptr).GetValuе<bool>();
			set => Instance_Class.GetField(nameof(pickupable)).SetValue(ptr, new IntPtr(&value));
		}

		unsafe public float proximity
		{
			get => Instance_Class.GetField(nameof(proximity)).GetValue(ptr).GetValuе<float>();
			set => Instance_Class.GetField(nameof(proximity)).SetValue(ptr, new IntPtr(&value));
		}
		
		unsafe public bool allowManipulationWhenEquipped
		{
			get => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).GetValue(ptr).GetValuе<bool>();
			set => Instance_Class.GetField(nameof(allowManipulationWhenEquipped)).SetValue(ptr, new IntPtr(&value));
		}

		unsafe public PickupOrientation orientation
		{
			get => Instance_Class.GetField(nameof(orientation)).GetValue(ptr).GetValuе<PickupOrientation>();
			set => Instance_Class.GetField(nameof(orientation)).SetValue(ptr, new IntPtr(&value));
		}

		public enum PickupOrientation
		{
			Any,
			Grip,
			Gun
		}


		public static new IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRC_Pickup", "VRC.SDKBase");
	}
}
