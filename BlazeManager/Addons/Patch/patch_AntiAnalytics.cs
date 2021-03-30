using System;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using UnityEngine.Analytics;
using BlazeTools;

namespace Addons.Patch
{
    public delegate AnalyticsResult _UnityEngine_Analytics_CustomEvent();
    public delegate void _Analytics_SendOrSendError(IntPtr arg1, IntPtr arg2, IntPtr arg3);
    public delegate void _VRC_Core_AnalyticsInterface_Send_3(IntPtr eventType, IntPtr eventProperties, IntPtr options);
    public delegate void _AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options);
    public static class patch_AntiAnalytics
    {
        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityengineunityanalyticsmodule]].GetClass("Analytics", "UnityEngine.Analytics").GetMethod(x => x.Name == "CustomEvent" && x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "eventData");
                if (method == null)
                    throw new Exception();
                IL2Ch.Patch(method, (_UnityEngine_Analytics_CustomEvent)UnityEngine_Analytics_CustomEvent);
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("0xAA1");
            }
            /*
            try
            {
                IL2Method method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("Analytics").GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName && x.GetParameters()[1].ReturnType.Name.StartsWith("System.Collections.Generic") && x.IsStatic);
                if (method == null)
                    throw new Exception();
                IL2Ch.Patch(method, (_Analytics_SendOrSendError)Analytics_SendOrSendError);
                method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("Analytics").GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name.StartsWith("Analytics") && x.GetParameters()[1].ReturnType.Name.StartsWith("System.Collections.Generic") && x.IsStatic);
                if (method == null)
                    throw new Exception();
                IL2Ch.Patch(method, (_Analytics_SendOrSendError)Analytics_SendOrSendError);
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("0xAA2");
            }
            */
            try
            {
                IL2Method method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("AmplitudeWrapper", "AmplitudeSDKWrapper").GetMethod("CheckedLogEvent");
                if (method == null)
                    throw new Exception();
                IL2Ch.Patch(method, (_AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent)AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent);
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("0xAA3");
            }
            try
            {
                IL2Method method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("AnalyticsInterface", "VRC.Core").GetMethod("Send", x => x.GetParameters().Length == 3);
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_VRC_Core_AnalyticsInterface_Send_3)VRC_Core_AnalyticsInterface_Send_3);
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("0xAA4");
            }
        }

        private static void VRC_Core_AnalyticsInterface_Send_3(IntPtr eventType, IntPtr eventProperties, IntPtr options)
        {
        }
        private static AnalyticsResult UnityEngine_Analytics_CustomEvent()
        {
            return AnalyticsResult.Ok;
        }
        private static void Analytics_SendOrSendError(IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {

        }
        private static void AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options)
        {

        }
    }
}
