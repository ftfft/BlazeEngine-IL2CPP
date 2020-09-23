/*
#if debug == false
using System;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using System.Collections.Generic;
using System.Reflection;
using NET_SDK.Reflection;
using NET_SDK.Harmony;
using BlazeEngine.Utils;

namespace BlazeEngine.Patch
{
    public class Kick
    {
        [HandleProcessCorruptedStateExceptions]
        public static void StartPatch()
        {
            Instance harmonyInstance = Manager.CreateInstance("Kick");
            if (Assemblies.AssemblyCSharp != null)
            {
                IL2CPP_Class patchClass = Assemblies.AssemblyCSharp.GetClass("ModerationManager");
                if (patchClass != null)
                {
                    IL2CPP_Method[] methods = patchClass.GetMethods();
                    foreach (IL2CPP_Method method in methods)
                    {
                        if (method.Name == "KickUserRPC" && method.GetParameterCount() == 5)
                        {
                            harmonyInstance.Patch(method, typeof(Kick).GetMethod("KickRPC", BindingFlags.NonPublic | BindingFlags.Static));
                            ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: Anti-Kick [" + method.Name + "]");
                        }
                        else if (method.Name == "WarnUserRPC" && method.GetParameterCount() == 3)
                        {
                            harmonyInstance.Patch(method, typeof(Kick).GetMethod("WarnRPC", BindingFlags.NonPublic | BindingFlags.Static));
                            ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: Anti-Kick [" + method.Name + "]");
                        }
                        /* else if (NET_SDK.IL2CPP.il2cpp_type_get_name(method.GetReturnType().Ptr) == "System.Boolean" && method.GetParameterCount() == 0)
                        {
                            if (method.Name == "MoveNext")
                                continue;

                            if (method.HasFlag(IL2CPP_BindingFlags.METHOD_STATIC))
                                continue;

                            if (method.HasFlag(IL2CPP_BindingFlags.METHOD_HAS_SECURITY))
                                continue;

                            if (!method.HasFlag(IL2CPP_BindingFlags.METHOD_PUBLIC))
                                continue;

                            try
                            {
                                if (!*(bool*)method.Invoke(ModerationManager.Instance.ptr).Unbox())
                                {
                                    harmonyInstance.Patch(method, typeof(Kick).GetMethod("KickHandler", BindingFlags.NonPublic | BindingFlags.Static));
                                    ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: " + method.Name);
                                }
                            }
                            catch { }
                        }
                        */
/*                    }
                }
                else
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: Anti-Kick [#2]");

                patchClass = null;
                patchClass = Assemblies.AssemblyCSharp.GetClass("Analytics");
                if (patchClass != null)
                {
                    IL2CPP_Method[] methods = patchClass.GetMethods();
                    foreach (IL2CPP_Method method in methods)
                    {
                        if(method.HasFlag(IL2CPP_BindingFlags.METHOD_STATIC) && method.HasFlag(IL2CPP_BindingFlags.METHOD_PUBLIC))
                        {
                            if (method.Name.Length > 30 && method.GetParameterCount() == 3)
                            {
                                if(NET_SDK.IL2CPP.il2cpp_type_get_name(method.GetParameters()[0].Ptr).Contains("Analytics")
                                && NET_SDK.IL2CPP.il2cpp_type_get_name(method.GetParameters()[0].Ptr).Length > 30
                                && NET_SDK.IL2CPP.il2cpp_type_get_name(method.GetParameters()[1].Ptr) == "System.Collections.Generic.Dictionary<System.String,System.Object>"
                                && NET_SDK.IL2CPP.il2cpp_type_get_name(method.GetParameters()[2].Ptr) == "System.Nullable<UnityEngine.Vector3>")
                                {
                                    harmonyInstance.Patch(method, typeof(Kick).GetMethod("DontContinue", BindingFlags.NonPublic | BindingFlags.Static));
                                    ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: Anti-Kick [Analytics.Send]");
                                }
                            }
                        }
                    }
                }
                else
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: Analytics [#2]");
            }
            else
                ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Not found: Assembly-CSharp [#1]");

            if (Assemblies.UnityAnalyticsModule != null)
            {
                IL2CPP_Class patchClass = Assemblies.UnityAnalyticsModule.GetClass("Analytics", "UnityEngine.Analytics");
                if (patchClass != null)
                {
                    IL2CPP_Method patchMethod = patchClass.GetMethod("CustomEvent", x => x.GetParameterCount() == 2);
                    if (patchMethod != null)
                    {
                        harmonyInstance.Patch(patchMethod, typeof(Kick).GetMethod("CustomEventPrefix", BindingFlags.NonPublic | BindingFlags.Static));
                        ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: UnityAnalytics");
                    }
                    else
                        ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: UnityAnalytics [#3]");
                }
                else
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: UnityAnalytics [#2]");
            }
            else
                ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Not found: UnityEngine.UnityAnalyticsModule [#1]");
        }

        private static void KickRPC(string userId, string message, string worldId, string instanceId, object instigator)
        {
        }

        private static void WarnRPC(string userId, string message, object instigator)
        {
        }

        private static UnityEngine.AnalyticsResult CustomEventPrefix(string customEventName, IDictionary<string, object> eventData)
        {
            return UnityEngine.AnalyticsResult.Ok;
        }

        private static bool KickHandler()
        {
            return false;
        }

        private static bool DontContinue()
        {
            return false;
        }
    }
}
#endif
*/