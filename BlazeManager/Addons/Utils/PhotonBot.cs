using System;
using System.Threading;
using PhotonClient.API;

namespace Addons.Utils
{
    public static class PhotonBot
    {
        public static void SendConnect(string worldId, int command = 0, string target = null)
        {
            PhotonNetwork.command = (PhotonNetwork.Cmd)command;
            PhotonNetwork.target = target;
            new Thread(() => {

                PhotonNetwork.Disconnect();
                if (!PhotonNetwork.ConnectToNameServer())
                    return;

                while (PhotonNetwork.IsConnected && !PhotonNetwork.IsConnectedAndReady)
                    Thread.Sleep(50);

                if (!PhotonNetwork.IsConnectedAndReady)
                {
                    Console.WriteLine("[INFO] Failed connecting to photon!");
                }
                else
                {
                    Console.WriteLine("[INFO] Now connected to masterserver!");
                    while (PhotonNetwork.isWaitState)
                    {
                        Thread.Sleep(50);
                    }
                    if (!PhotonNetwork.IsConnectedAndReady)
                        return;

                    if (PhotonNetwork.JoinOrCreateRoom(worldId))
                    {
                    }
                }
            }).Start();
        }
    }
}
