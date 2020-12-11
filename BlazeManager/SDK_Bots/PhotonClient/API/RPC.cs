using System;
using System.Text;
using VRC.SDKBase;
using ExitGames.Client.Photon;

namespace PhotonClient.API
{
	public class RPC
	{
		public static byte[] Serialize(object customType)
		{
			return new byte[32768];
		}

		public static object Deserialize(byte[] data)
		{
			RPC rpc = new RPC();
			int num = 0;
			float num2;
			Protocol.Deserialize(out num2, data, ref num);
			int num3;
			Protocol.Deserialize(out num3, data, ref num);
			short num4;
			Protocol.Deserialize(out num4, data, ref num);
			rpc.rpcName = Encoding.UTF8.GetString(data, num, (int)num4);
			num += (int)num4;
			int num5;
			Protocol.Deserialize(out num5, data, ref num);
			rpc.eventType = (VRC_EventHandler.VrcEventType)Enum.ToObject(typeof(VRC_EventHandler.VrcEventType), num5);
			short num6;
			Protocol.Deserialize(out num6, data, ref num);
			int num7;
			Protocol.Deserialize(out num7, data, ref num);
			float num8;
			Protocol.Deserialize(out num8, data, ref num);
			int num9;
			Protocol.Deserialize(out num9, data, ref num);
			Protocol.Deserialize(out num4, data, ref num);
			rpc.parameterString = Encoding.UTF8.GetString(data, num, (int)num4);
			num += (int)num4;
			try
			{
				float num10;
				Protocol.Deserialize(out num10, data, ref num);
				short num11;
				Protocol.Deserialize(out num11, data, ref num);
				rpc.broadcastType = (VRC_EventHandler.VrcBroadcastType)Enum.ToObject(typeof(VRC_EventHandler.VrcBroadcastType), num11);
				short num12;
				Protocol.Deserialize(out num12, data, ref num);
				rpc.parameterBytes = new byte[(int)num12];
				bool flag = num12 > 0;
				if (flag)
				{
					Array.Copy(data, num, rpc.parameterBytes, 0, (int)num12);
				}
				num += (int)num12;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				rpc.parameterBytes = new byte[0];
			}
			Console.WriteLine(string.Format("RPC Received | Target {0} : ParamString {1} : EvType {2} : BroadcType {3} : SizeOfParamsBytes {4}", new object[]
			{
				rpc.rpcName,
				string.IsNullOrEmpty(rpc.parameterString) ? "-empty-" : rpc.parameterString,
				rpc.eventType.ToString(),
				rpc.broadcastType.ToString(),
				rpc.parameterBytes.Length
			}));
			return rpc;
		}

		public string rpcName;

		public string parameterString;

		public VRC_EventHandler.VrcEventType eventType;

		public VRC_EventHandler.VrcBroadcastType broadcastType;

		public byte[] parameterBytes;
	}
}
