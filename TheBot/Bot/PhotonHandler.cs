using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Photon;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections;

namespace TheBot.Bot
{
    class PhotonHandler : IConnectionCallbacks, ILobbyCallbacks, IInRoomCallbacks, IMatchmakingCallbacks
    {
        private static PhotonHandler Instance;
        private static LoadBalancingClient Client;

        private int intervalDispatch = 10;
        private int lastDispatch = Environment.TickCount;
        private int intervalSend = 50;
        private int lastSend = Environment.TickCount;

        private readonly Thread dispatchInThread;
        private readonly Thread sendOutThread;

        public PhotonHandler()
        {
            Instance = this;
            Client = PhotonNetwork.NetworkingClient;

            dispatchInThread = new Thread(this.IncomingUpdate);
            dispatchInThread.IsBackground = true;
            dispatchInThread.Start();

            sendOutThread = new Thread(this.OutgoingUpdate);
            sendOutThread.IsBackground = true;
            sendOutThread.Start();
        }

        private void IncomingUpdate()
        {
            while (true)
            {
                In();
                Thread.Sleep(10);
            }
        }

        private void In()
        {
            if (Environment.TickCount - this.lastDispatch > this.intervalDispatch)
            {
                lastDispatch = Environment.TickCount;
                Client.LoadBalancingPeer.DispatchIncomingCommands();
            }
        }

        private void OutgoingUpdate()
        {
            while (true)
            {
                Out();
                Thread.Sleep(10);
            }
        }

        private void Out()
        {
            if (Environment.TickCount - this.lastSend > this.intervalSend)
            {
                lastSend = Environment.TickCount;
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
            Hashtable hashtable = new Hashtable()
            {
                { "user", new Dictionary<string, object>()
                    {
                        { "id", PhotonNetwork.SelfResponse.id }
                    }
                },
                { "avatarDict", new Dictionary<string, object>()
                    {
                        { "id", PhotonNetwork.SelfResponse.currentAvatar }
                    }
                },
                { "modTag", "" },
                { "isInvisible", false },
                { "avatarVariations", PhotonNetwork.SelfResponse.currentAvatar },
                { "status", "active" },
                { "statusDescription", "BlazeBest#4974" },
                { "inVRMode", false },
                { "showSocialRank", true },
                { "steamUserID", "0" }
            };
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable);
            Console.WriteLine($"{(PhotonNetwork.LocalPlayer.CustomProperties.Count > 0 ? $"I have ({PhotonNetwork.LocalPlayer.CustomProperties.Count}) custom properties" : "I have no custom properties")}");
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
            //Console.WriteLine(data["token"].ToString());
        }

        public void OnDisconnected(DisconnectCause cause)
        {
            Console.WriteLine("[INFO] Disconnected! Reason: {0}", cause.ToString());
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
            //not needed
        }

        public void OnJoinedLobby()
        {
            Console.WriteLine("[INFO] Successfully joined lobby!");
        }

        public void OnJoinedRoom()
        {
            Console.WriteLine("[INFO] Successfully joined room!");
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            //not needed
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
            //not needed
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
            Console.WriteLine("[INFO] Masterclient got switched! New Masterclient: {0}", newMasterClient.NickName);
        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {
            Console.WriteLine("[INFO] New Player joined: {0}", newPlayer.NickName);
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
            Console.WriteLine("[INFO] Player left room: {0}", otherPlayer.NickName);
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            Console.WriteLine("[INFO] Playerproperties Update from {0}", targetPlayer.NickName);
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
            //not needed
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            //not needed
        }

        public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            Console.WriteLine("[INFO] Roomproperties changed!");
        }
    }
}
