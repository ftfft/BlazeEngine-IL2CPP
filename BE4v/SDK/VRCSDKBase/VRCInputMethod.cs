using BE4v.SDK.CPP2IL;
using System;

namespace VRC.SDKBase
{
	public enum VRCInputMethod
	{
		Keyboard,
		Mouse,
		Controller,
		Gaze,
		Vive = 5,
		Oculus,
		Count
	}

	public class VRCInputMethod_Class : IL2Base
	{
		public VRCInputMethod_Class(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRCInputMethod", "VRC.SDKBase");
	}
}
