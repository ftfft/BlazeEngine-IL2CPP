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

        public void SendCustomNetworkEvent(NetworkEventTarget target, string eventName)
        {
            Instance_Class.GetMethod(nameof(SendCustomNetworkEvent)).Invoke(ptr, new IntPtr[] { ((int)target).MonoCast(), IL2Import.StringToIntPtr(eventName) });
        }
        
        public string[] GetPrograms()
        {
            return Instance_Class.GetMethod(nameof(GetPrograms)).Invoke(ptr).unbox_ToArray_String();
        }


        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrcudon]].GetClass("UdonBehaviour", "VRC.Udon");
    }
}
