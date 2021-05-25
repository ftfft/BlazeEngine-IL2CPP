using System;
using UnityEngine.Analytics;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    public delegate AnalyticsResult _UnityEngine_Analytics_CustomEvent();
    public delegate void _Analytics_SendOrSendError(IntPtr arg1, IntPtr arg2, IntPtr arg3);
    public delegate void _VRC_Core_AnalyticsInterface_Send_3(IntPtr eventType, IntPtr eventProperties, IntPtr options);
    public delegate void _AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options);
    public static class Patch_NoAnalytics
    {
        public static void Start()
        {
            try
            {
                IL2Method method = Assembler.list["UnityEngine.Analytics"].GetClass("Analytics", "UnityEngine.Analytics").GetMethod(x => x.Name == "CustomEvent" && x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "eventData");
                if (method == null)
                    throw new Exception();
                new IL2Patch(method, (_UnityEngine_Analytics_CustomEvent)UnityEngine_Analytics_CustomEvent);
                Message(true);
            }
            catch
            {
                Message(false);
            }
            try
            {
                IL2Method method = Analytics.Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName && x.GetParameters()[1].ReturnType.Name.StartsWith("System.Collections.Generic") && x.IsStatic);
                if (method == null)
                    throw new Exception();
                new IL2Patch(method, (_Analytics_SendOrSendError)Analytics_SendOrSendError);
                Message(true);
            }
            catch
            {
                Message(false);
            }
            try 
            {
                IL2Method method = Analytics.Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name.StartsWith(x.ReflectedType.FullName) && x.GetParameters()[1].ReturnType.Name.StartsWith("System.Collections.Generic") && x.IsStatic);
                if (method == null)
                    throw new Exception();
                new IL2Patch(method, (_Analytics_SendOrSendError)Analytics_SendOrSendError);
                Message(true);
            }
            catch
            {
                Message(false);
            }
            try
            {
                IL2Method method = Assembler.list["VRCCore-Standalone"].GetClass("AmplitudeWrapper", "AmplitudeSDKWrapper").GetMethod("CheckedLogEvent");
                if (method == null)
                    throw new Exception();
                new IL2Patch(method, (_AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent)AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent);
                Message(true);
            }
            catch
            {
                Message(false);
            }
            try
            {
                IL2Method method = Assembler.list["VRCCore-Standalone"].GetClass("AnalyticsInterface", "VRC.Core").GetMethod("Send", x => x.GetParameters().Length == 3);
                if (method == null)
                    throw new Exception();

                new IL2Patch(method, (_VRC_Core_AnalyticsInterface_Send_3)VRC_Core_AnalyticsInterface_Send_3);
                Message(true);
            }
            catch
            {
                Message(false);
            }
        }

        private static void Message(bool isSuccess)
        {
            if (isSuccess)
                ("No Analytics [#" + ++iCount + "]").GreenPrefix(TMessage.SuccessPatch);
            else
                ("No Analytics [#" + ++iCount + "]").RedPrefix(TMessage.BadPatch);
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

        private static int iCount = 0;
    }
}
