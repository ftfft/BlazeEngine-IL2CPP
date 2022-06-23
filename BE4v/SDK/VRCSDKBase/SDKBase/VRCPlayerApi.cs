using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public class VRCPlayerApi : IL2Object
	{
		public VRCPlayerApi(IntPtr ptr) : base(ptr) { }

		unsafe public void SetVelocity(Vector3 motion)
		{
			Instance_Class.GetMethod(nameof(SetVelocity)).Invoke(this, new IntPtr[] { new IntPtr(&motion) });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRCPlayerApi", "VRC.SDKBase");
	}
}
