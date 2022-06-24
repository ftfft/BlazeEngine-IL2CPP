using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using BE4v.Mods.Core;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;

namespace BE4v.Mods.Min
{
    public static class ConsoleResource
    {
        public static IEnumerable<string> SplitCommandLine(string commandLine)
        {
            bool inQuotes = false;

            return commandLine.Split(c =>
            {
                if (c == '\"')
                    inQuotes = !inQuotes;

                return !inQuotes && c == ' ';
            })
                              .Select(arg => arg.Trim().TrimMatchingQuotes('\"'))
                              .Where(arg => !string.IsNullOrEmpty(arg));
        }

        public static IEnumerable<string> Split(this string str,
                                        Func<char, bool> controller)
        {
            int nextPiece = 0;

            for (int c = 0; c < str.Length; c++)
            {
                if (controller(str[c]))
                {
                    yield return str.Substring(nextPiece, c - nextPiece);
                    nextPiece = c + 1;
                }
            }

            yield return str.Substring(nextPiece);
        }

        public static string TrimMatchingQuotes(this string input, char quote)
        {
            if ((input.Length >= 2) &&
                (input[0] == quote) && (input[input.Length - 1] == quote))
                return input.Substring(1, input.Length - 2);

            return input;
        }
    }

    public class ClientConsole : IUpdate
    {
        public static bool isLog = false;
        public static bool isTest = false;

        public static string worldId = "wrld_a5be505e-3578-42eb-a40f-6ae98f27877e";
        public static string instanceId = "123456";

        public static void Start()
        {
            new Thread(() => { while (true) { UpdateCommand(); } }).Start();
        }

        public static string[] args = new string[0];
        public static void UpdateCommand()
        {
            string consoleRead = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(consoleRead)) return;
            try
            {
                args = ConsoleResource.SplitCommandLine(consoleRead).ToArray();
            }
            catch { return; }

            switch (args[0])
            {
                case "clear":
                    {
                        Console.Clear();
                        break;
                    }
                case "help":
                    {
                        Console.WriteLine("~~~ [ HELP For BE4v ] ~~~");
                        Console.WriteLine("- connect World_Id:InstanceId");
                        break;
                    }
                case "gg":
                    {
                        NotifySystem.Notify.isEnabled = !NotifySystem.Notify.isEnabled;
                        break;
                    }
                case "log":
                    {
                        isLog = !isLog;
                        if (isLog)
                        {
                            Console.WriteLine("Logs enabled!");
                        }
                        else
                        {
                            Console.WriteLine("Logs disabled!");
                        }
                        break;
                    }
                case "test":
                    {
                        isTest = !isTest;
                        if (isTest)
                        {
                            Console.WriteLine("isTest enabled!");
                        }
                        else
                        {
                            Console.WriteLine("isTest disabled!");
                        }
                        break;
                    }
                /*
            case "log2":
                {
                    isLogDetail = !isLogDetail;
                    if (isLogDetail)
                    {
                        Console.WriteLine("Logs detail enabled!");
                    }
                    else
                    {
                        Console.WriteLine("Logs detail disabled!");
                    }
                    break;
                }
                */
                case "portal":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "set")
                            {
                                if (args.Length > 2)
                                {
                                    string[] worldData = args[2].Split(':');
                                    worldId = worldData[0];
                                    if (worldData.Length > 1)
                                        instanceId = worldData[1];
                                    $"New portal settings: {worldId}:{instanceId}".RedPrefix("Portal Set");
                                }
                                else
                                {
                                    $"Arguments len: {args.Length}".RedPrefix("Portal Set");
                                }
                                break;
                            }
                        }
                        return;
                    }
                default: return;
            }
            args = new string[0];
        }

        public void Update()
        {
            if (args == null || args.Length < 1) return;
            switch (args[0])
            {
                case "get_master":
                    {
                        byte[] array = Encoding.UTF8.GetBytes(VRC.Player.Instance.user.id);
                        PhotonNetwork.NetworkingClient.OpRaiseEvent(208, array, new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others,
                            CachingOption = EventCaching.DoNotCache
                        }, default(SendOptions));
                        break;
                    }
                    /*
                case "udon":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "list")
                            {
                                try
                                {
                                    UdonBehaviour[] udons = UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
                                    foreach (var x in udons)
                                    {
                                        Console.WriteLine("- [" + x.gameObject.name + "] -");
                                        string[] programs = x.GetPrograms();
                                        Console.WriteLine("{");
                                        foreach (var y in programs)
                                        {
                                            Console.WriteLine("\t- " + y);
                                        }
                                        Console.WriteLine("}");
                                    }
                                }
                                catch { "Udon is bad!".RedPrefix("WARN"); }
                            }
                            else if (args[1] == "trigger")
                            {
                                if (args.Length > 2)
                                {
                                    GameObject gameObject = GameObject.Find(args[2]);
                                    if (gameObject == null)
                                    {
                                        Console.WriteLine(args[2] + " not found!");
                                        break;
                                    }
                                    if (args.Length > 3)
                                    {
                                        Network.RPC(VRC_EventHandler.VrcTargetType.All, gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { new IL2String(args[3]).ptr });
                                    }
                                }
                            }
                        }
                        break;
                    }
                    */
                    /*
                case "portal":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "create")
                            {
                                if (args.Length > 2)
                                {
                                    string[] worldData = args[2].Split(':');
                                    UserUtils.SpawnPortal(VRCPlayer.Instance.transform, worldData[0], (worldData.Length > 1) ? worldData[1] : instanceId);
                                    ($"Created portal: {worldId}:" + ((worldData.Length > 1) ? worldData[1] : instanceId)).RedPrefix("Create portal");
                                }
                            }
                        }
                        break;
                    }
                case "gc":
                    {
                        AutoClearRAM.Clear();
                        break;
                    }
                */
            }
            args = new string[0];
        }
    }
}
