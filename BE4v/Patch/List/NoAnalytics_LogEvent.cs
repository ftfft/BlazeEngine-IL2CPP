using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class NoAnalytics_LogEvent : IPatch
    {
        public delegate void _AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options);
        public void Start()
        {
            IL2Method method = Assembler.list["VRCCore-Standalone"].GetClass("AmplitudeWrapper", "AmplitudeSDKWrapper").GetMethod("CheckedLogEvent");
            if (method == null)
                throw new NullReferenceException();

            new IL2Patch(method, (_AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent)AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent);
        }

        private static void AmplitudeSDKWrapper_AmplitudeWrapper_CheckedLogEvent(IntPtr instance, IntPtr eventType, IntPtr eventProperties, IntPtr timestamp, IntPtr options)
        {

        }
    }
}
