using ExitGames.Client.Photon;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TheBot.Bot
{
    static class Helpers
    {
        private static readonly Hashtable SendInstantiateEvHashtable = new Hashtable();
        private static RaiseEventOptions SendInstantiateRaiseEventOptions = new RaiseEventOptions();

        public static bool InstantiateSelf()
        {
            //Creating instantiate parameters
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                new Vector3(-18f, 0f, 0f),
                new Quaternion(0f, 0f, 0f, 1f),
                0,
                null,
                0,
                new int[2]
                {
                    int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber + "00002")
                },
                PhotonNetwork.NetworkingClient.LocalPlayer,
                PhotonNetwork.NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds);

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
            return PhotonNetwork.NetworkingClient.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
        }

        public static bool InstantiateSelfInvis()
        {
            //Creating instantiate parameters
            InstantiateParameters parameters = new InstantiateParameters("VRCPlayer",
                new Vector3(0.1f, 0.1f, 0.1f),
                new Quaternion(0.1f, 0.1f, 0.1f, 1f),
                0,
                null,
                0,
                new int[2]
                {
                    int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber + "00001"),
                    int.Parse(PhotonNetwork.NetworkingClient.LocalPlayer.ActorNumber + "00002")
                },
                PhotonNetwork.NetworkingClient.LocalPlayer,
                PhotonNetwork.NetworkingClient.LoadBalancingPeer.ServerTimeInMilliSeconds);

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
            return PhotonNetwork.NetworkingClient.OpRaiseEvent(202, SendInstantiateEvHashtable, SendInstantiateRaiseEventOptions, SendOptions.SendReliable);
        }

        public static string AskInput(string message)
        {
            Console.WriteLine(message);
            var s = Console.ReadLine();
            Console.WriteLine();
            return s;
        }

        public static string AskLogin(string message)
        {
            Console.WriteLine(message);
            var s = Console.ReadLine();
            Console.WriteLine();
            Console.Clear();
            return s;
        }

        public static void ListDetails(this Player player)
        {
            foreach (DictionaryEntry entry in player.CustomProperties)
            {
                if ((string)entry.Key == "user")
                {
                    Console.WriteLine("user: {");
                    foreach (var kvp in (Dictionary<string, object>)entry.Value)
                    {
                        if (kvp.Key == "tags")
                        {
                            Console.WriteLine("tags: {");
                            object[] array = (object[])kvp.Value;
                            array.ToList().ForEach(a => Console.WriteLine(a.ToString()));
                            Console.WriteLine("}");
                        }
                        else
                            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                    }
                    Console.WriteLine("}");
                }
                else if ((string)entry.Key == "avatarDict")
                {
                    Console.WriteLine("avatarDict: {");
                    foreach (var kvp in (Dictionary<string, object>)entry.Value)
                    {
                        if (kvp.Key == "tags")
                        {
                            Console.WriteLine("tags: {");
                            object[] array = (object[])kvp.Value;
                            array.ToList().ForEach(a => Console.WriteLine(a.ToString()));
                            Console.WriteLine("}");
                        }
                        else if (kvp.Key == "unityPackages")
                        {
                            Console.WriteLine("unityPackages: {");
                            object[] array = (object[])kvp.Value;
                            int index = 0;
                            array.ToList().ForEach(a =>
                            {
                                index++;
                                Console.WriteLine($"\t{index}: {{");
                                foreach (var kvp2 in (Dictionary<string, object>)a)
                                {
                                    Console.WriteLine($"\t\t{kvp2.Key} : {kvp2.Value.ToString()}");
                                }
                                Console.WriteLine("\t}");
                            });
                            Console.WriteLine("}");
                        }
                        else
                            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                    }
                    Console.WriteLine("}");
                }
                else
                    Console.WriteLine($"{entry.Key} : {entry.Value}");
            }
        }

        public static Player ActorNumberToPlayer(int an)
        {
            return PhotonNetwork.NetworkingClient.CurrentRoom.Players.Values.First(p => p.ActorNumber == an);
        }

        public static IPAddress ToIPAddress(this uint ip) =>
            new IPAddress(new byte[]
            {
                (byte)(ip >> 24 & 0xff),
                (byte)(ip >> 16 & 0xff),
                (byte)(ip >> 8 & 0xff),
                (byte)(ip & 0xff)
            });
    }
}
