using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.SDKBase
{
	public class VRCPlayerApi : IL2Base
	{
		public VRCPlayerApi(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public static IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRCPlayerApi", "VRC.SDKBase");
	}
}
