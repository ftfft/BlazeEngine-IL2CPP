using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

namespace VRC.SDKBase
{
	// Token: 0x0200006A RID: 106
	public abstract class VRC_MirrorReflection : MonoBehaviour
	{
		public VRC_MirrorReflection(IntPtr ptr) : base(ptr) => this.ptr = ptr;
		/*
		private void OnValidate()
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00002050 File Offset: 0x00000250
		private void Start()
		{
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00002050 File Offset: 0x00000250
		public void OnWillRenderObject()
		{
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00002050 File Offset: 0x00000250
		private void CameraPostRender(Camera currentCamera)
		{
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00002050 File Offset: 0x00000250
		private void OnDisable()
		{
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00002050 File Offset: 0x00000250
		private void OnDestroy()
		{
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00002050 File Offset: 0x00000250
		private bool ShouldRenderLeftEye(Camera cam)
		{
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00002050 File Offset: 0x00000250
		private bool ShouldRenderRightEye(Camera cam)
		{
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00002050 File Offset: 0x00000250
		private bool ShouldRenderMonoscopic(Camera cam)
		{
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00002050 File Offset: 0x00000250
		private Vector3 GetWorldEyePos(Camera cam, XRNode eye)
		{
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00002050 File Offset: 0x00000250
		private Quaternion GetWorldEyeRot(Camera cam, XRNode eye)
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00002050 File Offset: 0x00000250
		private Matrix4x4 GetEyeProjectionMatrix(Camera cam, XRNode eye)
		{
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00002050 File Offset: 0x00000250
		private Vector3 GetNormalDirection()
		{
		}

		// Token: 0x06000192 RID: 402 RVA: 0x00002050 File Offset: 0x00000250
		private void RenderMirror(RenderTexture targetTexture, Vector3 camPosition, Quaternion camRotation, Matrix4x4 camProjectionMatrix)
		{
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00002050 File Offset: 0x00000250
		private void UpdateCameraModes(Camera src)
		{
		}

		// Token: 0x06000194 RID: 404 RVA: 0x00002050 File Offset: 0x00000250
		private void UpdateParentTransform(Camera cam)
		{
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00002050 File Offset: 0x00000250
		private VRC_MirrorReflection.ReflectionData GetReflectionData(Camera currentCamera)
		{
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00002050 File Offset: 0x00000250
		private static void GetAutoResolution(Camera currentCamera, [Out] int width, [Out] int height)
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00002050 File Offset: 0x00000250
		private static Vector4 Plane(Vector3 pos, Vector3 normal)
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00002050 File Offset: 0x00000250
		private static Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal)
		{
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00002050 File Offset: 0x00000250
		private static Matrix4x4 CalculateReflectionMatrix(Vector4 plane)
		{
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00002050 File Offset: 0x00000250
		private static float CopySign(float sizeValue, float signValue)
		{
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00002050 File Offset: 0x00000250
		private static Quaternion GetRotation(Matrix4x4 matrix)
		{
		}

		private static Vector3 GetPosition(Matrix4x4 matrix)
		{
		}*/

		public bool m_DisablePixelLights;

		public bool TurnOffMirrorOcclusion;

		public LayerMask m_ReflectLayers
		{
			get => Instance_Class.GetField(nameof(m_ReflectLayers)).GetValue(ptr).unbox_Unmanaged<LayerMask>();
			set => Instance_Class.GetField(nameof(m_ReflectLayers)).SetValue(ptr, value.MonoCast());
		}

		// private VRC_MirrorReflection.Dimension mirrorResolution;

		// private VRC_MirrorReflection.AntialiasingSamples maximumAntialiasing;

		//private Shader customShader;

		//private RenderTexture _temporaryRenderTexture;

		//private Dictionary<Camera, VRC_MirrorReflection.ReflectionData> _mReflections;

		//private Renderer _mirrorRenderer;

		// private Camera _mirrorCamera;

		//private Skybox _mirrorSkybox;

		//private Matrix4x4 _parentTransform;

		//private Quaternion _parentRotation;
		
		//private int _playerLocalLayer;

		//private static bool _sInsideRendering;

		//private static readonly int[] _texturePropertyId;

		//private const int MAX_AUTO_VR_RESOLUTION_WIDTH = 2048;

		//private const int MAX_AUTO_VR_RESOLUTION_HEIGHT = 2048;

		//private const int MAX_AUTO_DESKTOP_RESOLUTION_WIDTH = 2048;

		//private const int MAX_AUTO_DESKTOP_RESOLUTION_HEIGHT = 2048;

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
		/*
		private class ReflectionData
		{
			public readonly RenderTexture[] texture;

			public MaterialPropertyBlock propertyBlock;
		}
		*/
		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRC_MirrorReflection", "VRC.SDKBase");
	}
}
