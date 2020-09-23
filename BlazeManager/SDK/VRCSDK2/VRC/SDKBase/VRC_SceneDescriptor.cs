using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VRC.SDKBase
{
	public class VRC_SceneDescriptor : MonoBehaviour
	{
		public VRC_SceneDescriptor(IntPtr ptr) : base(ptr) => base.ptr = ptr;


		public enum SpawnOrientation
		{
			Default,
			AlignPlayerWithSpawnPoint,
			AlignRoomWithSpawnPoint
		}
	}
}
