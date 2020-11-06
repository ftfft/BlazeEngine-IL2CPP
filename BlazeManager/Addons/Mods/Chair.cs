using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCSDK2;
using UnityEngine;
using VRC.SDKBase;

namespace Addons.Mods
{
	public static class Chair
	{
		public static void UpdateStatus()
		{
		}

		public static void OnCreate()
		{
			OnDestroy(false);
		
			Transform transform = VRC.Player.Instance.transform;
			Vector3 position = transform.position + (transform.forward * 2);
			position.y += _mirrorScaleY / 2f;

            #region Create Object
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.transform.position = position;
			gameObject.transform.rotation = transform.rotation;
			// gameObject.transform.localScale = new Vector3(_mirrorScaleX, _mirrorScaleY, 1f);
			gameObject.name = objName;
			// gameObject.GetComponent<BoxCollider>().Destroy();
			// gameObject.GetComponent<MeshFilter>().Destroy();
			// gameObject.GetComponent<MeshRenderer>().Destroy();
			#endregion
			#region MirrorReflection
			VRC_Station station;
			if ((station = gameObject.GetComponent<VRC_Station>()) == null)
				station = gameObject.AddComponent<VRC_Station>();

			VRC_EventHandler eventHandler;
			if ((eventHandler = gameObject.GetComponent<VRC_EventHandler>()) == null)
				eventHandler = gameObject.AddComponent<VRC_EventHandler>();
			VRC_StationInternal2 stationInternal2;
			if ((stationInternal2 = gameObject.GetComponent<VRC_StationInternal2>()) == null)
				stationInternal2 = gameObject.AddComponent<VRC_StationInternal2>();
			VRC_TriggerInternal triggerInternal;
			if ((triggerInternal = gameObject.GetComponent<VRC_TriggerInternal>()) == null)
				triggerInternal = gameObject.AddComponent<VRC_TriggerInternal>();
			BoxCollider collider;
			if ((collider = gameObject.GetComponent<BoxCollider>()) == null)
				collider = gameObject.AddComponent<BoxCollider>();
			collider.isTrigger = true;
			#endregion

		}

		public static void OnDestroy(bool updateStatus = true)
        {
            GameObject.Find(objName)?.Destroy();
			if (updateStatus)
			{
				_isEnable = false;
				UpdateStatus();
			}
		}

		public static string objName = UserUtils.prefix + "Chair";

		private static float _mirrorScaleY = 3f;

		public static bool _isEnable = false;
	}
}
