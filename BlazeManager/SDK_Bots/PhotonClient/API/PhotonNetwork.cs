using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;
using PhotonClient.API.Response;

namespace PhotonClient.API
{
	public static class PhotonNetwork
	{
		internal static bool IsConnected
		{
			get
			{
				return NetworkingClient != null && NetworkingClient.IsConnected;
			}
		}

		internal static bool IsConnectedAndReady
		{
			get
			{
				return NetworkingClient != null && NetworkingClient.IsConnectedAndReady;
			}
		}

		public static bool isWaitState
		{
			get
			{
				return NetworkClientState == ClientState.ConnectingToGameServer || NetworkClientState == ClientState.ConnectingToMasterServer || NetworkClientState == ClientState.ConnectingToNameServer || NetworkClientState == ClientState.Authenticating;
			}
		}

		
		public static bool isJoined
		{
			get
			{
				return NetworkClientState == ClientState.Joined;
			}
		}



		public static ClientState NetworkClientState
		{
			get
			{
				ClientState result;
				if (NetworkingClient == null)
				{
					result = ClientState.Disconnected;
				}
				else
				{
					result = NetworkingClient.State;
				}
				return result;
			}
		}

		public static bool InRoom
		{
			get
			{
				return NetworkClientState == ClientState.Joined;
			}
		}

		public static AuthenticationValues AuthValues
		{
			get
			{
				return (NetworkingClient != null) ? NetworkingClient.AuthValues : null;
			}
			set
			{
				bool flag = NetworkingClient != null;
				if (flag)
				{
					NetworkingClient.AuthValues = value;
				}
			}
		}

		public static Room CurrentRoom
		{
			get
			{
				return (NetworkingClient == null) ? null : NetworkingClient.CurrentRoom;
			}
		}

		public static bool IsMasterClient
		{
			get
			{
				return NetworkingClient.CurrentRoom != null && NetworkingClient.CurrentRoom.MasterClientId == LocalPlayer.ActorNumber;
			}
		}
		
		
		public static Cmd command { get; set; }
		public static string target { get; set; }
		public enum Cmd
        {
			none,
			check,
			cloneAvatar
		}

		public static Player LocalPlayer
		{
			get
			{
				Player result;
				if (NetworkingClient == null)
				{
					result = null;
				}
				else
				{
					result = NetworkingClient.LocalPlayer;
				}
				return result;
			}
		}

		public static Player MasterClient
		{
			get
			{
				Player result;
				if (NetworkingClient == null || NetworkingClient.CurrentRoom == null)
				{
					result = null;
				}
				else
				{
					result = NetworkingClient.CurrentRoom.GetPlayer(NetworkingClient.CurrentRoom.MasterClientId);
				}
				return result;
			}
		}

		public static Player[] PlayerList
		{
			get
			{
				Room room = CurrentRoom;
				bool flag = room != null;
				Player[] result;
				if (flag)
				{
					result = (from x in room.Players.Values
							  orderby x.ActorNumber
							  select x).ToArray<Player>();
				}
				else
				{
					Console.WriteLine("Room was null");
					result = new Player[0];
				}
				return result;
			}
		}

		public static int ServerTimestamp
		{
			get
			{
				return NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds;
			}
		}

		private static string szAppVersion;
		public static string AppVersion
		{
			get
			{
				return szAppVersion;
			}
			set
			{
				szAppVersion = value;
				NetworkingClient.AppVersion = string.Format("{0}_{1}", value, "2.5");
			}
		}

		static PhotonNetwork()
		{
			ApiClient = new Client("blowblow666", "$OorT2URr1ai");
			NetworkingClient = new LoadBalancingClient(ConnectionProtocol.Udp);
			NetworkingClient.LoadBalancingPeer.QuickResendAttempts = 2;
			NetworkingClient.LoadBalancingPeer.SentCountAllowance = 7;
			NetworkingClient.LoadBalancingPeer.DebugOut = DebugLevel.ALL;
			NetworkingClient.EventReceived += OnEvent;
			NetworkingClient.OpResponseReceived += OnOperation;
			NetworkingClient.StateChanged += OnStateChanged;
			CustomTypes.Register();
			PhotonHandler = new PhotonHandler();
			NetworkingClient.AddCallbackTarget(PhotonHandler);
			NetworkingClient.AppId = "bf0942f7-9935-4192-b359-f092fa85bef1";
			AppVersion = VRCApplicationSetup.Instance.GetGameServerVersion();
			NetworkingClient.EnableLobbyStatistics = true;

			NetworkingClient.AuthValues = new AuthenticationValues
			{
				AuthType = CustomAuthenticationType.Custom
			};
			NetworkingClient.AuthValues.AddAuthParameter("token", Variables.AuthCookie);
			NetworkingClient.AuthValues.AddAuthParameter("user", Variables.user.id);
		}

		public static int GetPing()
		{
			return NetworkingClient.LoadBalancingPeer.RoundTripTime;
		}

		public static bool ConnectToNameServer()
		{
			/*
			if (IL2Photon.Pun.PhotonNetwork.serverSettings.AppSettings.IsBestRegion)
			{
				return NetworkingClient.ConnectToMasterServer();
			}
			*/
			return NetworkingClient.ConnectToRegionMaster(FixedRegion);
		}
		private static bool ConnectToMaster(string address, int port, string appId)
		{
			if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
			{
				Console.WriteLine("ConnectToMaster() failed. Can only connect while in state 'Disconnected'. Current state: " + NetworkingClient.LoadBalancingPeer.PeerState);
				return false;
			}
			NetworkingClient.State = ClientState.ConnectedToMasterServer;
			NetworkingClient.IsUsingNameServer = false;
			NetworkingClient.MasterServerAddress = ((port != 0) ? (address + ":" + port) : address);
			NetworkingClient.AppId = appId;
			return NetworkingClient.ConnectToMasterServer();
		}

		public static bool Connect()
		{
			bool flag = !string.IsNullOrEmpty(NetworkingClient.MasterServerAddress);
			bool result;
			if (flag)
			{
				result = NetworkingClient.ConnectToMasterServer();
			}
			else
			{
				result = NetworkingClient.ConnectToRegionMaster(FixedRegion);
			}
			return result;
		}

		public static void Disconnect()
		{
			bool flag = NetworkingClient == null;
			if (!flag)
			{
				NetworkingClient.Disconnect();
			}
		}

		public static bool Reconnect()
		{
			bool flag = string.IsNullOrEmpty(NetworkingClient.MasterServerAddress);
			if (flag)
			{
				Console.WriteLine("How did you even connect before?");
			}
			bool flag2 = NetworkingClient.LoadBalancingPeer.PeerState > PeerStateValue.Disconnected;
			if (flag2)
			{
				Console.WriteLine("Can only reconnect when being disconnected");
			}
			NetworkingClient.IsUsingNameServer = false;
			return NetworkingClient.ReconnectToMaster();
		}

		public static bool JoinOrCreateRoom(string roomId)
		{
			bool result;
			if (NetworkingClient == null)
			{
				result = false;
			}
			else
			{
				if (!NetworkingClient.InRoom)
				{
					var worldInfo = WorldResponse.GetInfo(roomId);
					int maxPlayers = (worldInfo?.capacity == null) ? 8 : worldInfo.capacity;
					string roomName = (worldInfo?.name == null) ? "VRChat Home" : worldInfo.name;
					EnterRoomParams enterRoomParams = new EnterRoomParams
					{
						RoomOptions = new RoomOptions
						{
							IsOpen = true,
							IsVisible = false,
							MaxPlayers = (byte)(maxPlayers * 2),
							CustomRoomPropertiesForLobby = new string[] {"name"},
							CustomRoomProperties = new Hashtable() { { "name", roomName } },
							EmptyRoomTtl = 0,
							DeleteNullProperties = true,
							PublishUserId = false
						},
						RoomName = roomId,
						CreateIfNotExists = true,
						Lobby = new TypedLobby("", LobbyType.Default),
						PlayerProperties = NetworkingClient.LocalPlayer.CustomProperties
					};
					result = NetworkingClient.OpJoinOrCreateRoom(enterRoomParams);
				}
				else
				{
					Console.WriteLine("Can't join room while in room");
					result = false;
				}
			}
			return result;
		}
		
		public static bool JoinRoom(string roomId)
		{
			bool result;
			if (NetworkingClient == null)
			{
				result = false;
			}
			else
			{
				if (!NetworkingClient.InRoom)
				{
					EnterRoomParams enterRoomParams = new EnterRoomParams
					{
						RoomName = roomId,
						CreateIfNotExists = true,
						Lobby = new TypedLobby("", LobbyType.Default),
						PlayerProperties = NetworkingClient.LocalPlayer.CustomProperties
					};
					result = NetworkingClient.OpJoinRoom(enterRoomParams);
				}
				else
				{
					Console.WriteLine("Can't join room while in room");
					result = false;
				}
			}
			return result;
		}

		public static bool LeaveRoom()
		{
			bool result;
			if (NetworkingClient == null)
			{
				result = false;
			}
			else
			{
				bool inRoom = NetworkingClient.InRoom;
				if (inRoom)
				{
					result = NetworkingClient.OpLeaveRoom(false, false);
				}
				else
				{
					Console.WriteLine("Must be in room");
					result = false;
				}
			}
			return result;
		}

		private static void OnOperation(OperationResponse operationResponse)
		{
		}

		private static void OnEvent(EventData eventData)
		{
		}

		private static void OnStateChanged(ClientState before, ClientState now)
		{
		}

		private static readonly PhotonHandler PhotonHandler;

		public static LoadBalancingClient NetworkingClient;

		public static Client ApiClient;

		private static string FixedRegion = "usw";
	}
}
