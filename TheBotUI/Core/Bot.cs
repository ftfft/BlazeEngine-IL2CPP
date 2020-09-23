using VRChatAPI;

namespace TheBotUI.Core {

    public class Bot {
        public PhotonClient PhotonClient { get; set; }
        public Client APIClient { get; set; }
        public string CachedRoomID { get; set; }

        public Bot(string username, string password) {
            APIClient = new Client(username, password);
            PhotonClient = new PhotonClient(APIClient.Variables, "Release_server_801_2.5");
        }
    }
}