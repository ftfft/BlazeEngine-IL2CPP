/*
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NET_SDK.Reflection;
using NET_SDK.Harmony;
using BlazeEngine.Utils;

namespace BlazeEngine.Patch
{
    using System;

    public enum HTTPMethods : byte
    {
        Get,
        Head,
        Post,
        Put,
        Delete,
        Patch
    }

    public class InvisAPI
    {
        public static void StartPatch()
        {
            Instance harmonyInstance = Manager.CreateInstance("InvisAPI");
            if (Assemblies.VRChatStandalone != null)
            {
                IL2CPP_Class patchClass = Assemblies.VRChatStandalone.GetClass("API", "VRC.Core");
                if (patchClass != null)
                {
                    IL2CPP_Method patchMethod = patchClass.GetMethod("SendRequest", x => x.GetParameterCount() == 9);
                    if (patchMethod != null)
                    {
                        harmonyInstance.Patch(patchMethod, typeof(InvisAPI).GetMethod("SendRequestPrefix", BindingFlags.NonPublic | BindingFlags.Static));
                        ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: InvisAPI");
                    }
                    else
                        ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: InvisAPI [#3]");
                }
                else
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: InvisAPI [#2]");
            }
            else
                ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: InvisAPI [#1]");
        }

        private static void SendRequestPrefix(string endpoint, HTTPMethods method, object responseContainer, Dictionary<string, object> requestParams, bool authenticationRequired = true, bool disableCache = false, float cacheLifetime = 3600f, int retryCount = 2, object credentials = null)
        {
            Console.WriteLine("Send -> ");
            Console.WriteLine(endpoint);
        }
    }
}
*/