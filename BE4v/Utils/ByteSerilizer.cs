using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;

namespace BE4v.Utils
{
	public static class ByteSerilizer
	{
		private static void Clear()
		{
			bytePos = 1;
			encBuffer.Clear();
			decBuffer = null;
			objectTypeCounts.Clear();
			objectCount = 1;
		}

		private static float DeserializeFloat()
		{
			bytePos += 4;
			return BitConverter.ToSingle(decBuffer, bytePos - 4);
		}
		private static void SerializeShort(short obj)
		{
			encBuffer.AddRange(BitConverter.GetBytes(obj));
		}

		private static short DeserializeShort()
		{
			bytePos += 2;
			return BitConverter.ToInt16(decBuffer, bytePos - 2);
		}

		private static void SerializeString(string obj)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(obj);
			SerializeShort((short)bytes.Length);
			encBuffer.AddRange(bytes);
		}

		private static string DeserializeString()
		{
			short num = DeserializeShort();
			bytePos += num;
			return Encoding.UTF8.GetString(decBuffer, bytePos - num, num);
		}

		/*
		private static object DeserializeTypeArray()
		{
			short num = DeserializeShort();
			BinarySerializer.TypeCode type = (BinarySerializer.TypeCode)decBuffer[bytePos++];
			Array array = Array.CreateInstance(BinarySerializer.CodeToType[type], (int)num);
			for (int i = 0; i < num; i++)
			{
				array.SetValue(DeserializeBytes(type), i);
			}
			return array;
		}
		*/

		private static Vector2 DeserializeVector2()
		{
			return new Vector2(DeserializeFloat(), DeserializeFloat());
		}

		private static Vector3 DeserializeVector3()
		{
			return new Vector3(DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}

		private static Vector4 DeserializeVector4()
		{
			return new Vector4(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}

		private static Quaternion DeserializeQuaternion()
		{
			return new Quaternion(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}
		private static Color DeserializeColor()
		{
			return new Color(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}
		private static Color32 DeserializeColor32()
		{
			return new Color32(decBuffer[bytePos++], decBuffer[bytePos++], decBuffer[bytePos++], decBuffer[bytePos++]);
		}
		/*
		private static VRC_EventLog.EventLogEntry DeserializeEventLogEntry()
		{
		}
		
		private VRC_SyncVideoPlayer.VideoEntry DeserializePlayerVideoEntry()
		{
			return new VRC_SyncVideoPlayer.VideoEntry
			{
				Source = VideoSource.Url,
				AspectRatio = (VideoAspectRatio)decBuffer[bytePos++],
				PlaybackSpeed = DeserializeFloat(),
				URL = DeserializeString()
			};
		}

		private static object DeserializeSerializableBehaviour()
		{
		}

		private static object DeserializeSerializableContainer()
		{
			return new ParameterSerialization.SerializableContainer
			{
				name = DeserializeString(),
				data = (byte[])DeserializeTypeArray()
			};
		}
		*/

		public static object Deserialize(byte[] bytes)
		{
			Clear();
			decBuffer = bytes;
			object result = null;
			try
			{
				result = DeserializeBytes();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to deserialize, no parameters will be returned: {ex.Message}");
			}
			return result;
		}

		private static object DeserializeBytes(BinarySerializer.TypeCode type = 0)
		{
			if (type == 0)
			{
				type = (BinarySerializer.TypeCode)decBuffer[bytePos++];
			}
			if (decBuffer.Length < bytePos)
			{
				throw new Exception("  i:");
			}
			switch (type)
			{
				case 0:
					return null;
				case (BinarySerializer.TypeCode)92:
					return DeserializeVector2();
				case (BinarySerializer.TypeCode)93:
					return DeserializeVector3();
				case (BinarySerializer.TypeCode)94:
					return DeserializeVector4();
				case (BinarySerializer.TypeCode)95:
					return DeserializeQuaternion();
				case (BinarySerializer.TypeCode)96:
					return DeserializeColor();
				case (BinarySerializer.TypeCode)97:
					return DeserializeColor32();
				// case (BinarySerializer.TypeCode)98:
				//	return DeserializeEventLogEntry();
				// case (BinarySerializer.TypeCode)99:
				//	return DeserializePlayerVideoEntry();
				// case BinarySerializer.TypeCode.VECTOR2:
				//	return DeserializeSerializableBehaviour();
				// case BinarySerializer.TypeCode.VECTOR3:
				//	return DeserializeSerializableContainer();
				/*case BinarySerializer.TypeCode.VECTOR4:
					return this.MIHPDNKKPIG();
				case BinarySerializer.TypeCode.QUATERNION:
					return this.CKCGNEMANID();
				case BinarySerializer.TypeCode.COLOR:
					return this.BDJBNMCJMDE();
				case BinarySerializer.TypeCode.COLOR32:
					return this.DMLFILDIMEJ();
				case BinarySerializer.TypeCode.NULL:
					return this.CFIBOPGIOKO[this.JOKIHFPBEAE++];
				case BinarySerializer.TypeCode.BYTE:
					return this.PIHGFOEHOAL();
				case BinarySerializer.TypeCode.DOUBLE:
					return this.LDKPJIMKKCJ();
				case BinarySerializer.TypeCode.FLOAT:
					return this.BACJFDEODHB();
				case BinarySerializer.TypeCode.INT:
					return this.FMKEJGOPJNL();
				case BinarySerializer.TypeCode.SHORT:
					return this.JDMLLPPLPKF();
				case BinarySerializer.TypeCode.LONG:
					return this.JOKLNCHAMFF();
				case BinarySerializer.TypeCode.BOOL:
					return this.PJBOPGBGFAD();
				case BinarySerializer.TypeCode.STRING:
					return this.FEMCEHBHINO();
				case BinarySerializer.TypeCode.OBJECT_ARRAY:
					return this.BEDAOHHGOHE();*/
				default:
					throw new Exception(",balance=" + type);
			}
		}

		private const short ObjectCountLimit = 2048;

		private static int bytePos;

		private static List<byte> encBuffer;

		private static byte[] decBuffer;

		private static Dictionary<BinarySerializer.TypeCode, short> objectTypeCounts;

		private static short objectCount;
	}
}
