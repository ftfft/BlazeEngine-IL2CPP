using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRCStation : MonoBehaviour
	{
		public VRCStation(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		private static IL2Field fieldCanUseStationFromStation = null;
		public bool canUseStationFromStation
		{
			get
			{
				if (fieldCanUseStationFromStation == null)
				{
					fieldCanUseStationFromStation = Instance_Class.GetField("canUseStationFromStation");
					if (fieldCanUseStationFromStation == null)
						return default;
				}
				return fieldCanUseStationFromStation.GetValue(ptr).MonoCast<bool>();
			}
			set
			{
				if (fieldCanUseStationFromStation == null)
				{
					fieldCanUseStationFromStation = Instance_Class.GetField("canUseStationFromStation");
					if (fieldCanUseStationFromStation == null)
						return;
				}
				fieldCanUseStationFromStation.SetValue(ptr, value.MonoCast());
			}
		}
		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRCStation", "VRC.SDKBase");
	}
}
