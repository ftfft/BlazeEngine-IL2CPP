using System;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_EventDispatcher : MonoBehaviour
	{
		public VRC_EventDispatcher(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRC_EventDispatcher", "VRC.SDKBase");
	}
}
