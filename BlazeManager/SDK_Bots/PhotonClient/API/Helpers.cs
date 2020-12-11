using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;
using PhotonClient.API.Structures;

namespace PhotonClient.API
{
	internal static class Helpers
	{
		public static bool InstantiateSelf()
		{
			InstantiateParameters parameters = new InstantiateParameters("VRCPlayer", new Vector3(-18f, 0f, 0f), new Quaternion(0f, 0f, 0f, 1f), 0, null, 0, new int[]
			{
				int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber.ToString() + "00001"),
				int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber.ToString() + "00002"),
				int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber.ToString() + "00003"),
			}, PhotonNetwork.NetworkingClient.LocalPlayer, PhotonNetwork.NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds);
			int intID = parameters.viewIDs[0];
			SendInstantiateEvHashtable.Clear();
			SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
			SendInstantiateEvHashtable[(byte)1] = parameters.position;
			SendInstantiateEvHashtable[(byte)2] = parameters.rotation;
			if (parameters.viewIDs.Length > 1)
			{
				SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
			}
			SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
			SendInstantiateEvHashtable[(byte)7] = intID;

			SendInstantiateRaiseEventOptions = RaiseEventOptions.Default;
			SendInstantiateRaiseEventOptions.CachingOption = EventCaching.AddToRoomCache;
			return PhotonNetwork.NetworkingClient.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
		}

		private class FlatBufferNetworkSerializer
		{
			private class InterestRecord
			{
				public InterestRecord(int _viewId, byte _updateFrequency, FlatBufferNetworkSerializer _serializer, byte _voiceQuality)
				{
					viewId = _viewId;
					updateFrequency = _updateFrequency;
					serializer = _serializer;
					voiceQuality = _voiceQuality;
				}

				public int viewId;

				public byte updateFrequency;

				public FlatBufferNetworkSerializer serializer;

				public byte voiceQuality;
			}
		}


		public static void ListDetails(this Player player)
		{
			foreach (object obj in player.CustomProperties)
			{
				DictionaryEntry entry = (DictionaryEntry)obj;
				bool flag = (string)entry.Key == "user";
				if (flag)
				{
					Console.WriteLine("user: {");
					foreach (KeyValuePair<string, object> kvp in ((Dictionary<string, object>)entry.Value))
					{
						bool flag2 = kvp.Key == "tags";
						if (flag2)
						{
							Console.WriteLine("tags: {");
							object[] array = (object[])kvp.Value;
							array.ToList<object>().ForEach(delegate (object a)
							{
								Console.WriteLine(a.ToString());
							});
							Console.WriteLine("}");
						}
						else
						{
							Console.WriteLine(string.Format("{0} : {1}", kvp.Key, kvp.Value));
						}
					}
					Console.WriteLine("}");
				}
				else
				{
					bool flag3 = (string)entry.Key == "avatarDict";
					if (flag3)
					{
						Console.WriteLine("avatarDict: {");
						foreach (KeyValuePair<string, object> kvp2 in ((Dictionary<string, object>)entry.Value))
						{
							bool flag4 = kvp2.Key == "tags";
							if (flag4)
							{
								Console.WriteLine("tags: {");
								object[] array2 = (object[])kvp2.Value;
								array2.ToList<object>().ForEach(delegate (object a)
								{
									Console.WriteLine(a.ToString());
								});
								Console.WriteLine("}");
							}
							else
							{
								bool flag5 = kvp2.Key == "unityPackages";
								if (flag5)
								{
									Console.WriteLine("unityPackages: {");
									object[] array3 = (object[])kvp2.Value;
									int index = 0;
									array3.ToList<object>().ForEach(delegate (object a)
									{
										index++;
										Console.WriteLine(string.Format("\t{0}: {{", index));
										foreach (KeyValuePair<string, object> kvp3 in ((Dictionary<string, object>)a))
										{
											Console.WriteLine("\t\t" + kvp3.Key + " : " + kvp3.Value.ToString());
										}
										Console.WriteLine("\t}");
									});
									Console.WriteLine("}");
								}
								else
								{
									Console.WriteLine(string.Format("{0} : {1}", kvp2.Key, kvp2.Value));
								}
							}
						}
						Console.WriteLine("}");
					}
					else
					{
						Console.WriteLine(string.Format("{0} : {1}", entry.Key, entry.Value));
					}
				}
			}
		}

		public static Player ActorNumberToPlayer(int an)
		{
			return PhotonNetwork.NetworkingClient.CurrentRoom.Players.Values.FirstOrDefault((Player p) => p.ActorNumber == an);
		}

		public static IPAddress ToIPAddress(this uint ip)
		{
			return new IPAddress(new byte[]
			{
				(byte)(ip >> 24 & 255U),
				(byte)(ip >> 16 & 255U),
				(byte)(ip >> 8 & 255U),
				(byte)(ip & 255U)
			});
		}


		private static readonly Hashtable SendInstantiateEvHashtable = new Hashtable();

		private static RaiseEventOptions SendInstantiateRaiseEventOptions = new RaiseEventOptions();
	}
}
