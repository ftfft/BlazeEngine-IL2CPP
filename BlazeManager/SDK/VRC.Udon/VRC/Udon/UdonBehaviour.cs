using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Udon.Common.Interfaces;

namespace VRC.Udon
{
    public class UdonBehaviour : MonoBehaviour
    {
        public UdonBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodSendCustomNetworkEvent = null;
        public void SendCustomNetworkEvent(NetworkEventTarget target, string eventName)
        {
            if (methodSendCustomNetworkEvent == null)
            {
                methodSendCustomNetworkEvent = Instance_Class.GetMethod("SendCustomNetworkEvent");
                if (methodSendCustomNetworkEvent == null)
                    return;
            }

            methodSendCustomNetworkEvent.Invoke(ptr, new IntPtr[] { ((int)target).MonoCast(), IL2Import.StringToIntPtr(eventName) });
        }
        

        private static IL2Method methodGetPrograms = null;
        public string[] GetPrograms()
        {
            if (methodGetPrograms == null)
            {
                methodGetPrograms = Instance_Class.GetMethod("GetPrograms");
                if (methodGetPrograms == null)
                    return null;
            }

            return methodGetPrograms.Invoke(ptr).UnboxArray<string>();
        }


        public static new IL2Type Instance_Class = Assemblies.a["VRC.Udon"].GetClass("UdonBehaviour", "VRC.Udon");
    }
}
