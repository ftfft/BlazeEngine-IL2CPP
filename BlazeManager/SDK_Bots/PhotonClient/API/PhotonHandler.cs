using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Photon.Realtime;

namespace PhotonClient.API
{
	internal class PhotonHandler : IConnectionCallbacks, ILobbyCallbacks, IInRoomCallbacks, IMatchmakingCallbacks
	{
		public PhotonHandler()
		{
			Instance = this;
			Client = PhotonNetwork.NetworkingClient;
			dispatchInThread = new Thread(new ThreadStart(IncomingUpdate));
			dispatchInThread.IsBackground = true;
			dispatchInThread.Start();
			sendOutThread = new Thread(new ThreadStart(OutgoingUpdate));
			sendOutThread.IsBackground = true;
			sendOutThread.Start();
		}

		private void IncomingUpdate()
		{
			for (; ; )
			{
				this.In();
				Thread.Sleep(10);
			}
		}

		private void In()
		{
			bool flag = Environment.TickCount - this.lastDispatch > this.intervalDispatch;
			if (flag)
			{
				this.lastDispatch = Environment.TickCount;
				PhotonHandler.Client.LoadBalancingPeer.DispatchIncomingCommands();
			}
		}

		private void OutgoingUpdate()
		{
			for (; ; )
			{
				this.Out();
				Thread.Sleep(10);
			}
		}

		private void Out()
		{
			bool flag = Environment.TickCount - this.lastSend > this.intervalSend;
			if (flag)
			{
				this.lastSend = Environment.TickCount;
				Client.LoadBalancingPeer.SendOutgoingCommands();
			}
		}

		public void OnConnected()
		{
			Console.WriteLine("[INFO] Connected to Photon!");
		}

		public void OnConnectedToMaster()
		{
			Console.WriteLine("[INFO] Connected to Masterserver");
			Hashtable hashtable = new Hashtable
			{
				{
					"user",
					new Dictionary<string, object>
					{
						{
							"id",
							Variables.user.id
						}
					}
				},
				{
					"avatarDict",
					new Dictionary<string, object>
					{
						{
							"id",
							Variables.user.currentAvatar
						}
					}
				},
				{
					"modTag",
					""
				},
				{
					"isInvisible",
					false
				},
				{
					"avatarVariations",
					Variables.user.currentAvatar
				},
				{
					"status",
					"active"
				},
				{
					"statusDescription",
					"x"
				},
				{
					"inVRMode",
					false
				},
				{
					"showSocialRank",
					true
				},
				{
					"steamUserID",
					0.ToString()
				}
			};
			PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
			Console.WriteLine(((PhotonNetwork.LocalPlayer.CustomProperties.Count > 0) ? string.Format("I have ({0}) custom properties", PhotonNetwork.LocalPlayer.CustomProperties.Count) : "I have no custom properties") ?? "");
		}

		public void OnCreatedRoom()
		{
			Console.WriteLine("[INFO] Successfully created a room!");
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			Console.WriteLine("[ERROR] Unable to create a room! ErrorCode: {0}\nErrorMessage: {1}", returnCode, message);
		}

		public void OnCustomAuthenticationFailed(string debugMessage)
		{
			Console.WriteLine("[ERROR] Couldn't authenticate to VRChat! ErrorMessage: {0}", debugMessage);
		}

		public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
		{
			Console.WriteLine("[INFO] Authentication response received!");
		}

		public void OnDisconnected(DisconnectCause cause)
		{
			Console.WriteLine("[INFO] Disconnected! Reason: {0}", cause.ToString());
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnJoinedLobby()
		{
			Console.WriteLine("[INFO] Successfully joined lobby!");
		}

		public void OnJoinedRoom()
		{
			Console.WriteLine("[INFO] Successfully joined room!");
			PhotonNetwork.PlayerList.ToList().ForEach(p => Console.WriteLine($"{p.displayName.PadRight(30, ' ')} (ID: {p.ActorNumber}{(p.IsMasterClient ? "(Master)" : "")})"));
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			Console.WriteLine("[ERROR] Failed to join room! ErrorCode: {0}\nErrorMessage {1}", returnCode, message);
		}

		public void OnLeftLobby()
		{
			Console.WriteLine("[INFO] Left the lobby!");
		}

		public void OnLeftRoom()
		{
			Console.WriteLine("[INFO] Left the room!");
		}

		public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
		{
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
			Console.WriteLine("[INFO] Masterclient got switched! New Masterclient: {0}", newMasterClient.displayName);
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
			Console.WriteLine("[INFO] New Player joined: {0}", newPlayer.displayName);
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
			Console.WriteLine("[INFO] Player left room: {0}", otherPlayer.displayName);
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
			Console.WriteLine("[INFO] Playerproperties Update from {0}", targetPlayer.displayName);
		}

		public void OnRegionListReceived(RegionHandler regionHandler)
		{
		}

		public void OnRoomListUpdate(List<RoomInfo> roomList)
		{
		}

		public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
			Console.WriteLine("[INFO] Roomproperties changed!");
		}

		private static PhotonHandler Instance;

		private static LoadBalancingClient Client;

		private int intervalDispatch = 10;

		private int lastDispatch = Environment.TickCount;

		private int intervalSend = 50;

		private int lastSend = Environment.TickCount;

		private readonly Thread dispatchInThread;

		private readonly Thread sendOutThread;
	}
}
