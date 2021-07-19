using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class SteamVR_ExternalCamera : MonoBehaviour
{
    public SteamVR_ExternalCamera(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public struct Config
	{
		public float x;

		public float y;

		public float z;

		public float rx;

		public float ry;

		public float rz;

		public float fov;

		public float near;

		public float far;

		public float sceneResolutionScale;

		public float frameSkip;

		public float nearOffset;

		public float farOffset;

		public float hmdOffset;

		public float r;

		public float g;

		public float b;

		public float a;

		public bool disableStandardAssets;
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByNesestTypedName("Config");
}