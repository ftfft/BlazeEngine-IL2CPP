using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Photon;
using Photon.Realtime;
using ExitGames.Client.Photon;

using VRChatAPI;
using VRChatAPI.Responses;

namespace TheBot.Bot
{
    static class PhotonNetwork
    {
        #region Fields and Properties
        public static UserSelfRES SelfResponse;
        private static readonly PhotonHandler PhotonHandler;
        public static LoadBalancingClient NetworkingClient;
        public static Client ApiClient;
        private static string FixedRegion = "usw";

        static bool IsConnected
        {
            get
            {
                if (NetworkingClient == null)
                    return false;
                return NetworkingClient.IsConnected;
            }
        }

        static bool IsConnectedAndReady
        {
            get
            {
                if (NetworkingClient == null)
                    return false;
                return NetworkingClient.IsConnectedAndReady;
            }
        }

        public static ClientState NetworkClientState
        {
            get
            {
                if (NetworkingClient == null)
                    return ClientState.Disconnected;

                return NetworkingClient.State;
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
                return NetworkingClient?.AuthValues; 
            }
            set 
            { 
                if (NetworkingClient != null) 
                    NetworkingClient.AuthValues = value; 
            }
        }

        public static Room CurrentRoom
        {
            get
            {
                return NetworkingClient?.CurrentRoom;
            }
        }

        public static bool IsMasterClient
        {
            get
            {
                return NetworkingClient.CurrentRoom != null && NetworkingClient.CurrentRoom.MasterClientId == LocalPlayer.ActorNumber;
            }
        }

        public static Player LocalPlayer
        {
            get => NetworkingClient?.LocalPlayer;
        }

        public static Player MasterClient
        {
            get
            {
                return NetworkingClient?.CurrentRoom?.GetPlayer(NetworkingClient.CurrentRoom.MasterClientId);
            }
        }

        public static Player[] PlayerList
        {
            get
            {
                Room room = CurrentRoom;
                if (room != null)
                {
                    return room.Players.Values.OrderBy((x) => x.ActorNumber).ToArray();
                }
                else
                {
                    Console.WriteLine("Room was null");
                    return new Player[0];
                }
            }
        }

        public static int ServerTimestamp
        {
            get
            {
                return NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds;
            }
        }
        #endregion

        static PhotonNetwork()
        {
            ApiClient = new Client(Helpers.AskInput("Username"), Helpers.AskLogin("Password"));
            SelfResponse = Variables.UserSelfRES;

            NetworkingClient = new LoadBalancingClient(ConnectionProtocol.Udp);
            NetworkingClient.LoadBalancingPeer.QuickResendAttempts = 2;
            NetworkingClient.LoadBalancingPeer.SentCountAllowance = 7;

            NetworkingClient.EventReceived += OnEvent;
            NetworkingClient.OpResponseReceived += OnOperation;
            NetworkingClient.StateChanged += OnStateChanged;

            CustomTypes.Register();

            PhotonHandler = new PhotonHandler();
            NetworkingClient.AddCallbackTarget(PhotonHandler);

            NetworkingClient.AppId = "bf0942f7-9935-4192-b359-f092fa85bef1";
            NetworkingClient.NameServerHost = "ns.exitgames.com";
            NetworkingClient.MasterServerAddress = "92.38.173.6:5055";
            NetworkingClient.AppVersion = "Release_2018_server_968_2.5";

            NetworkingClient.AuthValues = new AuthenticationValues() 
            { 
                AuthType = CustomAuthenticationType.Custom 
            };
            NetworkingClient.AuthValues.AddAuthParameter("token", Variables.AuthCookie);
            NetworkingClient.AuthValues.AddAuthParameter("user", Variables.UserSelfRES.id);
        }

        public static int GetPing()
        {
            return NetworkingClient.LoadBalancingPeer.RoundTripTime;
        }

        public static bool Connect()
        {
            return NetworkingClient.ConnectToRegionMaster(FixedRegion);
        }

        public static void Disconnect()
        {
            if (NetworkingClient == null)
                return;

            NetworkingClient.Disconnect();
        }

        public static bool Reconnect()
        {
            if (string.IsNullOrEmpty(NetworkingClient.MasterServerAddress))
                Console.WriteLine("How did you even connect before?");
            if (NetworkingClient.LoadBalancingPeer.PeerState != PeerStateValue.Disconnected)
                Console.WriteLine("Can only reconnect when being disconnected");
            NetworkingClient.IsUsingNameServer = false;
            return NetworkingClient.ReconnectToMaster();
        }

        public static bool JoinRoom(string roomId)
        {
            if (NetworkingClient == null)
                return false;
            if (!NetworkingClient.InRoom)
            {
                EnterRoomParams enterRoomParams = new EnterRoomParams()
                {
                    RoomName = roomId,
                    CreateIfNotExists = true,
                    Lobby = new TypedLobby("", LobbyType.Default),
                    PlayerProperties = PhotonNetwork.NetworkingClient.LocalPlayer.CustomProperties
                };
                return NetworkingClient.OpJoinOrCreateRoom(enterRoomParams);
            }
            else
            {
                Console.WriteLine("Can't join room while in room");
                return false;
            }
        }

        public static bool LeaveRoom()
        {
            if (NetworkingClient == null)
                return false;
            if (NetworkingClient.InRoom)
            {
                return NetworkingClient.OpLeaveRoom(false);
            }
            else
            {
                Console.WriteLine("Must be in room");
                return false;
            }
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
    }

    public struct InstantiateParameters
    {
        public int[] viewIDs;
        public byte objLevelPrefix;
        public object[] data;
        public byte @group;
        public Quaternion rotation;
        public Vector3 position;
        public string prefabName;
        public Player creator;
        public int timestamp;

        public InstantiateParameters(string prefabName, Vector3 position, Quaternion rotation, byte @group, object[] data, byte objLevelPrefix, int[] viewIDs, Player creator, int timestamp)
        {
            this.prefabName = prefabName;
            this.position = position;
            this.rotation = rotation;
            this.@group = @group;
            this.data = data;
            this.objLevelPrefix = objLevelPrefix;
            this.viewIDs = viewIDs;
            this.creator = creator;
            this.timestamp = timestamp;
        }
    }
}
