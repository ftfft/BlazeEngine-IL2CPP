using System;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRCStation : MonoBehaviour
	{
		public VRCStation(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		unsafe public bool canUseStationFromStation
		{
			get => Instance_Class.GetField(nameof(canUseStationFromStation)).GetValue(ptr).GetValuе<bool>();
			set => Instance_Class.GetField(nameof(canUseStationFromStation)).SetValue(ptr, new IntPtr(&value));
		}

		public static new IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRCStation", "VRC.SDKBase");
	}
}
