using System;
using System.Linq;
using UnityEngine;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common.Enums;
using BE4v.SDK.CPP2IL;

namespace VRC.Udon
{
    public class UdonBehaviour : MonoBehaviour
    {
        public UdonBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public void SendCustomNetworkEvent(NetworkEventTarget target, string eventName)
        {
            Instance_Class.GetMethod(nameof(SendCustomNetworkEvent)).Invoke(ptr, new IntPtr[] { new IntPtr(&target), new IL2String(eventName).ptr });
        }
        
        unsafe public void SendCustomEvent(string eventName)
        {
            Instance_Class.GetMethod(nameof(SendCustomEvent)).Invoke(ptr, new IntPtr[] { new IL2String(eventName).ptr });
        }

        public string[] GetPrograms()
        {
            return Instance_Class.GetMethod(nameof(GetPrograms)).Invoke(ptr)?.UnboxArray<string>();
        }

        unsafe public void SendCustomEventDelayedSeconds(string eventName, float delaySeconds, EventTiming eventTiming = EventTiming.Update)
        {
            Instance_Class.GetMethod(nameof(SendCustomEventDelayedSeconds)).Invoke(ptr, new IntPtr[] { new IL2String(eventName).ptr, new IntPtr(&delaySeconds), new IntPtr(&eventTiming) });
        }

        unsafe public void SendCustomEventDelayedFrames(string eventName, int delayFrames, EventTiming eventTiming = EventTiming.Update)
        {
            Instance_Class.GetMethod(nameof(SendCustomEventDelayedFrames)).Invoke(ptr, new IntPtr[] { new IL2String(eventName).ptr, new IntPtr(&delayFrames), new IntPtr(&eventTiming) });
        }

        unsafe public bool DisableInteractive
        {
            get => Instance_Class.GetProperty(nameof(DisableInteractive)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(DisableInteractive)).GetSetMethod().Invoke(ptr, new IntPtr(&value));
        }

        public bool IsInteractive
        {
            get => Instance_Class.GetProperty(nameof(IsInteractive)).GetGetMethod().Invoke(ptr).GetValuе<bool>(); 
        }

        public static new IL2Class Instance_Class = Assembler.list["VRC.Udon"].GetClass("UdonBehaviour", "VRC.Udon");
    }
}
