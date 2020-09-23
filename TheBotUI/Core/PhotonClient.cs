using ExitGames.Client.Photon;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using VRChatAPI;

namespace TheBotUI.Core {

    public class PhotonClient : LoadBalancingClient, IConnectionCallbacks, IInRoomCallbacks, ILobbyCallbacks, IMatchmakingCallbacks {
        private readonly Thread photonThread;
        private readonly Thread handlerThread;
        public List<string> logs;
        public List<string> eventLogs;
        private Variables Variables;

        private readonly Hashtable SendInstantiateEvHashtable = new Hashtable();
        private RaiseEventOptions SendInstantiateRaiseEventOptions = new RaiseEventOptions();

        private int intervalDispatch = 10;
        private int lastDispatch = Environment.TickCount;
        private int intervalSend = 50;
        private int lastSend = Environment.TickCount;

        public PhotonClient(Variables variables, string releaseServer) : base(ConnectionProtocol.Udp) {
            logs = new List<string>(150);
            eventLogs = new List<string>(75);
            Variables = variables;

            this.AppId = "bf0942f7-9935-4192-b359-f092fa85bef1";
            this.AppVersion = releaseServer;
            this.NameServerHost = "ns.exitgames.com";

            photonThread = new Thread(PhotonLoop);
            photonThread.IsBackground = true;
            photonThread.Start();

            CustomTypes.Register(this);

            handlerThread = new Thread(HandlerLoop);
            handlerThread.IsBackground = true;
            handlerThread.Start();

            this.AuthValues = new AuthenticationValues() {
                AuthType = CustomAuthenticationType.Custom
            };
            this.AuthValues.AddAuthParameter("token", Variables.AuthCookie);

            this.AddCallbackTarget(this);
            this.EventReceived += CustomOnEvent;
            this.StateChanged += OnStateChanged;
            this.OpResponseReceived += OnResponseReceived;

            if (this.ConnectToRegionMaster("usw")) {
                Log(LogType.Info, "Connecting to usw..");
            }
            else {
                Log(LogType.Error, "Something went wrong while connecting to usw!");
            }
        }

        private void OnResponseReceived(OperationResponse opResponse) {
            Log(LogType.Info, $"Response received: {opResponse.ToString()}");
        }

        private void OnStateChanged(ClientState before, ClientState now) {
            Log(LogType.Info, $"Changed state from {before.ToString()} to {now.ToString()}");
        }

        private void CustomOnEvent(EventData eventData) {
            byte evCode = eventData.Code;
            switch (evCode) {
                case 1:     //USpeak
                case 201:   //Unreliable PhotonView
                case 206:   //Reliable PhotonView
                    break;

                default:
                    eventLogs.Insert(0, eventData.ToStringFull());
                    break;
            }
        }

        private void PhotonLoop() {
            while (true) {
                DoPhotonStuff();
                Thread.Sleep(10);
            }
        }

        private void DoPhotonStuff() {
            if (Environment.TickCount - this.lastDispatch > this.intervalDispatch) {
                lastDispatch = Environment.TickCount;
                this.LoadBalancingPeer.DispatchIncomingCommands();
            }
            if (Environment.TickCount - this.lastSend > this.intervalSend) {
                lastSend = Environment.TickCount;
                this.LoadBalancingPeer.SendOutgoingCommands();
            }
        }

        private void HandlerLoop() {
            while (true) {
                DoHandlerStuff();
                Thread.Sleep(10);
            }
        }

        private void DoHandlerStuff() {
        }

        public void OnConnected() {
            Log(LogType.Info, "Connected to Photon");
        }

        public void OnConnectedToMaster() {
            Log(LogType.Info, "Connected to Masterserver");
            Hashtable hashtable = new Hashtable() {
                { "user", new Dictionary<string, object>()
                    {
                        { "id", Variables.UserSelfRES.id }
                    }
                },
                { "avatarDict", new Dictionary<string, object>()
                    {
                        { "id", Variables.UserSelfRES.currentAvatar }
                    }
                },
                { "modTag", "" },
                { "isInvisible", false },
                { "avatarVariations", Variables.UserSelfRES.currentAvatar },
                { "status", "active" },
                { "statusDescription", "ya yeet" },
                { "inVRMode", false },
                { "showSocialRank", true },
                { "steamUserID", "0" }
            };
            this.LocalPlayer.SetCustomProperties(hashtable);
            Log(LogType.Info, $"{(LocalPlayer.CustomProperties.Count > 0 ? $"Set CustomProperties! ({LocalPlayer.CustomProperties.Count})" : "No CustomProperties were set!")}");
        }

        public void OnDisconnected(DisconnectCause cause) {
            Log(LogType.Error, $"Disconnected! Cause: {cause}");
        }

        public void OnRegionListReceived(RegionHandler regionHandler) {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data) {
            Log(LogType.Info, $"Received CustomAuthenticationResponse! {data.ToStringFull()}");
        }

        public void OnCustomAuthenticationFailed(string debugMessage) {
            Log(LogType.Error, $"CustomAuthentication failed! Message: {(string.IsNullOrEmpty(debugMessage) ? "N/A" : debugMessage)}");
        }

        public void OnPlayerEnteredRoom(Player newPlayer) {
            Log(LogType.Info, $"{newPlayer.NickName} joined the room!");
        }

        public void OnPlayerLeftRoom(Player otherPlayer) {
            Log(LogType.Info, $"{otherPlayer.NickName} left the room!");
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged) {
            Log(LogType.Info, $"The room properties have been updated. New props: {propertiesThatChanged.ToStringFull()}");
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) {
            Log(LogType.Info, $"{targetPlayer.NickName} changed PhotonProperties! New props: {changedProps.ToStringFull()}");
        }

        public void OnMasterClientSwitched(Player newMasterClient) {
            Log(LogType.Info, $"{newMasterClient.NickName} is the new Masterclient");
        }

        public void OnJoinedLobby() {
            Log(LogType.Info, "Joined the default lobby!");
        }

        public void OnLeftLobby() {
            Log(LogType.Info, "Left the default lobby!");
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList) {
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics) {
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList) {
        }

        public void OnCreatedRoom() {
            Log(LogType.Info, "Created a room!");
        }

        public void OnCreateRoomFailed(short returnCode, string message) {
            Log(LogType.Error, $"Failed to create room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
        }

        public void OnJoinedRoom() {
            Log(LogType.Info, "Joined the room!");
        }

        public void OnJoinRoomFailed(short returnCode, string message) {
            Log(LogType.Error, $"Failed to join room! Code: {returnCode} Message: {(string.IsNullOrEmpty(message) ? "N/A" : message)}");
        }

        public void OnJoinRandomFailed(short returnCode, string message) {
        }

        public void OnLeftRoom() {
            Log(LogType.Info, "Left the room!");
        }

        private void Log(LogType logType, string log) {
            switch (logType) {
                case LogType.Info:
                    logs.Insert(0, $"[INFO] {log}");
                    break;

                case LogType.Error:
                    logs.Insert(0, $"[ERROR] {log}");
                    break;

                case LogType.Warning:
                    logs.Insert(0, $"[WARNING] {log}");
                    break;

                default:
                    logs.Insert(0, log);
                    break;
            }
        }

        private enum LogType {
            Info,
            Warning,
            Error
        }

        public bool InstantiateSelf() {
            //Creating instantiate parameters
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                new Vector3(-18f, 0f, 0f),
                new Quaternion(0f, 0f, 0f, 1f),
                0,
                null,
                0,
                new int[2]
                {
                    int.Parse(this.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00002")
                },
                this.LocalPlayer,
                this.LoadBalancingPeer.ServerTimeInMilliSeconds);

            //Instantiation ID
            int intID = parameters.viewIDs[0];

            SendInstantiateEvHashtable.Clear();
            SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
            SendInstantiateEvHashtable[(byte)1] = parameters.position;
            SendInstantiateEvHashtable[(byte)2] = parameters.rotation;
            if (parameters.viewIDs.Length > 1)
                SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
            SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
            SendInstantiateEvHashtable[(byte)7] = intID;

            //Adding our instantiation to the Roomcache
            SendInstantiateRaiseEventOptions = RaiseEventOptions.Default;
            SendInstantiateRaiseEventOptions.CachingOption = EventCaching.AddToRoomCache;
            //Finally calling OpRaiseEvent to send it over the network
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
        }

        public bool InstantiateSelfInvis() {
            //Creating instantiate parameters
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                new Vector3(0.1f, 0.1f, 0.1f),
                new Quaternion(0.1f, 0.1f, 0.1f, 1f),
                0,
                null,
                0,
                new int[2]
                {
                    int.Parse(this.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(this.LocalPlayer.ActorNumber + "00002")
                },
                this.LocalPlayer,
                this.LoadBalancingPeer.ServerTimeInMilliSeconds);

            //Instantiation ID
            int intID = parameters.viewIDs[0];

            SendInstantiateEvHashtable[(byte)0] = parameters.prefabName;
            SendInstantiateEvHashtable[(byte)1] = parameters.position;
            SendInstantiateEvHashtable[(byte)2] = parameters.rotation;
            if (parameters.viewIDs.Length > 1)
                SendInstantiateEvHashtable[(byte)4] = parameters.viewIDs;
            SendInstantiateEvHashtable[(byte)6] = parameters.timestamp;
            SendInstantiateEvHashtable[(byte)7] = intID;

            //Adding our instantiation to the Roomcache
            SendInstantiateRaiseEventOptions = new RaiseEventOptions();
            SendInstantiateRaiseEventOptions.TargetActors = new int[] { 0 };
            //Finally calling OpRaiseEvent to send it over the network
            return this.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
        }
    }

    public struct InstantiateParameters {
        public int[] viewIDs;
        public byte objLevelPrefix;
        public object[] data;
        public byte @group;
        public Quaternion rotation;
        public Vector3 position;
        public string prefabName;
        public Player creator;
        public int timestamp;

        public InstantiateParameters(string prefabName, Vector3 position, Quaternion rotation, byte @group, object[] data, byte objLevelPrefix, int[] viewIDs, Player creator, int timestamp) {
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