using System;
using BE4v.SDK.CPP2IL;

namespace VRCSDK2
{
	public class VRC_MirrorReflection : VRC.SDKBase.VRC_MirrorReflection
	{
		public VRC_MirrorReflection(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["VRCSDK2"].GetClass("VRC_MirrorReflection", "VRCSDK2");
	}
}
