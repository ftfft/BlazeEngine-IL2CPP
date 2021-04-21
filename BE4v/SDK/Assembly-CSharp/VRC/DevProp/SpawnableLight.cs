using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.DevProp
{
    public class SpawnableLight : MonoBehaviour
    {
        public SpawnableLight(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public struct Preset
		{
			public LightType lightType;

			public float range;

			public float angle;

			public Color color;

			public float intensity;

			public LightShadows shadowType;
		}

		public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("SetPresetRPC") != null);
    }
}