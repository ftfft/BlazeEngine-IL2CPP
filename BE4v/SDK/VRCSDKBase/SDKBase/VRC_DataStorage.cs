using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_DataStorage : MonoBehaviour
	{
		public VRC_DataStorage(IntPtr ptr) : base(ptr) => this.ptr = ptr;


		public enum VrcDataMirror
		{
			None,
			Animator,
			SerializeComponent
		}

		public enum VrcDataType
		{
			None,
			Bool,
			Int,
			Float,
			String,
			SerializeBytes,
			SerializeObject,
			Other
		}

		public class VrcDataElement : IL2Base
		{
			public VrcDataElement(IntPtr ptr) : base(ptr) => this.ptr = ptr;

			public VrcDataElement() : base(IntPtr.Zero)
			{
				ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
				Instance_Class.GetMethod(".ctor").Invoke(ptr);
			}


			public bool Serialize<T>(T objectToSerialize)
			{
				return default(bool);
			}
			/*
			public bool Deserialize<T>(out T objectToDeserialize)
			{
				return default(bool);
			}
			*/

			public string name;

			public VrcDataMirror mirror;

			unsafe public VrcDataType type
            {
				get => Instance_Class.GetField(nameof(type)).GetValue(ptr).GetValuе<VrcDataType>();
				set => Instance_Class.GetField(nameof(type)).SetValue(ptr, new IntPtr(&value));
            }

			public MonoBehaviour serializeComponent;

			unsafe public bool valueBool
            {
				get => Instance_Class.GetField(nameof(valueBool)).GetValue(ptr).GetValuе<bool>();
				set => Instance_Class.GetField(nameof(valueBool)).SetValue(ptr, new IntPtr(&value));
            }


			unsafe public int valueInt
			{
				get => Instance_Class.GetField(nameof(valueInt)).GetValue(ptr).GetValuе<int>();
				set => Instance_Class.GetField(nameof(valueInt)).SetValue(ptr, new IntPtr(&value));
			}

			unsafe public float valueFloat
			{
				get => Instance_Class.GetField(nameof(valueFloat)).GetValue(ptr).GetValuе<float>();
				set => Instance_Class.GetField(nameof(valueFloat)).SetValue(ptr, new IntPtr(&value));
			}

			public string valueString
			{
				get => Instance_Class.GetField(nameof(type)).GetValue(ptr).GetValue<string>();
				set => Instance_Class.GetField(nameof(type)).SetValue(ptr, new IL2String(value).ptr);
			}

			public byte[] valueSerializedBytes;

			public bool modified;

			public bool added;

			public VRC_DataStorage dataStorage;

			public static IL2Class Instance_Class = VRC_DataStorage.Instance_Class.GetNestedType("VrcDataElement");
		}

		public static new IL2Class Instance_Class = Assembler.list["VRCSDKBase"].GetClass("VRC_DataStorage", "VRC.SDKBase");
	}
}
