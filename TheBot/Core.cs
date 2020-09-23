using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheBot.Bot;
using VRChatAPI;
using VRChatAPI.Endpoints;
using VRChatAPI.Responses;

namespace TheBot
{
    static class Core
    {
        static List<string> actions;
        static string selected;
        static int index = 0;
        static string cachedRoomId;

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    MainAsync().GetAwaiter().GetResult();
                    if (exception != null)
                    {
                        Console.WriteLine(exception);
                        exception = null;
                    }
                }
                catch (Exception ex) { exception = ex; }
            }
        }

        private static Exception exception = null; 
        static async Task MainAsync()
        {
            actions = new List<string>();
            actions.Add("connect");
            actions.Add("join");
            actions.Add("leave");
            actions.Add("list players");
            actions.Add("player details");
            actions.Add("instantiate");
            actions.Add("instantiate invisible");
            actions.Add("exit");
            actions.Add("reconnect");

            while (true)
            {
                selected = DrawMenu(actions);
                switch(selected)
                {
                    case "connect":
                        {
                            Console.Clear();
                            if (PhotonNetwork.Connect())
                                Console.WriteLine("Connected!");
                            break;
                        }
                    case "join":
                        {
                            Console.Clear();
                            cachedRoomId = Helpers.AskInput("WorldID:InstanceID");
                            if (PhotonNetwork.JoinRoom(cachedRoomId))
                                Console.WriteLine("Joined room!");
                            break;
                        }
                    case "leave":
                        {
                            Console.Clear();
                            if (PhotonNetwork.LeaveRoom())
                                Console.WriteLine("Left room!");
                            break;
                        }
                    case "list players":
                        {
                            Console.Clear();
                            Console.WriteLine("Current Players:");
                            PhotonNetwork.PlayerList.ToList().ForEach(p => Console.WriteLine($"{p.NickName.PadRight(30, ' ')} (ID: {p.ActorNumber}{(p.IsMasterClient ? "(Master)" : "")})"));
                            break;
                        }
                    case "player details":
                        {
                            Console.Clear();
                            PhotonNetwork.PlayerList[int.Parse(Helpers.AskInput("Actor Number:"))].ListDetails();
                            break;
                        }
                    case "instantiate":
                        {
                            Console.Clear();
                            if (Helpers.InstantiateSelf())
                                Console.WriteLine("Instantiated self");
                            break;
                        }
                    case "instantiate invisible": //Instantiates the bot in the room for the server only, invisible in the Social-Menu & for everyone else
                        {
                            Console.Clear();
                            if (Helpers.InstantiateSelfInvis())
                                Console.WriteLine("Instantiated self invis");
                            break;
                        }
                    case "exit":
                        {
                            Console.Clear();
                            PhotonNetwork.Disconnect();
                            Environment.Exit(0);
                            break;
                        }
                    case "reconnect":
                        {
                            Console.Clear();
                            if (PhotonNetwork.Reconnect())
                            {
                                if (PhotonNetwork.JoinRoom(cachedRoomId))
                                {
                                    Console.WriteLine("Reconnected and rejoined room!");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to join room");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed to reconnect");
                            }
                            break;
                        }
                }
            }
        }

        static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    index = 0;
                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1;
                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
