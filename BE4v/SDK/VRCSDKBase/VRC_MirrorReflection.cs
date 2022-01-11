using BE4v.SDK.CPP2IL;
using System;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_MirrorReflection : MonoBehaviour
	{
		public VRC_MirrorReflection(IntPtr ptr) : base(ptr) => this.ptr = ptr;
		public bool m_DisablePixelLights;

		public bool TurnOffMirrorOcclusion;

		unsafe public LayerMask m_ReflectLayers
		{
			get => Instance_Class.GetField(nameof(m_ReflectLayers)).GetValue(ptr).GetValuе<LayerMask>();
			set => Instance_Class.GetField(nameof(m_ReflectLayers)).SetValue(ptr, new IntPtr(&value));
		}

		private enum Dimension
		{
			Auto,
			X256 = 256,
			X512 = 512,
			X1024 = 1024
		}

		private enum AntialiasingSamples
		{
			X1 = 1,
			X2,
			X4 = 4,
			X8 = 8
		}

		public static new IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRC_MirrorReflection", "VRC.SDKBase");
	}
}
