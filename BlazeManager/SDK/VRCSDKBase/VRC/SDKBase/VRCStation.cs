using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRCStation : MonoBehaviour
	{
		public VRCStation(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public bool canUseStationFromStation
		{
			get => Instance_Class.GetField(nameof(canUseStationFromStation)).GetValue(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetField(nameof(canUseStationFromStation)).SetValue(ptr, value.MonoCast());
		}

		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRCStation", "VRC.SDKBase");
	}
}
