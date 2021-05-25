using System;
using BE4v.SDK.CPP2IL;
using UnityEngine;
using VRC.SDKBase;

namespace VRC.SDK3.Avatars.Components
{
	public class VRCAvatarDescriptor : VRC_AvatarDescriptor
	{
		public VRCAvatarDescriptor(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["VRCSDK3A"].GetClass("VRCAvatarDescriptor", "VRC.SDK3.Avatars.Components");
	}
}
