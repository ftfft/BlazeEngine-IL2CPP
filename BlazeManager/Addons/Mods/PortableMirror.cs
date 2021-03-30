using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCSDK2;
using UnityEngine;

namespace Addons.Mods
{
	public static class PortableMirror
	{
		public static void UpdateStatus()
		{
			if (!BlazeManagerMenu.Main.singleList.ContainsKey("LocalMirror"))
				return;

			var menu = BlazeManagerMenu.Main.singleList["LocalMirror"];
			if (_isEnable)
			{
				menu.setButtonText("<color=red>Destroy</color>\nLocal Mirror");
				menu.setToolTip("Destroy Portable Mirror (Local).");
				return;
			}
			menu.setButtonText("Spawn\nLocal Mirror");
			menu.setToolTip("Spawn Portable Mirror (Local).");
		}

		public static void OnCreate()
		{
			OnDestroy(false);
		
			Transform transform = VRC.Player.Instance.transform;
			Vector3 position = transform.position + (transform.forward * 2);
			position.y += _mirrorScaleY / 2f;

            #region Create Object
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
			gameObject.transform.position = position;
			gameObject.transform.rotation = transform.rotation;
			gameObject.transform.localScale = new Vector3(_mirrorScaleX, _mirrorScaleY, 1f);
			gameObject.GetComponent<Collider>()?.Destroy();
			#endregion
			#region BoxCollider
			BoxCollider boxCollider = gameObject.GetOrAddComponent<BoxCollider>();
			boxCollider.size = new Vector3(1f, 1f, 0.05f);
			boxCollider.isTrigger = true;
			#endregion
			#region MeshRender
			MeshRenderer meshRenderer = gameObject.GetOrAddComponent<MeshRenderer>();
			meshRenderer.material.shader = Shader.Find("FX/MirrorReflection");
			#endregion
			#region MirrorReflection
			VRC_MirrorReflection mirrorReflection = gameObject.GetOrAddComponent<VRC_MirrorReflection>();
			LayerMask reflectLayers = new LayerMask();
			reflectLayers.value = (_optimizedMirror ? 263680 : -1025);
			mirrorReflection.m_ReflectLayers = reflectLayers;
			#endregion
			#region VRCPickup
			VRC_Pickup pickup = gameObject.GetOrAddComponent<VRC_Pickup>();
			pickup.proximity = 0.3f;
			pickup.pickupable = _canPickupMirror;
			pickup.allowManipulationWhenEquipped = false;
			#endregion
			#region Rigidbody
			Rigidbody rigidbody = gameObject.GetOrAddComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			#endregion

			PortableMirror.gameObject = gameObject;
			_isEnable = true;
			UpdateStatus();
		}

		public static void OnDestroy(bool updateStatus = true)
        {
			gameObject?.gameObject?.Destroy();
			if (updateStatus)
			{
				_isEnable = false;
				gameObject = null;
				UpdateStatus();
			}
		}

		private static GameObject gameObject = null;

		private static float _mirrorScaleX = 5f;

		private static float _mirrorScaleY = 3f;

		private static bool _optimizedMirror = true;

		private static bool _canPickupMirror = true;

		public static bool _isEnable = false;
	}
}
