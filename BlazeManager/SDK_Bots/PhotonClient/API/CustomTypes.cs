using System;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace PhotonClient.API
{
	internal static class CustomTypes
	{
		internal static void Register()
		{
			PhotonPeer.RegisterType(typeof(Vector2), 87, new SerializeStreamMethod(SerializeVector2), new DeserializeStreamMethod(DeserializeVector2));
			PhotonPeer.RegisterType(typeof(Vector3), 86, new SerializeStreamMethod(SerializeVector3), new DeserializeStreamMethod(DeserializeVector3));
			PhotonPeer.RegisterType(typeof(Quaternion), 81, new SerializeStreamMethod(SerializeQuaternion), new DeserializeStreamMethod(DeserializeQuaternion));
			PhotonPeer.RegisterType(typeof(Player), 80, new SerializeStreamMethod(SerializePhotonPlayer), new DeserializeStreamMethod(DeserializePhotonPlayer));
			PhotonPeer.RegisterType(typeof(Vector4), 101, new SerializeStreamMethod(SerializeVector4), new DeserializeStreamMethod(DeserializeVector4));
			PhotonPeer.RegisterType(typeof(RPC), 102, new SerializeMethod(RPC.Serialize), new DeserializeMethod(RPC.Deserialize));
		}

		private static short SerializeVector3(StreamBuffer outStream, object customobject)
		{
			Vector3 vo = (Vector3)customobject;
			int index = 0;
			byte[] obj = memVector3;
			lock (obj)
			{
				byte[] bytes = memVector3;
				Protocol.Serialize(vo.x, bytes, ref index);
				Protocol.Serialize(vo.y, bytes, ref index);
				Protocol.Serialize(vo.z, bytes, ref index);
				outStream.Write(bytes, 0, 12);
			}
			return 12;
		}

		private static object DeserializeVector3(StreamBuffer inStream, short length)
		{
			Vector3 vo = default(Vector3);
			byte[] obj = memVector3;
			lock (obj)
			{
				inStream.Read(memVector3, 0, 12);
				int index = 0;
				Protocol.Deserialize(out vo.x, memVector3, ref index);
				Protocol.Deserialize(out vo.y, memVector3, ref index);
				Protocol.Deserialize(out vo.z, memVector3, ref index);
			}
			return vo;
		}

		private static short SerializeVector2(StreamBuffer outStream, object customobject)
		{
			Vector2 vo = (Vector2)customobject;
			byte[] obj = memVector2;
			lock (obj)
			{
				byte[] bytes = memVector2;
				int index = 0;
				Protocol.Serialize(vo.x, bytes, ref index);
				Protocol.Serialize(vo.y, bytes, ref index);
				outStream.Write(bytes, 0, 8);
			}
			return 8;
		}

		private static object DeserializeVector2(StreamBuffer inStream, short length)
		{
			Vector2 vo = default(Vector2);
			byte[] obj = memVector2;
			lock (obj)
			{
				inStream.Read(memVector2, 0, 8);
				int index = 0;
				Protocol.Deserialize(out vo.x, memVector2, ref index);
				Protocol.Deserialize(out vo.y, memVector2, ref index);
			}
			return vo;
		}

		private static short SerializeQuaternion(StreamBuffer outStream, object customobject)
		{
			Quaternion o = (Quaternion)customobject;
			byte[] obj = memQuarternion;
			lock (obj)
			{
				byte[] bytes = memQuarternion;
				int index = 0;
				Protocol.Serialize(o.w, bytes, ref index);
				Protocol.Serialize(o.x, bytes, ref index);
				Protocol.Serialize(o.y, bytes, ref index);
				Protocol.Serialize(o.z, bytes, ref index);
				outStream.Write(bytes, 0, 16);
			}
			return 16;
		}

		private static object DeserializeQuaternion(StreamBuffer inStream, short length)
		{
			Quaternion o = default(Quaternion);
			byte[] obj = memQuarternion;
			lock (obj)
			{
				inStream.Read(memQuarternion, 0, 16);
				int index = 0;
				Protocol.Deserialize(out o.w, memQuarternion, ref index);
				Protocol.Deserialize(out o.x, memQuarternion, ref index);
				Protocol.Deserialize(out o.y, memQuarternion, ref index);
				Protocol.Deserialize(out o.z, memQuarternion, ref index);
			}
			return o;
		}

		private static short SerializeVector4(StreamBuffer outStream, object customobject)
		{
			Vector4 o = (Vector4)customobject;
			byte[] obj = memQuarternion;
			lock (obj)
			{
				byte[] bytes = memQuarternion;
				int index = 0;
				Protocol.Serialize(o.w, bytes, ref index);
				Protocol.Serialize(o.x, bytes, ref index);
				Protocol.Serialize(o.y, bytes, ref index);
				Protocol.Serialize(o.z, bytes, ref index);
				outStream.Write(bytes, 0, 16);
			}
			return 16;
		}

		private static object DeserializeVector4(StreamBuffer inStream, short length)
		{
			Vector4 o = default(Vector4);
			byte[] obj = memQuarternion;
			lock (obj)
			{
				inStream.Read(memQuarternion, 0, 16);
				int index = 0;
				Protocol.Deserialize(out o.w, memQuarternion, ref index);
				Protocol.Deserialize(out o.x, memQuarternion, ref index);
				Protocol.Deserialize(out o.y, memQuarternion, ref index);
				Protocol.Deserialize(out o.z, memQuarternion, ref index);
			}
			return o;
		}

		private static short SerializePhotonPlayer(StreamBuffer outStream, object customobject)
		{
			int ID = ((Player)customobject).ActorNumber;
			byte[] obj = memPlayer;
			short result;
			lock (obj)
			{
				byte[] bytes = memPlayer;
				int off = 0;
				Protocol.Serialize(ID, bytes, ref off);
				outStream.Write(bytes, 0, 4);
				result = 4;
			}
			return result;
		}

		private static object DeserializePhotonPlayer(StreamBuffer inStream, short length)
		{
			byte[] obj = memPlayer;
			int ID;
			lock (obj)
			{
				inStream.Read(memPlayer, 0, (int)length);
				int off = 0;
				Protocol.Deserialize(out ID, memPlayer, ref off);
			}
			bool flag2 = PhotonNetwork.NetworkingClient.CurrentRoom != null;
			object result;
			if (flag2)
			{
				Player player = PhotonNetwork.NetworkingClient.CurrentRoom.GetPlayer(ID);
				result = player;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static readonly byte[] memVector3 = new byte[12];

		public static readonly byte[] memVector2 = new byte[8];

		public static readonly byte[] memQuarternion = new byte[16];

		public static readonly byte[] memVector4 = new byte[16];

		public static readonly byte[] memPlayer = new byte[4];
	}
}
