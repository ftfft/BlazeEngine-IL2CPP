using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.SDKBase
{
	public class VRCPlayerApi : IL2Base
	{
		public VRCPlayerApi(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		unsafe public void SetVelocity(Vector3 motion)
		{
			Instance_Class.GetMethod(nameof(SetVelocity)).Invoke(ptr, new IntPtr[] { new IntPtr(&motion) });
		}

		public static IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRCPlayerApi", "VRC.SDKBase");
	}
}
